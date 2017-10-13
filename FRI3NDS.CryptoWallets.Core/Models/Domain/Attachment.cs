using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Вложение в документ (файл).
	/// </summary>
	public class AttachmentBase
	{
		/// <summary>
		/// Идентификатор вложения.
		/// </summary>
		public Guid AttachmentId { get; set; }

		/// <summary>
		/// Идентификатор документа.
		/// </summary>
		/// <see cref="Document"/>
		public Guid DocumentId { get; set; }

		/// <summary>
		/// Название файла.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Расширение файла.
		/// </summary>
		public string FileExtension { get; set; }

		/// <summary>
		/// Путь к файлу в файловой системе.
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// Размер файла в байтах.
		/// </summary>
		public int FileSize { get; set; }

		/// <summary>
		/// Майм-тип файла.
		/// </summary>
		public string FileMimeType { get; set; }

		/// <summary>
		/// Дата создания вложения.
		/// </summary>
		public DateTime? CreatedOn { get; set; }
	}

	/// <summary>
	/// Вложение в документ (файл).
	/// </summary>
	public class Attachment : AttachmentBase
	{
	}
}
