using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Migrator.Migrator;
using FRI3NDS.CryptoWallets.Utils.Consoles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Migrator.Infrastructure
{
	/// <summary>
	/// Конфигуратор DI.
	/// </summary>
	public static class ServiceConfiguration
	{
		/// <summary>
		/// Создать сервис-локатор для DI.
		/// </summary>
		/// <param name="configuration">Конфигурация проекта.</param>
		/// <returns></returns>
		public static IServiceProvider CreateServiceProvider(IConfigurationRoot configuration)
		{
			IServiceCollection services = new ServiceCollection();
			ConfigureServices(services, configuration);
			IServiceProvider provider = services.BuildServiceProvider();

			provider
				.GetService<ILoggerFactory>()
				.AddProvider(new ConsoleLoggerProvider());

			return provider;
		}

		/// <summary>
		/// Задать зависимости проектов.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
		{
			services.AddLogging();
			services.AddSingleton<IConfiguration>((x) => configuration);
			services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
			services.AddTransient<IMigrator, Migrator.Migrator>();
			services.AddTransient<IVersionComparer, VersionNumberComparer>();
		}
	}
}
