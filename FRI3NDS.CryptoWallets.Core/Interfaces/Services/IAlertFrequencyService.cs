using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Сервис типов частоты оповещений.
	/// </summary>
	public interface IAlertFrequencyService
	{
		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор типа частоты оповещений.</param>
		/// <returns>Тип частоты оповещений.</returns>
		AlertFrequency GetById(int id);

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns>Список типов частоты оповещений.</returns>
		List<AlertFrequency> Get();
	}
}
