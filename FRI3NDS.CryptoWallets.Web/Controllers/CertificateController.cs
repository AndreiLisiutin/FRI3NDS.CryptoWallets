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
	public class CertificateController: ControllerBase, ICertificateService
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
		public Certificate GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список сертификатов 1С пользователя.
		/// </summary>
		/// <returns>Список сертификатов 1С пользователя.</returns>
		public List<Certificate> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить сертификат 1С пользователя.
		/// </summary>
		/// <param name="certificate">Сохраняемый сертификат 1С пользователя.</param>
		/// <returns>Сохраненный сертификат 1С пользователя с заполненным идентификатором</returns>
		public Guid Save(CertificateBase certificate)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateRepository.Save(certificate);
			}
		}

		/// <summary>
		/// Удалить сертификат 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор сертификата 1С пользователя.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.CertificateRepository.Delete(id);
			}
		}
	}
}
