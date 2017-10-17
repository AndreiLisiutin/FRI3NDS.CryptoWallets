using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Сервис оповещений.
	/// </summary>
	public class AlertService : ServiceBase, IAlertService
	{
		public AlertService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
            : base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповещение.</returns>
		public Alert GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.AlertRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <returns>Список оповещений.</returns>
		public List<Alert> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.AlertRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		public Guid Save(AlertBase alert)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.AlertRepository.Save(alert);
			}
		}

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.AlertRepository.Delete(id);
			}
		}
	}
}
