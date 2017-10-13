using AutoMapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий регионов.
	/// </summary>
	public class RegionRepository : RepositoryBase<Region>, IRegionRepository
	{
		private static List<Region> _list = new List<Region>()
		{
			new Region()
			{
				RegionId = Guid.NewGuid(),
				Name = "Татарстан",
				CountryId = Guid.NewGuid()
			},
			new Region()
			{
				RegionId = Guid.NewGuid(),
				Name = "Московская область",
				CountryId = Guid.NewGuid()
			},
			new Region()
			{
				RegionId = Guid.NewGuid(),
				Name = "Округ Колумбия",
				CountryId = Guid.NewGuid()
			},
			new Region()
			{
				RegionId = Guid.NewGuid(),
				Name = "13 район",
				CountryId = Guid.NewGuid()
			}
		};

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
			return _list.FirstOrDefault(e => e.RegionId == id);
		}

		/// <summary>
		/// Получить список регионов.
		/// </summary>
		/// <returns>Список регионов.</returns>
		public List<Region> Get()
		{
			return _list;
		}
	}
}
