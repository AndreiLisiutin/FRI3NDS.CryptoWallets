using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий кошельков.
	/// </summary>
	public class WalletRepository : RepositoryBase<WalletBase>, IWalletRepository
	{
		private static FakeStore<WalletBase, Wallet> store = new FakeStore<WalletBase, Wallet>();

		public WalletRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		/// <returns>Кошелек, найденная по идентификатору.</returns>
		public Wallet GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список кошельков.
		/// </summary>
		/// <returns>Список кошельков.</returns>
		public List<Wallet> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить кошелек.
		/// </summary>
		/// <param name="wallet">Сохраняемый кошелек.</param>
		/// <returns>Сохраненный кошелек с заполненным идентификатором</returns>
		public Guid Save(WalletBase wallet)
		{
			return store.Save(wallet).WalletId;
		}

		/// <summary>
		/// Удалить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
