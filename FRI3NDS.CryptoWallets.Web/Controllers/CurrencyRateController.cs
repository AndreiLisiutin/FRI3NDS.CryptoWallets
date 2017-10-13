using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер курсов валюты.
	/// </summary>
	[Route("api/CurrencyRate")]
	public class CurrencyRateController: ControllerBase, ICurrencyRateService
	{
		/// <summary>
		/// Сервис курсов валюты.
		/// </summary>
		protected ICurrencyRateService CurrencyRateService { get; private set; }

		/// <summary>
		/// Контроллер курсов валюты.
		/// </summary>
		/// <param name="currencyRateService">Сервис курсов валюты.</param>
		public CurrencyRateController(ICurrencyRateService currencyRateService)
		{
			this.CurrencyRateService = currencyRateService;
		}

		/// <summary>
		/// Получить курс валюты по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Курс валюты, найденный по идентификатору.</returns>
		public CurrencyRate GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
			{
				uow.CurrencyRateRepository.Delete(id);
			}
		}
	}
}
