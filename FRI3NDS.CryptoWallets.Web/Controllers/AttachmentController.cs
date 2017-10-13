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
	public class AttachmentController : Controller
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

		[HttpGet]
		public List<Attachment> Get()
		{
			return AttachmentService.Get();
		}
		
		[HttpGet("{id}")]
		public Attachment Get(Guid id)
		{
			return AttachmentService.GetById(id);
		}
		
		[HttpPost]
		public Guid Post([FromBody]AttachmentBase value)
		{
			return AttachmentService.Save(value);
		}
		
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			AttachmentService.Delete(id);
		}
	}
}
