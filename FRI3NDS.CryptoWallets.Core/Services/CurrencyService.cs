using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий валют.
	/// </summary>
	public class CurrencyService : ServiceBase, ICurrencyService
	{
		public CurrencyService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Валюта, найденный по идентификатору.</returns>
		public Currency GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список валют.
		/// </summary>
		/// <returns>Список валют.</returns>
		public List<Currency> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить валюту.
		/// </summary>
		/// <param name="Currency">Сохраняемая валюта.</param>
		/// <returns>Сохраненная валюта с заполненным идентификатором</returns>
		public Guid Save(CurrencyBase currency)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRepository.Save(currency);
			}
		}

		/// <summary>
		/// Удалить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор валюты.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.CurrencyRepository.Delete(id);
			}
		}
	}
}
