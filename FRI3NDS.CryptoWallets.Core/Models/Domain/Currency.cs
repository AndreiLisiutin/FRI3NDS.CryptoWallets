using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Валюта.
	/// </summary>
	public class CurrencyBase
	{
		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		public Guid CurrencyId { get; set; }

		/// <summary>
		/// Название (Например, "Доллар").
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Символ (в юникоде).
		/// </summary>
		public string Symbol { get; set; }

		/// <summary>
		/// Короткое название (Например, "USD").
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Идентификатор типа валют (Фиатная/Крипто).
		/// </summary>
		/// <see cref="CurrencyType"/>
		public int CurrencyTypeId { get; set; }

		/// <summary>
		/// Актуальный на данный момент курс в долларах. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
		/// </summary>
		public decimal ActualRateToDollar { get; set; }

		/// <summary>
		/// Дата последнего обновления курса. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
		/// </summary>
		public DateTime LastUpdatedOn { get; set; }
	}

	/// <summary>
	/// Валюта.
	/// </summary>
	public class Currency: CurrencyBase
	{
	}
}
