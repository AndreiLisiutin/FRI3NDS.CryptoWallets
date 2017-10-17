using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий курсов валюты.
	/// </summary>
	public class CurrencyRateService : ServiceBase, ICurrencyRateService
	{
		public CurrencyRateService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Курс валюты, найденный по идентификатору.</returns>
		public CurrencyRate GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRateRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список курсов валюты.
		/// </summary>
		/// <returns>Список курсов валюты.</returns>
		public List<CurrencyRate> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRateRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить курс валюты.
		/// </summary>
		/// <param name="CurrencyRate">Сохраняемый курс валюты.</param>
		/// <returns>Сохраненный курс валюты с заполненным идентификатором</returns>
		public Guid Save(CurrencyRateBase currencyRate)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.CurrencyRateRepository.Save(currencyRate);
			}
		}

		/// <summary>
		/// Удалить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор курса валюты.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.CurrencyRateRepository.Delete(id);
			}
		}
	}
}
