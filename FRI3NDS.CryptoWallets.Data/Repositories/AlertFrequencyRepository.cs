using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий типов частоты оповещений.
	/// </summary>
	public class AlertFrequencyRepository : RepositoryBase<AlertFrequency>, IAlertFrequencyRepository
	{
		public AlertFrequencyRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор частоты срабатывания оповещения.</param>
		/// <returns></returns>
		public AlertFrequency GetById(int id)
		{
			return Get(alertFrequencyId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <param name="alertFrequencyId">Идентификатор частоты срабатывания оповещения.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список типов частоты оповещений.</returns>
		public List<AlertFrequency> Get(
			int? alertFrequencyId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_alert_frequency_id", alertFrequencyId, DbType.Int32);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<AlertFrequency> list = CallProcedure<AlertFrequency>("AlertFrequency$Query", @params);
			return list;
		}
	}
}
