using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Курс валюты.
	/// </summary>
	public class CurrencyRateBase
	{
		/// <summary>
		/// Идентификатор курса валюты.
		/// </summary>
		public Guid CurrencyRateId { get; set; }

		/// <summary>
		/// Дата и время, на которую этот курс был актуальным.
		/// </summary>
		public DateTime ActualOn { get; set; }

		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		public Guid CurrencyId { get; set; }

		/// <summary>
		/// Курс валюты к доллару.
		/// </summary>
		public decimal RateToDollar { get; set; }
	}

	/// <summary>
	/// Курс валюты.
	/// </summary>
	public class CurrencyRate: CurrencyRateBase
	{
	}
}
