using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер сертификатов 1С пользователя.
	/// </summary>
	[Route("api/Certificate")]
	public class CertificateController: ControllerBase
	{
		/// <summary>
		/// Сервис сертификатов 1С пользователя.
		/// </summary>
		protected ICertificateService CertificateService { get; private set; }

		/// <summary>
		/// Контроллер сертификатов 1С пользователя.
		/// </summary>
		/// <param name="certificateService">Сервис сертификатов 1С пользователя.</param>
		public CertificateController(ICertificateService certificateService)
		{
			this.CertificateService = certificateService;
		}

		/// <summary>
		/// Получить сертификата 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Сертификат 1С пользователя, найденный по идентификатору.</returns>
		[HttpGet("{id}")]
		public Certificate GetById(Guid id)
		{
			return CertificateService.GetById(id);
		}

		/// <summary>
		/// Получить список сертификатов 1С пользователя.
		/// </summary>
		/// <returns>Список сертификатов 1С пользователя.</returns>
		[HttpGet]
		public List<Certificate> Get()
		{
			return CertificateService.Get();
		}

		/// <summary>
		/// Сохранить сертификат 1С пользователя.
		/// </summary>
		/// <param name="certificate">Сохраняемый сертификат 1С пользователя.</param>
		/// <returns>Сохраненный сертификат 1С пользователя с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]CertificateBase certificate)
		{
			return CertificateService.Save(certificate);
		}

		/// <summary>
		/// Удалить сертификат 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор сертификата 1С пользователя.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			CertificateService.Delete(id);
		}
	}
}
