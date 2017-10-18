using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий сертификатов 1С пользователя.
	/// </summary>
	public class CertificateRepository : RepositoryBase<CertificateBase>, ICertificateRepository
	{
		public CertificateRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить сертификата 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Сертификат 1С пользователя, найденный по идентификатору.</returns>
		public Certificate GetById(Guid id)
		{
			return Get(certificateId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список сертификатов 1С пользователя.
		/// </summary>
		/// <param name="certificateId">Идентификатор сертификата.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список сертификатов 1С пользователя.</returns>
		public List<Certificate> Get(
			Guid? certificateId = null,
			Guid? userId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_certificate_id", certificateId, DbType.Guid);
			@params.Add("_user_id", userId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Certificate> list = CallProcedure<Certificate>("Certificate$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить сертификат 1С пользователя.
		/// </summary>
		/// <param name="certificate">Сохраняемый сертификат 1С пользователя.</param>
		/// <returns>Сохраненный сертификат 1С пользователя с заполненным идентификатором</returns>
		public Guid Save(CertificateBase certificate)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_certificate_id", certificate.CertificateId, DbType.Guid);
			@params.Add("_user_id", certificate.UserId, DbType.Guid);
			@params.Add("_certificate_type_id", certificate.CertificateTypeId, DbType.Int32);
			@params.Add("_certificate_state_id", certificate.CertificateStateId, DbType.Int32);
			@params.Add("_document_id", certificate.DocumentId, DbType.Guid);
			@params.Add("_created_on", certificate.CreatedOn, DbType.Date);
			@params.Add("_requested_on", certificate.RequestedOn, DbType.Date);
			@params.Add("_approved_on", certificate.ApprovedOn, DbType.Date);
			@params.Add("_certificate_request_id", certificate.CertificateRequestId, DbType.Guid);
			@params.Add("_certificate_number", certificate.CertificateNumber, DbType.String);
			@params.Add("_certificate_date", certificate.CertificateDate, DbType.Date);
			@params.Add("_owner_email", certificate.OwnerEmail, DbType.String);
			@params.Add("_owner_first_name", certificate.OwnerFirstName, DbType.String);
			@params.Add("_owner_last_name", certificate.OwnerLastName, DbType.String);
			@params.Add("_owner_patronymic", certificate.OwnerPatronymic, DbType.String);

			Guid certificateId = CallProcedure<Guid>("Certificate$Save", @params).FirstOrDefault();

			certificate.CertificateId = certificateId;
			return certificateId;
		}

		/// <summary>
		/// Удалить сертификат 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор сертификата 1С пользователя.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Certificate$Delete", @params);
		}
	}
}
