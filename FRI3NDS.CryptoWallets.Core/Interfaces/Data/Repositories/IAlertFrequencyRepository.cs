using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий типов частоты оповещений.
	/// </summary>
	public interface IAlertFrequencyRepository : IRepositoryBase<AlertFrequency>
	{
		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns></returns>
		AlertFrequency GetById(int id);

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <param name="alertFrequencyId">Идентификатор частоты срабатывания оповещения.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список типов частоты оповещений.</returns>
		List<AlertFrequency> Get(
			int? alertFrequencyId = null,
			int? pageSize = null,
			int? pageNumber = null);
	}
}
