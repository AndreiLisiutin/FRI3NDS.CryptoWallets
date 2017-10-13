using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер стран.
	/// </summary>
	[Route("api/Country")]
	public class CountryController: ControllerBase
	{
		/// <summary>
		/// Сервис стран.
		/// </summary>
		protected ICountryService CountryService { get; private set; }

		/// <summary>
		/// Контроллер валют.
		/// </summary>
		/// <param name="countryService">Сервис валют.</param>
		public CountryController(ICountryService countryService)
		{
			this.CountryService = countryService;
		}

		/// <summary>
		/// Получить страну по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор страны.</param>
		/// <returns>Страна, найденная по ее идентификатору.</returns>
		[HttpGet("{id}")]
		public Country GetById(Guid id)
		{
			return CountryService.GetById(id);
		}

		/// <summary>
		/// Получить список стран.
		/// </summary>
		/// <returns>Список стран.</returns>
		[HttpGet]
		public List<Country> Get()
		{
			return CountryService.Get();
		}
	}
}
