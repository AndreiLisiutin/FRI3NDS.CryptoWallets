using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Migrator.Migrator
{
	/// <summary>
	/// Мигратор.
	/// </summary>
	public interface IMigrator
	{
		/// <summary>
		/// Мигрировать.
		/// </summary>
		void Migrate();
	}
}
