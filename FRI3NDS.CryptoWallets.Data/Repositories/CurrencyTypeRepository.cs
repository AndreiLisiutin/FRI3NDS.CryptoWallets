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
	/// Репозиторий типов валют.
	/// </summary>
	public class CurrencyTypeRepository : RepositoryBase<CurrencyType>, ICurrencyTypeRepository
	{
		private static List<CurrencyType> _list = new List<CurrencyType>()
		{
			new CurrencyType()
			{
				CurrencyTypeId = 1,
				Name = "Фиатная"
			},
			new CurrencyType()
			{
				CurrencyTypeId = 2,
				Name = "Криптота ***ная"
			}
		};

		public CurrencyTypeRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить тип валюты по идентификатору сатуса.
		/// </summary>
		/// <param name="id">Идентификатор типа валюты.</param>
		/// <returns>Тип валюты, найденный по его идентификатору.</returns>
		public CurrencyType GetById(int id)
		{
			return _list.FirstOrDefault(e => e.CurrencyTypeId == id);
		}

		/// <summary>
		/// Получить список типов валют.
		/// </summary>
		/// <returns>Список типов валют.</returns>
		public List<CurrencyType> Get()
		{
			return _list;
		}
	}
}
