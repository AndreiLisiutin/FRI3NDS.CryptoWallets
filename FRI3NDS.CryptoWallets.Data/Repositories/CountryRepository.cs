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
	/// Репозиторий стран.
	/// </summary>
	public class CountryRepository : RepositoryBase<Country>, ICountryRepository
	{
		private static List<Country> _list = new List<Country>()
		{
			new Country()
			{
				CountryId = Guid.NewGuid(),
				Name = "Россия"
			},
			new Country()
			{
				CountryId = Guid.NewGuid(),
				Name = "Пендосы"
			},
			new Country()
			{
				CountryId = Guid.NewGuid(),
				Name = "Лягушатники"
			}
		};

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
			return _list.FirstOrDefault(e => e.CountryId == id);
		}

		/// <summary>
		/// Получить список стран.
		/// </summary>
		/// <returns>Список стран.</returns>
		public List<Country> Get()
		{
			return _list;
		}
	}
}
