using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий городов.
	/// </summary>
	public class CityRepository : RepositoryBase<City>, ICityRepository
	{
		private static List<City> _list = new List<City>()
		{
			new City()
			{
				CityId = Guid.NewGuid(),
				Name = "Казань",
				RegionId = Guid.NewGuid()
			},
			new City()
			{
				CityId = Guid.NewGuid(),
				Name = "Москва",
				RegionId = Guid.NewGuid()
			},
			new City()
			{
				CityId = Guid.NewGuid(),
				Name = "Лос-Анджелес",
				RegionId = Guid.NewGuid()
			},
			new City()
			{
				CityId = Guid.NewGuid(),
				Name = "Париж",
				RegionId = Guid.NewGuid()
			}
		};

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
			return _list.FirstOrDefault(e => e.CityId == id);
		}

		/// <summary>
		/// Получить список городов.
		/// </summary>
		/// <returns>Список городов.</returns>
		public List<City> Get()
		{
			return _list;
		}
	}
}
