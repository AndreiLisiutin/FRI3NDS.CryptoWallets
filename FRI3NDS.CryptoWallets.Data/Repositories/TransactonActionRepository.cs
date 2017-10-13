using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий шагов транзакции.
	/// </summary>
	public class TransactonActionRepository : RepositoryBase<TransactonActionBase>, ITransactonActionRepository
	{
		private static FakeStore<TransactonActionBase, TransactonAction> store = new FakeStore<TransactonActionBase, TransactonAction>();

		public TransactonActionRepository(DataContext dataContext)
			: base(dataContext)
		{
		}
		/// <summary>
		/// Получить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Шаг транзакции, найденная по идентификатору.</returns>
		public TransactonAction GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список шагов транзакции.
		/// </summary>
		/// <returns>Список шагов транзакции.</returns>
		public List<TransactonAction> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить шаг транзакции.
		/// </summary>
		/// <param name="transactonAction">Сохраняемый шаг транзакции.</param>
		/// <returns>Сохраненный шаг транзакции с заполненным идентификатором</returns>
		public Guid Save(TransactonActionBase transactonAction)
		{
			return store.Save(transactonAction).TransactonActionId;
		}

		/// <summary>
		/// Удалить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор шага транзакции.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
