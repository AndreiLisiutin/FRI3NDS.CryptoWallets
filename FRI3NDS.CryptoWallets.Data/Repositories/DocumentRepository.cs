using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий документов.
	/// </summary>
	public class DocumentRepository : RepositoryBase<DocumentBase>, IDocumentRepository
	{
		private static FakeStore<DocumentBase, Document> store = new FakeStore<DocumentBase, Document>();

		public DocumentRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Документ, найденный по идентификатору.</returns>
		public Document GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список документов.
		/// </summary>
		/// <returns>Список документов.</returns>
		public List<Document> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="document">Сохраняемый документ.</param>
		/// <returns>Сохраненный документ с заполненным идентификатором</returns>
		public Guid Save(DocumentBase document)
		{
			return store.Save(document).DocumentId;
		}

		/// <summary>
		/// Удалить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор документа.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
