using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Сервис типов частоты оповещений.
	/// </summary>
	public class AlertFrequencyService : ServiceBase, IAlertFrequencyService
	{
		public AlertFrequencyService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer) 
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор типа частоты оповещений.</param>
		/// <returns>Тип частоты оповещений.</returns>
		public AlertFrequency GetById(int id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.AlertFrequencyRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns>Список типов частоты оповещений.</returns>
		public List<AlertFrequency> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.AlertFrequencyRepository.Get();
			}
		}
	}
}
