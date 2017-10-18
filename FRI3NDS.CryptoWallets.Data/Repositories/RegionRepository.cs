using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий регионов.
	/// </summary>
	public class RegionRepository : RepositoryBase<Region>, IRegionRepository
	{
		public RegionRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить регион по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор региона.</param>
		/// <returns>Регион, найденный по его идентификатору.</returns>
		public Region GetById(Guid id)
		{
			return this.Get(regionId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список регионов.
		/// </summary>
		/// <param name="regionId">Идентификатор региона.</param>
		/// <param name="countryId">Идентификатор страны.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список регионов.</returns>
		public List<Region> Get(
			Guid? regionId = null,
			Guid? countryId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_region_id", regionId, DbType.Guid);
			@params.Add("_country_id", countryId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Region> list = CallProcedure<Region>("Region$Query", @params);
			return list;
		}
	}
}
