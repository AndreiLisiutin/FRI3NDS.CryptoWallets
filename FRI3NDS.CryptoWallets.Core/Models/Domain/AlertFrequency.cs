using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Частота срабатывания оповещения.
	/// </summary>
	public class AlertFrequency
	{
		/// <summary>
		/// Идентификатор частоты срабатывания оповещения.
		/// </summary>
		public int AlertFrequencyId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}
}
