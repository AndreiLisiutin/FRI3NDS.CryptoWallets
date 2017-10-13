using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий сертификатов 1С пользователя.
	/// </summary>
	public interface ICertificateRepository : IRepositoryBase<CertificateBase>
	{
		/// <summary>
		/// Получить сертификата 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Сертификат 1С пользователя, найденный по идентификатору.</returns>
		Certificate GetById(Guid id);

		/// <summary>
		/// Получить список сертификатов 1С пользователя.
		/// </summary>
		/// <returns>Список сертификатов 1С пользователя.</returns>
		List<Certificate> Get();

		/// <summary>
		/// Сохранить сертификат 1С пользователя.
		/// </summary>
		/// <param name="certificate">Сохраняемый сертификат 1С пользователя.</param>
		/// <returns>Сохраненный сертификат 1С пользователя с заполненным идентификатором</returns>
		Guid Save(CertificateBase certificate);

		/// <summary>
		/// Удалить сертификат 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор сертификата 1С пользователя.</param>
		void Delete(Guid id);
	}
}
