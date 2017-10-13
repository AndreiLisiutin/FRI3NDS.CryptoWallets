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
		/// <returns>Список оповещений.</returns>
		List<Alert> Get();

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
