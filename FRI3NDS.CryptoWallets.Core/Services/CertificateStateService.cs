using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий статусов сертификатов.
	/// </summary>
	public class CertificateStateService : ServiceBase, ICertificateStateService
	{
		public CertificateStateService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить статус сертификата по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор статуса.</param>
		/// <returns>Статус сертификата, найденный по его идентификатору.</returns>
		public CertificateState GetById(int id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateStateRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список статусов сертификатов.
		/// </summary>
		/// <returns>Список статусов сертификатов.</returns>
		public List<CertificateState> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateStateRepository.Get();
			}
		}
	}
}
