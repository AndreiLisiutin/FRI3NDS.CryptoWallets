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
		/// <param name="regionId">Идентификатор региона.</param>
		/// <param name="countryId">Идентификатор страны.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список регионов.</returns>
		List<Region> Get(
			Guid? regionId = null,
			Guid? countryId = null,
			int? pageSize = null,
			int? pageNumber = null);
	}
}
