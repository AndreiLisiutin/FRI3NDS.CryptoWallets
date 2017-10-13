using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Тип сертификата.
	/// </summary>
	public class CertificateType
	{
		/// <summary>
		/// Идентификатор типа сертификата.
		/// </summary>
		public int CertificateTypeId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }
	}
}
