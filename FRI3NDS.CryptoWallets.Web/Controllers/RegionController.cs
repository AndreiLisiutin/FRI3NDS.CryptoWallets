using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер регионов.
	/// </summary>
	[Route("api/Region")]
	public class RegionController: ControllerBase
	{
		/// <summary>
		/// Сервис регионов.
		/// </summary>
		protected IRegionService RegionService { get; private set; }

		/// <summary>
		/// Контроллер регионов.
		/// </summary>
		/// <param name="regionService">Сервис регионов.</param>
		public RegionController(IRegionService regionService)
		{
			this.RegionService = regionService;
		}

		/// <summary>
		/// Получить регион по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор региона.</param>
		/// <returns>Регион, найденный по его идентификатору.</returns>
		[HttpGet("{id}")]
		public Region GetById(Guid id)
		{
			return RegionService.GetById(id);
		}

		/// <summary>
		/// Получить список регионов.
		/// </summary>
		/// <returns>Список регионов.</returns>
		[HttpGet]
		public List<Region> Get()
		{
			return RegionService.Get();
		}
	}
}
