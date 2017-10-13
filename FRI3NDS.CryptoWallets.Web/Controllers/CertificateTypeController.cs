using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер типов сертификатов.
	/// </summary>
	[Route("api/CertificateType")]
	public class CertificateTypeController: ControllerBase
	{
		/// <summary>
		/// Сервис типов сертификатов.
		/// </summary>
		protected ICertificateTypeService CertificateTypeService { get; private set; }

		/// <summary>
		/// Контроллер типов сертификатов.
		/// </summary>
		/// <param name="certificateTypeService">Сервис типов сертификатов.</param>
		public CertificateTypeController(ICertificateTypeService certificateTypeService)
		{
			this.CertificateTypeService = certificateTypeService;
		}
		
		/// <summary>
		/// Получить тип сертификата по идентификатору типа.
		/// </summary>
		/// <param name="id">Идентификатор типа.</param>
		/// <returns>Тип сертификата, найденный по его идентификатору.</returns>
		public CertificateType GetById(int id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateTypeRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список типов сертификатов.
		/// </summary>
		/// <returns>Список типов сертификатов.</returns>
		public List<CertificateType> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateTypeRepository.Get();
			}
		}
	}
}
