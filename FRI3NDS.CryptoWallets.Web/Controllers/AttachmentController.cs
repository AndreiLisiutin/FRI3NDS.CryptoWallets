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
	/// Контроллер вложений в документ.
	/// </summary>
	[Route("api/Attachment")]
	public class AttachmentController : Controller
	{
		protected IAttachmentService AttachmentService { get; private set; }

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
