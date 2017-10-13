using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер валют.
	/// </summary
	[Route("api/Currency")]
	public class CurrencyController: ControllerBase, ICurrencyService
	{
		/// <summary>
		/// Сервис валют.
		/// </summary>
		protected ICurrencyService CurrencyService { get; private set; }

		/// <summary>
		/// Контроллер валют.
		/// </summary>
		/// <param name="currencyService">Сервис валют.</param>
		public CurrencyController(ICurrencyService currencyService)
		{
			this.CurrencyService = currencyService;
		}

		/// <summary>
		/// Получить валюту по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Валюта, найденный по идентификатору.</returns>
		public Currency GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
			{
				uow.CurrencyRepository.Delete(id);
			}
		}
	}
}
