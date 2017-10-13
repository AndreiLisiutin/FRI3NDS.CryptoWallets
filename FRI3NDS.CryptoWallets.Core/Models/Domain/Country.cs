using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Страна.
	/// </summary>
	public class CountryBase
	{
		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public Guid CountryId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}

	/// <summary>
	/// Страна.
	/// </summary>
	public class Country: CountryBase
	{
	}
}
