using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий городов.
	/// </summary>
	public interface ICityRepository : IRepositoryBase<City>
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
		/// <param name="cityId">Идентификатор города.</param>
		/// <param name="regionId">Идентификатор региона.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список городов.</returns>
		List<City> Get(
			Guid? cityId = null,
			Guid? regionId = null,
			int? pageSize = null,
			int? pageNumber = null);
	}
}
