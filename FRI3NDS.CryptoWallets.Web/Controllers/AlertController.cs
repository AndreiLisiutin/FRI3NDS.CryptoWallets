using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер оповещений об изменении курса.
	/// </summary>
	[Route("api/Alert")]
	public class AlertController : Controller
	{
		/// <summary>
		/// Сервис оповещений об изменении курса.
		/// </summary>
		protected IAlertService AlertService { get; private set; }

		/// <summary>
		/// Контроллер оповещений об изменении курса.
		/// </summary>
		/// <param name="alertService">Сервис оповещений об изменении курса.</param>
		public AlertController(IAlertService alertService)
		{
			this.AlertService = alertService;
		}

		[HttpGet]
		public List<Alert> Get()
		{
			return AlertService.Get();
		}
		
		[HttpGet("{id}")]
		public Alert Get(Guid id)
		{
			return AlertService.GetById(id);
		}
		
		[HttpPost]
		public Guid Post([FromBody]AlertBase value)
		{
			return AlertService.Save(value);
		}
		
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			AlertService.Delete(id);
		}
	}
}
