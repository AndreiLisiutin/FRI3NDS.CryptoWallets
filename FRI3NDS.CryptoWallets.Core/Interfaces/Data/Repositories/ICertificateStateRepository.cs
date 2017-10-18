using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий статусов сертификатов.
	/// </summary>
	public interface ICertificateStateRepository : IRepositoryBase<CertificateState>
	{
		/// <summary>
		/// Получить статус сертификата по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор статуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		CertificateState GetById(int id);

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <param name="certificateStateId">Идентификатор статуса сертификата.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список статусов сертификатов.</returns>
		List<CertificateState> Get(
			int? certificateStateId = null,
			int? pageSize = null,
			int? pageNumber = null);
	}
}
