using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий шагов транзакции.
	/// </summary>
	public interface ITransactonActionService : IServiceBase
	{
		/// <summary>
		/// Получить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Шаг транзакции, найденная по идентификатору.</returns>
		TransactonAction GetById(Guid id);

		/// <summary>
		/// Получить список шагов транзакции.
		/// </summary>
		/// <returns>Список шагов транзакции.</returns>
		List<TransactonAction> Get();

		/// <summary>
		/// Сохранить шаг транзакции.
		/// </summary>
		/// <param name="transactonAction">Сохраняемый шаг транзакции.</param>
		/// <returns>Сохраненный шаг транзакции с заполненным идентификатором</returns>
		Guid Save(TransactonActionBase transactonAction);

		/// <summary>
		/// Удалить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор шага транзакции.</param>
		void Delete(Guid id);
	}
}
