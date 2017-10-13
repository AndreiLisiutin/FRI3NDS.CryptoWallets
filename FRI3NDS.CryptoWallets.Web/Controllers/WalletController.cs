using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер кошельков.
	/// </summary>
	[Route("api/Wallet")]
	public class WalletController: ControllerBase, IWalletService
	{
		/// <summary>
		/// Сервис кошельков.
		/// </summary>
		protected IWalletService WalletService { get; private set; }

		/// <summary>
		/// Контроллер кошельков.
		/// </summary>
		/// <param name="walletService">Сервис кошельков.</param>
		public WalletController(IWalletService walletService)
		{
			this.WalletService = walletService;
		}

		/// <summary>
		/// Получить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		/// <returns>Кошелек, найденная по идентификатору.</returns>
		public Wallet GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.WalletRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список кошельков.
		/// </summary>
		/// <returns>Список кошельков.</returns>
		public List<Wallet> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.WalletRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить кошелек.
		/// </summary>
		/// <param name="wallet">Сохраняемый кошелек.</param>
		/// <returns>Сохраненный кошелек с заполненным идентификатором</returns>
		public Guid Save(WalletBase wallet)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.WalletRepository.Save(wallet);
			}
		}

		/// <summary>
		/// Удалить кошелек по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор кошелька.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.WalletRepository.Delete(id);
			}
		}
	}
}
