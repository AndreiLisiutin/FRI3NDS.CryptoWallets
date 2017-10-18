using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий кошельков.
	/// </summary>
	public interface IWalletRepository : IRepositoryBase<WalletBase>
	{
		/// <summary>
		/// Получить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		/// <returns>Кошелек, найденная по идентификатору.</returns>
		Wallet GetById(Guid id);

		/// <summary>
		/// Получить список кошельков.
		/// </summary>
		/// <param name="walletId">Идентификатор кошелька.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="currencyId">Идентификатор валюты.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список кошельков.</returns>
		List<Wallet> Get(
			Guid? walletId = null,
			Guid? userId = null,
			Guid? currencyId = null,
			int? pageSize = null,
			int? pageNumber = null);

		/// <summary>
		/// Сохранить кошелек.
		/// </summary>
		/// <param name="wallet">Сохраняемый кошелек.</param>
		/// <returns>Сохраненный кошелек с заполненным идентификатором</returns>
		Guid Save(WalletBase wallet);

		/// <summary>
		/// Удалить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		void Delete(Guid id);
	}
}
