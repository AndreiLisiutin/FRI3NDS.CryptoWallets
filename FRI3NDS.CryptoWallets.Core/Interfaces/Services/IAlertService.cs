using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Сервис оповещений.
	/// </summary>
	public interface IAlertService
	{
		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповешение.</returns>
		Alert GetById(Guid id);

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <returns></returns>
		List<Alert> Get();

		/// <summary>
		/// Сохренить оповещение.
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
