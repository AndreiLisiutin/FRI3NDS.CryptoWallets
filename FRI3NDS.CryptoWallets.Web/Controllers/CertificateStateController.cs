using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер статусов сертификатов.
	/// </summary>
	[Route("api/CertificateState")]
	public class CertificateStateController: ControllerBase
	{
		/// <summary>
		/// Сервис статусов сертификатов.
		/// </summary>
		protected ICertificateStateService CertificateStateService { get; private set; }

		/// <summary>
		/// Контроллер статусов сертификатов.
		/// </summary>
		/// <param name="cetificateStateService">Сервис статусов сертификатов.</param>
		public CertificateStateController(ICertificateStateService cetificateStateService)
		{
			this.CertificateStateService = cetificateStateService;
		}

		/// <summary>
		/// Получить статус сертификата по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор статуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		[HttpGet("{id}")]
		public CertificateState GetById(int id)
		{
			return CertificateStateService.GetById(id);
		}

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <returns>Список статусов сертификатов.</returns>
		[HttpGet]
		public List<CertificateState> Get()
		{
			return CertificateStateService.Get();
		}
	}
}
