using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер типов валюты.
	/// </summary>
	[Route("api/CurrencyType")]
	public class CurrencyTypeController: ControllerBase
	{
		/// <summary>
		/// Сервис типов валюты.
		/// </summary>
		protected ICurrencyTypeService CurrencyTypeService { get; private set; }

		/// <summary>
		/// Контроллер типов валюты.
		/// </summary>
		/// <param name="currencyTypeService">Сервис типов валюты.</param>
		public CurrencyTypeController(ICurrencyTypeService currencyTypeService)
		{
			this.CurrencyTypeService = currencyTypeService;
		}

		/// <summary>
		/// Получить тип валюты по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор типа валюты.</param>
		/// <returns>Тип валюты, найденный по его идентификатору.</returns>
		[HttpGet("{id}")]
		public CurrencyType GetById(int id)
		{
			return CurrencyTypeService.GetById(id);
		}

		/// <summary>
		/// Получить список типов валют.
		/// </summary>
		/// <returns>Список типов валют.</returns>
		[HttpGet]
		public List<CurrencyType> Get()
		{
			return CurrencyTypeService.Get();
		}
	}
}
