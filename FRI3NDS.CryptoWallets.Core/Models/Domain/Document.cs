using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Документ (список вложений).
	/// </summary>
	public class DocumentBase
	{
		/// <summary>
		/// Идентификатор документа.
		/// </summary>
		public Guid DocumentId { get; set; }

		/// <summary>
		/// Идентификатор пользователя. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
		/// </summary>
		/// <see cref="User"/>
		public Guid? UserId { get; set; }
	}

	/// <summary>
	/// Документ (список вложений).
	/// </summary>
	public class Document: DocumentBase
	{
	}
}
