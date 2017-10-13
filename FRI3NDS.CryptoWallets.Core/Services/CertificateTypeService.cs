using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий типов сертификатов.
	/// </summary>
	public class CertificateTypeService : ServiceBase, ICertificateTypeService
	{
		public CertificateTypeService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить тип сертификата по идентификатору типа.
		/// </summary>
		/// <param name="id">Идентификатор типа.</param>
		/// <returns>Тип сертификата, найденный по его идентификатору.</returns>
		public CertificateType GetById(int id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateTypeRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список типов сертификатов.
		/// </summary>
		/// <returns>Список типов сертификатов.</returns>
		public List<CertificateType> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CertificateTypeRepository.Get();
			}
		}
	}
}
