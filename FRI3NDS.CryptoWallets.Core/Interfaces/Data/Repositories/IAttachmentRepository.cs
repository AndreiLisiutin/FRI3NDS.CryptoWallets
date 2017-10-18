using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий вложений в документ (файлов).
	/// </summary>
	public interface IAttachmentRepository : IRepositoryBase<Attachment>
	{
		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		Attachment GetById(Guid id);

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <param name="attachmentId">Идентификатор вложения.</param>
		/// <param name="documentId">Идентификатор документа.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список вложений в документ.</returns>
		List<Attachment> Get(
			Guid? attachmentId = null,
			Guid? documentId = null,
			int? pageSize = null,
			int? pageNumber = null);

		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		Guid Save(AttachmentBase attachment);

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		void Delete(Guid id);
	}
}
