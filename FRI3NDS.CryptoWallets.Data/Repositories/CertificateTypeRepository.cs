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
	/// Репозиторий статусов сертификатов.
	/// </summary>
	public class CertificateTypeRepository : RepositoryBase<CertificateType>, ICertificateTypeRepository
	{
		private static List<CertificateType> _list = new List<CertificateType>()
		{
			new CertificateType()
			{
				CertificateTypeId = 1,
				Name = "Физическое лицо"
			},
			new CertificateType()
			{
				CertificateTypeId = 2,
				Name = "Юридическое лицо"
			},
			new CertificateType()
			{
				CertificateTypeId = 3,
				Name = "Красно личико"
			},
			new CertificateType()
			{
				CertificateTypeId = 4,
				Name = "Лицо со шрамом"
			}
		};

		public CertificateTypeRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить статус сертификата по идентификатору сатуса.
		/// </summary>
		/// <param name="id">Идентификатор сатуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		public CertificateType GetById(int id)
		{
			return _list.FirstOrDefault(e => e.CertificateTypeId == id);
		}

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <returns>Список статусов сертификатов.</returns>
		public List<CertificateType> Get()
		{
			return _list;
		}
	}
}
