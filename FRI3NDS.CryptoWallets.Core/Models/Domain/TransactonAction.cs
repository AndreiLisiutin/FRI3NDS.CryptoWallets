using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Элементарное действие транзакции.
	/// </summary>
	public class TransactonActionBase
	{
		/// <summary>
		/// Идентификатор элементарного действия транзакции.
		/// </summary>
		public Guid TransactonActionId { get; set; }

		/// <summary>
		/// Идентификатор транзакции.
		/// </summary>
		/// <see cref="Transaction"/>
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

		/// <summary>
		/// Количество денег транзакции.
		/// </summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		/// <see cref="Wallet"/>
		public Guid WalletId { get; set; }

		/// <summary>
		/// Сумма вознаграждения майнера (пока не понятно).
		/// </summary>
		public decimal MiningFee { get; set; }

		/// <summary>
		/// Подтверждено в блоке ID блока (пока не понятно). 
		/// </summary>
		public bool IsConfirmedInBlock { get; set; }

		/// <summary>
		/// Количество подтверждений операций (пока не понятно).
		/// </summary>
		public int ConfirmationsCount { get; set; }

		/// <summary>
		/// Идентификатор пользователя (лишнее поле, для возможной оптимизации).
		/// </summary>
		/// <see cref="User"/>
		public Guid UserId { get; set; }

		/// <summary>
		/// Идентификатор валюты (лишнее поле, для возможной оптимизации).
		/// </summary>
		/// <see cref="Currency"/>
		public Guid CurrencyId { get; set; }
	}

	/// <summary>
	/// Элементарное действие транзакции.
	/// </summary>
	public class TransactonAction: TransactonActionBase
	{
	}
}
