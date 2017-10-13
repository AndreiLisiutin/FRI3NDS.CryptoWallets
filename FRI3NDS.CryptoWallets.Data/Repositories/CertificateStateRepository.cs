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
	public class CertificateStateRepository : RepositoryBase<CertificateState>, ICertificateStateRepository
	{
		private static List<CertificateState> _list = new List<CertificateState>()
		{
			new CertificateState()
			{
				CertificateStateId = 1,
				Name = "Обрабатывается"
			},
			new CertificateState()
			{
				CertificateStateId = 2,
				Name = "На подтверждении в УЦ"
			},
			new CertificateState()
			{
				CertificateStateId = 3,
				Name = "Подтвержден"
			},
			new CertificateState()
			{
				CertificateStateId = 4,
				Name = "Отвергнут"
			}
		};

		public CertificateStateRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить статус сертификата по идентификатору сатуса.
		/// </summary>
		/// <param name="id">Идентификатор сатуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		public CertificateState GetById(int id)
		{
			return _list.FirstOrDefault(e => e.CertificateStateId == id);
		}

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <returns>Список статусов сертификатов.</returns>
		public List<CertificateState> Get()
		{
			return _list;
		}
	}
}
