using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер типов оповещений об изменении курса по частоте.
	/// </summary>
	[Route("api/AlertFrequency")]
	public class AlertFrequencyController : ControllerBase
	{
		/// <summary>
		/// Сервис типов оповещений об изменении курса по частоте.
		/// </summary>
		protected IAlertFrequencyService AlertFrequencyService { get; private set; }

		/// <summary>
		/// Контроллер типов оповещений об изменении курса по частоте.
		/// </summary>
		/// <param name="alertFrequencyService">Сервис типов оповещений об изменении курса по частоте.</param>
		public AlertFrequencyController(IAlertFrequencyService alertFrequencyService)
		{
			this.AlertFrequencyService = alertFrequencyService;
		}

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns>Список типов частоты оповещений.</returns>
		[HttpGet]
		public List<AlertFrequency> Get()
		{
			return AlertFrequencyService.Get();
		}

		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор типа частоты оповещений.</param>
		/// <returns>Тип частоты оповещений.</returns>
		[HttpGet("{id}")]
		public AlertFrequency Get(int id)
		{
			return AlertFrequencyService.GetById(id);
		}
	}
}
