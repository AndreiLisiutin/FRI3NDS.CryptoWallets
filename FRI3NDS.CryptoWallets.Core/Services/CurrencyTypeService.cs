using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий типов валют.
	/// </summary>
	public class CurrencyTypeService : ServiceBase, ICurrencyTypeService
	{
		public CurrencyTypeService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить тип валюты по идентификатору статуса.
		/// </summary>
		/// <param name="id">Идентификатор типа валюты.</param>
		/// <returns>Тип валюты, найденный по его идентификатору.</returns>
		public CurrencyType GetById(int id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CurrencyTypeRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список типов валют.
		/// </summary>
		/// <returns>Список типов валют.</returns>
		public List<CurrencyType> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CurrencyTypeRepository.Get();
			}
		}
	}
}
