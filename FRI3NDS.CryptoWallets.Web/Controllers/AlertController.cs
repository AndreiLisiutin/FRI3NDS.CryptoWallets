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
	public class AlertController : ControllerBase
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

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <returns>Список оповещений.</returns>
		[HttpGet]
		public List<Alert> Get()
		{
			return AlertService.Get();
		}

		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповещение.</returns>
		[HttpGet("{id}")]
		public Alert Get(Guid id)
		{
			return AlertService.GetById(id);
		}

		/// <summary>
		/// Сохранить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Post([FromBody]AlertBase alert)
		{
			return AlertService.Save(alert);
		}

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			AlertService.Delete(id);
		}
	}
}
