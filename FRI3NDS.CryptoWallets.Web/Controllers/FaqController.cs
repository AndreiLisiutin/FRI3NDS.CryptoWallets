using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер ЧаВо.
	/// </summary>
	[Route("api/Faq")]
	public class FaqController: ControllerBase, IFaqService
	{
		/// <summary>
		/// Сервис ЧаВо.
		/// </summary>
		protected IFaqService FaqService { get; private set; }

		/// <summary>
		/// Контроллер ЧаВо.
		/// </summary>
		/// <param name="faqService">Сервис ЧаВо.</param>
		public FaqController(IFaqService faqService)
		{
			this.FaqService = faqService;
		}

		/// <summary>
		/// Получить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>ЧаВо, найденный по идентификатору.</returns>
		public Faq GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.FaqRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список ЧаВо.
		/// </summary>
		/// <returns>Список ЧаВо.</returns>
		public List<Faq> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.FaqRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="faq">Сохраняемый ЧаВо.</param>
		/// <returns>Сохраненный ЧаВо с заполненным идентификатором</returns>
		public Guid Save(FaqBase faq)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.FaqRepository.Save(faq);
			}
		}

		/// <summary>
		/// Удалить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ЧаВо.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.FaqRepository.Delete(id);
			}
		}
	}
}
