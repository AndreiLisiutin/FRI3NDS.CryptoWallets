using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Статус сертификата (запроса на него).
	/// </summary>
	public class CertificateState
	{
		/// <summary>
		/// Идентификатор статуса сертификата.
		/// </summary>
		public int CertificateStateId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}
}
