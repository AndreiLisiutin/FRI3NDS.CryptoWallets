using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер документов.
	/// </summary>
	[Route("api/Document")]
	public class DocumentController: ControllerBase
	{
		/// <summary>
		/// Сервис документов.
		/// </summary>
		protected IDocumentService DocumentService { get; private set; }

		/// <summary>
		/// Контроллер документов.
		/// </summary>
		/// <param name="documentService">Сервис документов.</param>
		public DocumentController(IDocumentService documentService)
		{
			this.DocumentService = documentService;
		}

		/// <summary>
		/// Получить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Документ, найденный по идентификатору.</returns>
		[HttpGet("{id}")]
		public Document GetById(Guid id)
		{
			return DocumentService.GetById(id);
		}

		/// <summary>
		/// Получить список документов.
		/// </summary>
		/// <returns>Список документов.</returns>
		[HttpGet]
		public List<Document> Get()
		{
			return DocumentService.Get();
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="document">Сохраняемый документ.</param>
		/// <returns>Сохраненный документ с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]DocumentBase document)
		{
			return DocumentService.Save(document);
		}

		/// <summary>
		/// Удалить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор документа.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			DocumentService.Delete(id);
		}
	}
}
