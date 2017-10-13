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
	public class TransactionController: ControllerBase, ITransactionService
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
		public Transaction GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.TransactionRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список транзакций.
		/// </summary>
		/// <returns>Список транзакций.</returns>
		public List<Transaction> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.TransactionRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить транзакцию.
		/// </summary>
		/// <param name="transaction">Сохраняемая транзакция.</param>
		/// <returns>Сохраненная транзакция с заполненным идентификатором</returns>
		public Guid Save(TransactionBase transaction)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.TransactionRepository.Save(transaction);
			}
		}

		/// <summary>
		/// Удалить транзакцию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор транзакции.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.TransactionRepository.Delete(id);
			}
		}
	}
}
