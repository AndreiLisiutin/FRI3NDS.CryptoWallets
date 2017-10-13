using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер шагов транзакции.
	/// </summary>
	[Route("api/TransactonAction")]
	public class TransactonActionController: ControllerBase
	{
		/// <summary>
		/// Сервис шагов транзакции.
		/// </summary>
		protected ITransactonActionService TransactonActionService { get; private set; }

		/// <summary>
		/// Контроллер шагов транзакции.
		/// </summary>
		/// <param name="transactonActionService">Сервис шагов транзакции.</param>
		public TransactonActionController(ITransactonActionService transactonActionService)
		{
			this.TransactonActionService = transactonActionService;
		}

		/// <summary>
		/// Получить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Шаг транзакции, найденная по идентификатору.</returns>
		[HttpGet("{id}")]
		public TransactonAction GetById(Guid id)
		{
			return TransactonActionService.GetById(id);
		}

		/// <summary>
		/// Получить список шагов транзакции.
		/// </summary>
		/// <returns>Список шагов транзакции.</returns>
		[HttpGet]
		public List<TransactonAction> Get()
		{
			return TransactonActionService.Get();
		}

		/// <summary>
		/// Сохранить шаг транзакции.
		/// </summary>
		/// <param name="transactonAction">Сохраняемый шаг транзакции.</param>
		/// <returns>Сохраненный шаг транзакции с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]TransactonActionBase transactonAction)
		{
			return TransactonActionService.Save(transactonAction);
		}

		/// <summary>
		/// Удалить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор шага транзакции.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			TransactonActionService.Delete(id);
		}
	}
}
