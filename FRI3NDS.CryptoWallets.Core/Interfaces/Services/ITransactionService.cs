using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий транзакций.
	/// </summary>
	public interface ITransactionService : IServiceBase
	{
		/// <summary>
		/// Получить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Транзакция, найденная по идентификатору.</returns>
		Transaction GetById(Guid id);

		/// <summary>
		/// Получить список транзакций.
		/// </summary>
		/// <returns>Список транзакций.</returns>
		List<Transaction> Get();

		/// <summary>
		/// Сохранить транзакцию.
		/// </summary>
		/// <param name="transaction">Сохраняемая транзакция.</param>
		/// <returns>Сохраненная транзакция с заполненным идентификатором</returns>
		Guid Save(TransactionBase transaction);

		/// <summary>
		/// Удалить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор транзакции.</param>
		void Delete(Guid id);
	}
}
