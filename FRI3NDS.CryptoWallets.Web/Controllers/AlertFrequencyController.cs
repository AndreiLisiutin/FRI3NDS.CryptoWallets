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
	/// Контроллер типов оповещений об изменении курса по частоте.
	/// </summary>
	[Route("api/AlertFrequency")]
	public class AlertFrequencyController : Controller
	{
		protected IAlertFrequencyService AlertFrequencyService { get; private set; }

		public AlertFrequencyController(IAlertFrequencyService alertFrequencyService)
		{
			this.AlertFrequencyService = alertFrequencyService;
		}

		[HttpGet]
		public List<AlertFrequency> Get()
		{
			return AlertFrequencyService.Get();
		}
		
		[HttpGet("{id}")]
		public AlertFrequency Get(int id)
		{
			return AlertFrequencyService.GetById(id);
		}
	}
}
