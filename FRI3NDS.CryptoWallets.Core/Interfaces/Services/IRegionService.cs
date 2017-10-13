using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий регионов.
	/// </summary>
	public interface IRegionService : IServiceBase
	{
		/// <summary>
		/// Получить регион по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор региона.</param>
		/// <returns>Регион, найденный по его идентификатору.</returns>
		Region GetById(Guid id);

		/// <summary>
		/// Получить список регионов.
		/// </summary>
		/// <returns>Список регионов.</returns>
		List<Region> Get();
	}
}
