using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// ЧаВо.
	/// </summary>
	public class FaqBase
	{
		/// <summary>
		/// Идентификатор ЧаВо.
		/// </summary>
		public Guid FaqId { get; set; }

		/// <summary>
		/// Вопрос.
		/// </summary>
		public string Question { get; set; }

		/// <summary>
		/// Ответ.
		/// </summary>
		public string Answer { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn { get; set; }
	}

	/// <summary>
	/// ЧаВо.
	/// </summary>
	public class Faq: FaqBase
	{
	}
}
