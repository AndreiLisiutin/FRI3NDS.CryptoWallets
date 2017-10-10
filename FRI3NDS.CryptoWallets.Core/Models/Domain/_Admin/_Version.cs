using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain._Admin
{
	/// <summary>
	/// Версия БД.
	/// </summary>
	public class _Version : _VersionBase
	{
		public string ScriptBody { get; set; }
	}

	/// <summary>
	/// Версия БД.
	/// </summary>
	public class _VersionBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ScriptHash { get; set; }
		public string Description { get; set; }
		public DateTime? AppliedOn { get; set; }
	}
}
