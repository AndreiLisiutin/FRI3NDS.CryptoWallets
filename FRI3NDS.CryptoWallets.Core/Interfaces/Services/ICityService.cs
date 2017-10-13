using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий городов.
	/// </summary>
	public interface ICityService : IServiceBase
	{
		/// <summary>
		/// Получить город по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор города.</param>
		/// <returns>Город, найденный по его идентификатору.</returns>
		City GetById(Guid id);

		/// <summary>
		/// Получить список городов.
		/// </summary>
		/// <returns>Список городов.</returns>
		List<City> Get();
	}
}
