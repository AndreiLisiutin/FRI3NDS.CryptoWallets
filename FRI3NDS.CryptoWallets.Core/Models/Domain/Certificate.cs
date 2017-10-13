using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Сертификат 1С пользователя.
	/// </summary>
	public class CertificateBase
	{
		/// <summary>
		/// Идентификатор сертификата.
		/// </summary>
		public Guid CertificateId { get; set; }

		/// <summary>
		/// Идентификатор пользователя-владельца.
		/// </summary>
		/// <see cref="User"/>
		public Guid UserId { get; set; }

		/// <summary>
		/// Тип сертификата (Юрлицо, физлицо и т.п.)
		/// </summary>
		/// <see cref="CertificateType"/>
		public int CertificateTypeId { get; set; }

		/// <summary>
		/// Идентификатор документа с файлами персональных документов пользователя.
		/// </summary>
		/// <see cref="Document"/>
		public Guid DocumentId { get; set; }

		/// <summary>
		/// Дата запроса сертификата в 1С.
		/// </summary>
		public DateTime? RequestedOn { get; set; }

		/// <summary>
		/// Дата создания сертификата в нашей системе.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Дата подтверждения сертификата.
		/// </summary>
		public DateTime? ApprovedOn { get; set; }

		/// <summary>
		/// Идентификатор запроса сертификата в 1С.
		/// </summary>
		public Guid? CertificateRequestId { get; set; }

		/// <summary>
		/// Номер сертификата (данные из сертификата).
		/// </summary>
		public string CertificateNumber { get; set; }

		/// <summary>
		/// Дата сертификата (данные из сертификата).
		/// </summary>
		public DateTime CertificateDate { get; set; }

		/// <summary>
		/// Email владельца (данные из сертификата).
		/// </summary>
		public string OwnerEmail { get; set; }

		/// <summary>
		/// Имя владельца (данные из сертификата).
		/// </summary>
		public string OwnerFirstName { get; set; }

		/// <summary>
		/// Фамилия владельца (данные из сертификата).
		/// </summary>
		public string OwnerLastName { get; set; }

		/// <summary>
		/// Отчество владельца (данные из сертификата).
		/// </summary>
		public string OwnerPatronymic { get; set; }

		/// <summary>
		/// Статус запроса на сертификат.
		/// </summary>
		/// <see cref="CertificateState"/>
		public int CertificateStateId { get; set; }
	}

	/// <summary>
	/// Сертификат 1С пользователя.
	/// </summary>
	public class Certificate: CertificateBase
	{

	}
}
