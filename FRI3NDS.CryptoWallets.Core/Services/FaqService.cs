using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий ЧаВо.
	/// </summary>
	public class FaqService : ServiceBase, IFaqService
	{
		public FaqService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
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
