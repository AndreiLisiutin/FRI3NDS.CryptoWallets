using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер городов.
	/// </summary>
	[Route("api/City")]
	public class CityController: ControllerBase, ICityService
	{
		/// <summary>
		/// Сервис городов.
		/// </summary>
		protected ICityService CityService { get; private set; }

		/// <summary>
		/// Контроллер городов.
		/// </summary>
		/// <param name="cityService">Сервис городов.</param>
		public CityController(ICityService cityService)
		{
			this.CityService = cityService;
		}

		/// <summary>
		/// Получить город по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор города.</param>
		/// <returns>Город, найденный по его идентификатору.</returns>
		public City GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CityRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список городов.
		/// </summary>
		/// <returns>Список городов.</returns>
		public List<City> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CityRepository.Get();
			}
		}
	}
}
