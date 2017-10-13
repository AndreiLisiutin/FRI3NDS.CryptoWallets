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
	/// Репозиторий курсов валюты.
	/// </summary>
	public class CurrencyRateRepository : RepositoryBase<CurrencyRateBase>, ICurrencyRateRepository
	{
		private static FakeStore<CurrencyRateBase, CurrencyRate> store = new FakeStore<CurrencyRateBase, CurrencyRate>();

		public CurrencyRateRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Курс валюты, найденный по идентификатору.</returns>
		public CurrencyRate GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список курсов валюты.
		/// </summary>
		/// <returns>Список курсов валюты.</returns>
		public List<CurrencyRate> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить курс валюты.
		/// </summary>
		/// <param name="CurrencyRate">Сохраняемый курс валюты.</param>
		/// <returns>Сохраненный курс валюты с заполненным идентификатором</returns>
		public Guid Save(CurrencyRateBase currencyRate)
		{
			return store.Save(currencyRate).CurrencyRateId;
		}

		/// <summary>
		/// Удалить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор курса валюты.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
