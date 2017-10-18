using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий статусов сертификатов.
	/// </summary>
	public class CertificateStateRepository : RepositoryBase<CertificateState>, ICertificateStateRepository
	{
		public CertificateStateRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить статус сертификата по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор статуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		public CertificateState GetById(int id)
		{
			return Get(certificateStateId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <param name="certificateStateId">Идентификатор статуса сертификата.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список статусов сертификатов.</returns>
		public List<CertificateState> Get(
			int? certificateStateId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_certificate_state_id", certificateStateId, DbType.Int32);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<CertificateState> list = CallProcedure<CertificateState>("CertificateState$Query", @params);
			return list;
		}
	}
}
