using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий шагов транзакции.
	/// </summary>
	public class TransactonActionService : ServiceBase, ITransactonActionService
	{
		public TransactonActionService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}
		/// <summary>
		/// Получить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Шаг транзакции, найденная по идентификатору.</returns>
		public TransactonAction GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.TransactonActionRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список шагов транзакции.
		/// </summary>
		/// <returns>Список шагов транзакции.</returns>
		public List<TransactonAction> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.TransactonActionRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить шаг транзакции.
		/// </summary>
		/// <param name="transactonAction">Сохраняемый шаг транзакции.</param>
		/// <returns>Сохраненный шаг транзакции с заполненным идентификатором</returns>
		public Guid Save(TransactonActionBase transactonAction)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.TransactonActionRepository.Save(transactonAction);
			}
		}

		/// <summary>
		/// Удалить шаг транзакции по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор шага транзакции.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.TransactonActionRepository.Delete(id);
			}
		}
	}
}
