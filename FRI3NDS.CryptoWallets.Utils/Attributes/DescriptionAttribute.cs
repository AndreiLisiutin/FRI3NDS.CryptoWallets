using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Utils.Attributes
{
	/// <summary>
	/// Строковое описание чего-нибудь.
	/// </summary>
	public class DescriptionAttribute : Attribute
	{
		/// <summary>
		/// Конструктор строкового описания чего-нибудь.
		/// </summary>
		/// <param name="description"></param>
		public DescriptionAttribute(string description)
		{
			this.Description = description;
		}

		/// <summary>
		/// Строковое описание.
		/// </summary>
		public string Description { get; set; }
	}
}
