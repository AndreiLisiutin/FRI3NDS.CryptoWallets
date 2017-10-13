using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий статусов сертификатов.
	/// </summary>
	public interface ICertificateTypeRepository : IRepositoryBase<CertificateType>
	{
		/// <summary>
		/// Получить статус сертификата по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор статуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		CertificateType GetById(int id);

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <returns>Список статусов сертификатов.</returns>
		List<CertificateType> Get();
	}
}
