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
	/// Репозиторий городов.
	/// </summary>
	public class CityRepository : RepositoryBase<City>, ICityRepository
	{
		public CityRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить город по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор города.</param>
		/// <returns>Город, найденный по его идентификатору.</returns>
		public City GetById(Guid id)
		{
			return Get(cityId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список городов.
		/// </summary>
		/// <param name="cityId">Идентификатор города.</param>
		/// <param name="regionId">Идентификатор региона.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список городов.</returns>
		public List<City> Get(
			Guid? cityId = null,
			Guid? regionId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_city_id", cityId, DbType.Guid);
			@params.Add("_region_id", regionId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<City> list = CallProcedure<City>("City$Query", @params);
			return list;
		}
	}
}
