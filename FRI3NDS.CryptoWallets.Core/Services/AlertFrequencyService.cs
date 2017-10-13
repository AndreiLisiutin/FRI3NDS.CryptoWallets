using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Сервис типов частоты оповещений.
	/// </summary>
	public class AlertFrequencyService : ServiceBase, IAlertFrequencyService
	{
		public AlertFrequencyService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор типа частоты оповещений.</param>
		/// <returns>Тип частоты оповещений.</returns>
		public AlertFrequency GetById(int id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AlertFrequencyRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns></returns>
		public List<AlertFrequency> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AlertFrequencyRepository.Get();
			}
		}
	}
}
