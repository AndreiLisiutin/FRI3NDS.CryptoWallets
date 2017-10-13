using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер транзакций.
	/// </summary>
	[Route("api/Transaction")]
	public class TransactionController: ControllerBase
	{
		/// <summary>
		/// Сервис транзакций.
		/// </summary>
		protected ITransactionService TransactionService { get; private set; }

		/// <summary>
		/// Контроллер транзакций.
		/// </summary>
		/// <param name="transactionService">Сервис транзакций.</param>
		public TransactionController(ITransactionService transactionService)
		{
			this.TransactionService = transactionService;
		}

		/// <summary>
		/// Получить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Транзакция, найденная по идентификатору.</returns>
		[HttpGet("{id}")]
		public Transaction GetById(Guid id)
		{
			return TransactionService.GetById(id);
		}

		/// <summary>
		/// Получить список транзакций.
		/// </summary>
		/// <returns>Список транзакций.</returns>
		[HttpGet]
		public List<Transaction> Get()
		{
			return TransactionService.Get();
		}

		/// <summary>
		/// Сохранить транзакцию.
		/// </summary>
		/// <param name="transaction">Сохраняемая транзакция.</param>
		/// <returns>Сохраненная транзакция с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]TransactionBase transaction)
		{
			return TransactionService.Save(transaction);
		}

		/// <summary>
		/// Удалить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор транзакции.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			TransactionService.Delete(id);
		}
	}
}
