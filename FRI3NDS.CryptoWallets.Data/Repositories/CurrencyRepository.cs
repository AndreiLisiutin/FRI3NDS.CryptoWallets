using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий валют.
	/// </summary>
	public class CurrencyRepository : RepositoryBase<CurrencyBase>, ICurrencyRepository
	{
		private static FakeStore<CurrencyBase, Currency> store = new FakeStore<CurrencyBase, Currency>();

		public CurrencyRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Валюта, найденный по идентификатору.</returns>
		public Currency GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список валют.
		/// </summary>
		/// <returns>Список валют.</returns>
		public List<Currency> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить валюту.
		/// </summary>
		/// <param name="Currency">Сохраняемая валюта.</param>
		/// <returns>Сохраненная валюта с заполненным идентификатором</returns>
		public Guid Save(CurrencyBase currency)
		{
			return store.Save(currency).CurrencyId;
		}

		/// <summary>
		/// Удалить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор валюты.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
