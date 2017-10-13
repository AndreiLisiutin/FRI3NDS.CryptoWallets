using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Тип валюты.
	/// </summary>
	public class CurrencyType
	{
		/// <summary>
		/// Идентификатор типа валюты.
		/// </summary>
		public int CurrencyTypeId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}
}
