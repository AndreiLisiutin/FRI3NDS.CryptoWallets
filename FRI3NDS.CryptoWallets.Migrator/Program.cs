using FRI3NDS.CryptoWallets.Migrator.Infrastructure;
using FRI3NDS.CryptoWallets.Migrator.Migrator;
using Microsoft.Extensions.Configuration;
using FRI3NDS.CryptoWallets.Utils.Extensions;
using System;
using Microsoft.DotNet.PlatformAbstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace FRI3NDS.CryptoWallets.Migrator
{
	class Program
	{
		static void Main(string[] args)
		{
			IConfigurationRoot configuration = LoadConfiguration();
			IServiceProvider provider = ServiceConfiguration.CreateServiceProvider(configuration);

			IMigrator migrator = provider.GetService<IMigrator>();
			migrator.Migrate();
			Console.ReadKey();
		}

		/// <summary>
		/// Загрузить конфигурацию проекта.
		/// </summary>
		/// <returns>Конфигурация проекта.</returns>
		private static IConfigurationRoot LoadConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();
			return builder.Build();
		}
	}
}
