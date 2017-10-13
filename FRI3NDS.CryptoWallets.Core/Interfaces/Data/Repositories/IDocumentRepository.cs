using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий документов.
	/// </summary>
	public interface IDocumentRepository : IRepositoryBase<DocumentBase>
	{
		/// <summary>
		/// Получить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Документ, найденный по идентификатору.</returns>
		Document GetById(Guid id);

		/// <summary>
		/// Получить список документов.
		/// </summary>
		/// <returns>Список документов.</returns>
		List<Document> Get();

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="document">Сохраняемый документ.</param>
		/// <returns>Сохраненный документ с заполненным идентификатором</returns>
		Guid Save(DocumentBase document);

		/// <summary>
		/// Удалить документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор документа.</param>
		void Delete(Guid id);
	}
}
