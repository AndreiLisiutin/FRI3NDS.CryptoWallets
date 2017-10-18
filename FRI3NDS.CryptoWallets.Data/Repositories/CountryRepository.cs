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
	/// Репозиторий стран.
	/// </summary>
	public class CountryRepository : RepositoryBase<Country>, ICountryRepository
	{
		public CountryRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить страну по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор страны.</param>
		/// <returns>Страна, найденная по ее идентификатору.</returns>
		public Country GetById(Guid id)
		{
			return Get(countryId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список стран.
		/// </summary>
		/// <param name="countryId">Идентификатор страны.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns></returns>
		public List<Country> Get(
			Guid? countryId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_country_id", countryId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Country> list = CallProcedure<Country>("Country$Query", @params);
			return list;
		}
	}
}
