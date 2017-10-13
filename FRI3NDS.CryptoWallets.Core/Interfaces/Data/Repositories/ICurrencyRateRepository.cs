using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий курсов валюты.
	/// </summary>
	public interface ICurrencyRateRepository : IRepositoryBase<CurrencyRateBase>
	{
		/// <summary>
		/// Получить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Курс валюты, найденный по идентификатору.</returns>
		CurrencyRate GetById(Guid id);

		/// <summary>
		/// Получить список курсов валюты.
		/// </summary>
		/// <returns>Список курсов валюты.</returns>
		List<CurrencyRate> Get();

		/// <summary>
		/// Сохранить курс валюты.
		/// </summary>
		/// <param name="CurrencyRate">Сохраняемый курс валюты.</param>
		/// <returns>Сохраненный курс валюты с заполненным идентификатором</returns>
		Guid Save(CurrencyRateBase currencyRate);

		/// <summary>
		/// Удалить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор курса валюты.</param>
		void Delete(Guid id);
	}
}
