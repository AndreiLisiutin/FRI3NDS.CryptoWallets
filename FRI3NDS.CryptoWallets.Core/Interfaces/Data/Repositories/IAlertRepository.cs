using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий оповещений.
	/// </summary>
	public interface IAlertRepository : IRepositoryBase<AlertBase>
	{
		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповещение.</returns>
		Alert GetById(Guid id);

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <param name="alertId">Идентификатор оповещения.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="currencyId">Идентификатор главной валюты.</param>
		/// <param name="isActive">Активное ли в данный момент оповещение.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список оповещений.</returns>
		List<Alert> Get(
			Guid? alertId = null,
			Guid? userId = null,
			Guid? currencyId = null,
			bool? isActive = null,
			int? pageSize = null,
			int? pageNumber = null);

		/// <summary>
		/// Сохранить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		Guid Save(AlertBase alert);

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		void Delete(Guid id);
	}
}
