using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Utils.Consoles
{
	/// <summary>
	/// Провайдер для логера.
	/// </summary>
	public class ConsoleLoggerProvider : ILoggerProvider
	{
		/// <summary>
		/// Создать логер.
		/// </summary>
		/// <param name="categoryName"></param>
		/// <returns></returns>
		public ILogger CreateLogger(string categoryName)
		{
			return new ConsoleLogger();
		}

		public void Dispose()
		{
		}
	}
}
