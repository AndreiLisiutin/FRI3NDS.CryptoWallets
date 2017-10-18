using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий кошельков.
	/// </summary>
	public class WalletRepository : RepositoryBase<WalletBase>, IWalletRepository
	{
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
			return Get(walletId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список кошельков.
		/// </summary>
		/// <param name="walletId">Идентификатор кошелька.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="currencyId">Идентификатор валюты.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список кошельков.</returns>
		public List<Wallet> Get(
			Guid? walletId = null,
			Guid? userId = null,
			Guid? currencyId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_wallet_id", walletId, DbType.Guid);
			@params.Add("_currency_id", currencyId, DbType.Guid);
			@params.Add("_user_id", userId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Guid);
			@params.Add("_page_number", pageNumber, DbType.Guid);

			List<Wallet> list = CallProcedure<Wallet>("Wallet$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить кошелек.
		/// </summary>
		/// <param name="wallet">Сохраняемый кошелек.</param>
		/// <returns>Сохраненный кошелек с заполненным идентификатором</returns>
		public Guid Save(WalletBase wallet)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_wallet_id", wallet.WalletId, DbType.Guid);
			@params.Add("_currency_id", wallet.CurrencyId, DbType.Guid);
			@params.Add("_user_id", wallet.UserId, DbType.Guid);
			@params.Add("_balance", wallet.Balance, DbType.Decimal);
			@params.Add("_created_on", wallet.CreatedOn, DbType.Date);
			@params.Add("_last_updated_on", wallet.LastUpdatedOn, DbType.Date);
			@params.Add("_address", wallet.Address, DbType.String);

			Guid walletId = CallProcedure<Guid>("Wallet$Save", @params).FirstOrDefault();

			wallet.UserId = walletId;
			return walletId;
		}

		/// <summary>
		/// Удалить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Wallet$Delete", @params);
		}
	}
}
