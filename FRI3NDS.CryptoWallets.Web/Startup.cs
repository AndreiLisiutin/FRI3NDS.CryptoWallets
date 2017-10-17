using FRI3NDS.CryptoWallets.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Globalization;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env, IConfiguration configuration)
		{
			//Configuration = configuration;
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			//авторизация-аутентификация
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.Authority = TokenAuthenticationOptions.Audience;
				options.Audience = TokenAuthenticationOptions.Audience;
				options.ClaimsIssuer = TokenAuthenticationOptions.Issuer;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = TokenAuthenticationOptions.Parameters;
			});

			//локализация по заголовку Language (en|ru) в запросе
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo("en"),
					new CultureInfo("ru")
				};

				options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
				options.RequestCultureProviders.Insert(0, new RouteCultureProvider(options.DefaultRequestCulture));
			});

			//стандартное
			services.AddMvc();
			services.AddSignalR();
			ServiceConfiguration.ConfigureServices(services, this.Configuration);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			loggerFactory.AddNLog();
			app.AddNLogWeb();
			env.ConfigureNLog("NLog.config");

			var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(localizationOptions.Value);

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseAuthentication();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseSignalR(routes =>
			{
				routes.MapHub<ChatHub>("chat");
			});

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}

	public class ChatHub : Hub
	{

		public Task Send(string message)
		{
			return Clients.Client(this.Context.ConnectionId).InvokeAsync("Send", message);
		}
	}
}
