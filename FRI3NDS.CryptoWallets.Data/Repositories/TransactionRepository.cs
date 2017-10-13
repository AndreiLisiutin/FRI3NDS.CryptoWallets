using AutoMapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий транзакций.
	/// </summary>
	public class TransactionRepository : RepositoryBase<TransactionBase>, ITransactionRepository
	{
		private static FakeStore<TransactionBase, Transaction> store = new FakeStore<TransactionBase, Transaction>();

		public TransactionRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Транзакция, найденная по идентификатору.</returns>
		public Transaction GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список транзакций.
		/// </summary>
		/// <returns>Список транзакций.</returns>
		public List<Transaction> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить транзакцию.
		/// </summary>
		/// <param name="transaction">Сохраняемая транзакция.</param>
		/// <returns>Сохраненная транзакция с заполненным идентификатором</returns>
		public Guid Save(TransactionBase transaction)
		{
			return store.Save(transaction).TransactionId;
		}

		/// <summary>
		/// Удалить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор транзакции.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
