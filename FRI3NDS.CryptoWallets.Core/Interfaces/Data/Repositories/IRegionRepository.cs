using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий регионов.
	/// </summary>
	public interface IRegionRepository : IRepositoryBase<Region>
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
