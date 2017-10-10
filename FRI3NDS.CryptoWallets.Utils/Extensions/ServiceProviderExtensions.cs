using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Utils.Extensions
{
	/// <summary>
	/// Расширения сервис-провайдера.
	/// </summary>
	public static class ServiceProviderExtensions
	{
		/// <summary>
		/// Получить сервис.
		/// </summary>
		/// <typeparam name="T">Тип сервиса.</typeparam>
		/// <param name="serviceProvider">Сервис-провайдер.</param>
		/// <returns>Сервис.</returns>
		public static T GetService<T>(this IServiceProvider serviceProvider)
		{
			return (T)serviceProvider.GetService(typeof(T));
		}
	}
}
