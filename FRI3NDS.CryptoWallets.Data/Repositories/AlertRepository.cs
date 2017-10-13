using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий оповещений.
	/// </summary>
	public class AlertRepository : RepositoryBase<AlertBase>, IAlertRepository
	{
		private static FakeStore<AlertBase, Alert> store = new FakeStore<AlertBase, Alert>();

		public AlertRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповещение.</returns>
		public Alert GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <returns>Список оповещений.</returns>
		public List<Alert> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		public Guid Save(AlertBase alert)
		{
			return store.Save(alert).AlertId;
		}

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
