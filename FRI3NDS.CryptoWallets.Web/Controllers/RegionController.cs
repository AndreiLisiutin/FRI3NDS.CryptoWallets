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
	public class RegionController: ControllerBase, IRegionService
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
		public Region GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.RegionRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список регионов.
		/// </summary>
		/// <returns>Список регионов.</returns>
		public List<Region> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.RegionRepository.Get();
			}
		}
	}
}
