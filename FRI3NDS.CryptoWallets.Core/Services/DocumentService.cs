using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий документов.
	/// </summary>
	public class DocumentService : ServiceBase, IDocumentService
	{
		public DocumentService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Документ, найденный по идентификатору.</returns>
		public Document GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.DocumentRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список документов.
		/// </summary>
		/// <returns>Список документов.</returns>
		public List<Document> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.DocumentRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="document">Сохраняемый документ.</param>
		/// <returns>Сохраненный документ с заполненным идентификатором</returns>
		public Guid Save(DocumentBase document)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.DocumentRepository.Save(document);
			}
		}

		/// <summary>
		/// Удалить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор документа.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.DocumentRepository.Delete(id);
			}
		}
	}
}
