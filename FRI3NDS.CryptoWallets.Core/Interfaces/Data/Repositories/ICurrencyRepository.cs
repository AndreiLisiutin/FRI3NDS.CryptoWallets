using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий валют.
	/// </summary>
	public interface ICurrencyRepository : IRepositoryBase<CurrencyBase>
	{
		/// <summary>
		/// Получить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Валюта, найденный по идентификатору.</returns>
		Currency GetById(Guid id);

		/// <summary>
		/// Получить список валют.
		/// </summary>
		/// <returns>Список валют.</returns>
		List<Currency> Get();

		/// <summary>
		/// Сохранить валюту.
		/// </summary>
		/// <param name="Currency">Сохраняемая валюта.</param>
		/// <returns>Сохраненная валюта с заполненным идентификатором</returns>
		Guid Save(CurrencyBase currency);

		/// <summary>
		/// Удалить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор валюты.</param>
		void Delete(Guid id);
	}
}
