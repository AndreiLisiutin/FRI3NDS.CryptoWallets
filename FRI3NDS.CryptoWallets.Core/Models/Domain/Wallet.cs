using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Кошелек.
	/// </summary>
	public class WalletBase
	{
		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		public Guid WalletId { get; set; }

		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		/// <see cref="Currency"/>
		public Guid CurrencyId { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		/// <see cref="User"/>
		public Guid UserId { get; set; }

		/// <summary>
		/// Текущий баланс.
		/// </summary>
		public decimal Balance { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Дата последнего обновления баланса. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
		/// </summary>
		public DateTime LastUpdatedOn { get; set; }

		/// <summary>
		/// Адрес (для криптовалютных кошельков).
		/// </summary>
		public string Address { get; set; }
	}

	/// <summary>
	/// Кошелек.
	/// </summary>
	public class Wallet: WalletBase
	{
	}
}
