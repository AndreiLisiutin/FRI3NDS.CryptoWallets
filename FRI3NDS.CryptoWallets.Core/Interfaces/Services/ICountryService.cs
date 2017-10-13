using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий стран.
	/// </summary>
	public interface ICountryService : IServiceBase
	{
		/// <summary>
		/// Получить страну по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор страны.</param>
		/// <returns>Страна, найденная по ее идентификатору.</returns>
		Country GetById(Guid id);

		/// <summary>
		/// Получить список стран.
		/// </summary>
		/// <returns>Список стран.</returns>
		List<Country> Get();
	}
}
