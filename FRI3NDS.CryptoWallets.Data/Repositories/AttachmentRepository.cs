using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий вложений в документ.
	/// </summary>
	public class AttachmentRepository : RepositoryBase<AttachmentBase>, IAttachmentRepository
	{
		private static FakeStore<AttachmentBase, Attachment> store = new FakeStore<AttachmentBase, Attachment>();

		public AttachmentRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		public Attachment GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <param name="attachmentId">Идентификатор вложения.</param>
		/// <param name="documentId">Идентификатор документа.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список вложений в документ.</returns>
		public List<Attachment> Get(
			Guid? attachmentId = null,
			Guid? documentId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_attachment_id", attachmentId, DbType.Guid);
			@params.Add("_document_id", documentId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Attachment> list = CallProcedure<Attachment>("Attachment$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		public Guid Save(AttachmentBase attachment)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_attachment_id", attachment.AttachmentId, DbType.Guid);
			@params.Add("_document_id", attachment.DocumentId, DbType.Guid);
			@params.Add("_file_name", attachment.FileName, DbType.String);
			@params.Add("_file_extension", attachment.FileExtension, DbType.String);
			@params.Add("_file_path", attachment.FilePath, DbType.String);
			@params.Add("_file_size", attachment.FileSize, DbType.Int32);
			@params.Add("_file_mime_type", attachment.FileMimeType, DbType.String);
			@params.Add("_created_on", attachment.CreatedOn, DbType.Date);

			Guid attachmentId = CallProcedure<Guid>("Attachment$Save", @params)
				.FirstOrDefault();

			attachment.AttachmentId = attachmentId;
			return attachmentId;
		}

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Attachment$Delete", @params);
		}
	}
}
