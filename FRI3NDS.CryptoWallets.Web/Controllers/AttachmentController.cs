using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер вложений в документ.
	/// </summary>
	[Route("api/Attachment")]
	public class AttachmentController : ControllerBase
	{
		/// <summary>
		/// Сервис вложений в документ.
		/// </summary>
		protected IAttachmentService AttachmentService { get; private set; }

		/// <summary>
		/// Контроллер вложений в документ.
		/// </summary>
		/// <param name="attachmentService">Сервис вложений в документ.</param>
		public AttachmentController(IAttachmentService attachmentService)
		{
			this.AttachmentService = attachmentService;
		}

		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		[HttpGet("{id}")]
		public Attachment Get(Guid id)
		{
			return AttachmentService.GetById(id);
		}

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <returns>Список вложений в документ.</returns>
		[HttpGet]
		public List<Attachment> Get()
		{
			return AttachmentService.Get();
		}
		
		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Post([FromBody]AttachmentBase attachment)
		{
			return AttachmentService.Save(attachment);
		}

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			AttachmentService.Delete(id);
		}
	}
}
