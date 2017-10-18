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
	/// Репозиторий типов сертификатов.
	/// </summary>
	public class CertificateTypeRepository : RepositoryBase<CertificateType>, ICertificateTypeRepository
	{
		public CertificateTypeRepository(DataContext dataContext)
			: base(dataContext)
		{
		}


		/// <summary>
		/// Получить тип сертификата по идентификатору типа.
		/// </summary>
		/// <param name="id">Идентификатор типа.</param>
		/// <returns>Тип сертификата, найденный по его идентификатору.</returns>
		public CertificateType GetById(int id)
		{
			return Get(certificateTypeId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список типов сертификатов.
		/// </summary>
		/// <param name="certificateTypeId">Идентификатор типа сертификата.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список типов сертификатов.</returns>
		public List<CertificateType> Get(
			int? certificateTypeId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_certificate_type_id", certificateTypeId, DbType.Int32);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<CertificateType> list = CallProcedure<CertificateType>("CertificateState$Query", @params);
			return list;
		}
	}
}
