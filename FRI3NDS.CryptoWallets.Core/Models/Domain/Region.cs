using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Регион.
	/// </summary>
	public class RegionBase
	{
		/// <summary>
		/// Идентификатор региона.
		/// </summary>
		public Guid RegionId { get; set; }

		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		/// <see cref="Country"/>
		public Guid CountryId { get; set; }
		
		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}

	/// <summary>
	/// Регион.
	/// </summary>
	public class Region : RegionBase
	{
	}
}
