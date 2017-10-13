using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FRI3NDS.CryptoWallets.Utils;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер оповещений об изменении курса.
	/// </summary>
	[Route("api/Alert")]
	public class AlertController : Controller
	{
		protected IAlertService AlertService { get; private set; }

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
