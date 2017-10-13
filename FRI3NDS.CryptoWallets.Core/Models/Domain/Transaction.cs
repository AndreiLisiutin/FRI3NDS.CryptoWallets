using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Транзакция (базовая, обмен, пересылка и т.п.). 
	/// Состоит из нескольких <see cref="TransactonAction"/>.
	/// </summary>
	public class TransactionBase
	{
		/// <summary>
		/// Идентификатор транзакции.
		/// </summary>
		public Guid TransactionId { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Дата подтверждения.
		/// </summary>
		public DateTime? ConfirmedOn { get; set; }

		/// <summary>
		/// Подтверждена ли транзакция.
		/// </summary>
		public bool IsConfirmed { get; set; }
	}

	/// <summary>
	/// Транзакция (базовая, обмен, пересылка и т.п.).
	/// </summary>
	public class Transaction: TransactionBase
	{
	}
}
