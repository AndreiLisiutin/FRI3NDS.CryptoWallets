using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Вопрос пользователя к админам.
	/// </summary>
	public class QuestionBase
	{
		/// <summary>
		/// Идентификатор вопроса.
		/// </summary>
		public Guid QuestionId { get; set; }

		/// <summary>
		/// Вопрос.
		/// </summary>
		public string Question { get; set; }

		/// <summary>
		/// Идентификатор пользователя, задавшего вопрос.
		/// </summary>
		/// <see cref="User"/>
		public Guid? UserId { get; set; }

		/// <summary>
		/// Email пользователя, куда отправим ответ. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Дата создания вопроса.
		/// </summary>
		public DateTime CreatedOn { get; set; }
	}

	/// <summary>
	/// Вопрос пользователя к админам.
	/// </summary>
	public class Question: QuestionBase
	{
	}
}
