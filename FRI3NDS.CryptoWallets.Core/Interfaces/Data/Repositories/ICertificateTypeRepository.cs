﻿using FRI3NDS.CryptoWallets.Core.Models.Domain;
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
		/// Получить список типов сертификатов.
		/// </summary>
		/// <param name="certificateTypeId">Идентификатор типа сертификата.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список типов сертификатов.</returns>
		List<CertificateType> Get(
			int? certificateTypeId = null,
			int? pageSize = null,
			int? pageNumber = null);
	}
}
