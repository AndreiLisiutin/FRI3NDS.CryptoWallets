using AutoMapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий сертификатов 1С пользователя.
	/// </summary>
	public class CertificateRepository : RepositoryBase<CertificateBase>, ICertificateRepository
	{
		private static FakeStore<CertificateBase, Certificate> store = new FakeStore<CertificateBase, Certificate>();

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
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список сертификатов 1С пользователя.
		/// </summary>
		/// <returns>Список сертификатов 1С пользователя.</returns>
		public List<Certificate> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить сертификат 1С пользователя.
		/// </summary>
		/// <param name="certificate">Сохраняемый сертификат 1С пользователя.</param>
		/// <returns>Сохраненный сертификат 1С пользователя с заполненным идентификатором</returns>
		public Guid Save(CertificateBase certificate)
		{
			return store.Save(certificate).CertificateId;
		}

		/// <summary>
		/// Удалить сертификат 1С пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор сертификата 1С пользователя.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
