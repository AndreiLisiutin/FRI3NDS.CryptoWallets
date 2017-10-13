using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Город.
	/// </summary>
	public class CityBase
	{
		/// <summary>
		/// Идентификатор города.
		/// </summary>
		public Guid CityId { get; set; }

		/// <summary>
		/// Идентификатор региона.
		/// </summary>
		/// <see cref="Region"/>
		public Guid RegionId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}

	/// <summary>
	/// Город.
	/// </summary>
	public class City : CityBase
	{
	}
}
