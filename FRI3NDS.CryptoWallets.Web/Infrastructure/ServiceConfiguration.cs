using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Services;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FRI3NDS.CryptoWallets.Web.Infrastructure
{
	/// <summary>
	/// Конфигурация зависимостей проектов.
	/// </summary>
	public static class ServiceConfiguration
	{
		/// <summary>
		/// Задать зависимости проектов.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
		{
			services.AddSingleton<IConfiguration>((serviceProvider) => configuration);
			ConfigureDataServices(services);
			ConfigureCoreServices(services);
		}

		/// <summary>
		/// Задать зависимости проекта .Core.
		/// </summary>
		/// <param name="services">Набор сервисов.</param>
		private static void ConfigureCoreServices(IServiceCollection services)
		{

			// сервисы - компоненты с бизнес-логикой приложения
			services.AddTransient<IAlertFrequencyService, AlertFrequencyService>();
			services.AddTransient<IAlertService, AlertService>();
			services.AddTransient<IAttachmentService, AttachmentService>();
			services.AddTransient<ICertificateService, CertificateService>();
			services.AddTransient<ICertificateStateService, CertificateStateService>();
			services.AddTransient<ICertificateTypeService, CertificateTypeService>();
			services.AddTransient<ICityService, CityService>();
			services.AddTransient<ICountryService, CountryService>();
			services.AddTransient<ICurrencyService, CurrencyService>();
			services.AddTransient<ICurrencyRateService, CurrencyRateService>();
			services.AddTransient<ICurrencyTypeService, CurrencyTypeService>();
			services.AddTransient<IDocumentService, DocumentService>();
			services.AddTransient<IFaqService, FaqService>();
			services.AddTransient<IQuestionService, QuestionService>();
			services.AddTransient<IRegionService, RegionService>();
			services.AddTransient<ITransactionService, TransactionService>();
			services.AddTransient<ITransactonActionService, TransactonActionService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IWalletService, WalletService>();
		}

		/// <summary>
		/// Задать зависимости проекта .Data.
		/// </summary>
		/// <param name="services">Набор сервисов.</param>
		private static void ConfigureDataServices(IServiceCollection services)
		{
			services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
		}
	}
}
