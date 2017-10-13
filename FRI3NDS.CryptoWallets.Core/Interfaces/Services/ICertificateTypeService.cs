using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий типов сертификатов.
	/// </summary>
	public interface ICertificateTypeService : IServiceBase
	{
		/// <summary>
		/// Получить тип сертификата по идентификатору типа.
		/// </summary>
		/// <param name="id">Идентификатор типа.</param>
		/// <returns>Тип сертификата, найденный по его идентификатору.</returns>
		CertificateType GetById(int id);

		/// <summary>
		/// Получить список типов сертификатов.
		/// </summary>
		/// <returns>Список типов сертификатов.</returns>
		List<CertificateType> Get();
	}
}
