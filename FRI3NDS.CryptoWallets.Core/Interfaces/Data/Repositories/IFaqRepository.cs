using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий ЧаВо.
	/// </summary>
	public interface IFaqRepository : IRepositoryBase<FaqBase>
	{
		/// <summary>
		/// Получить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>ЧаВо, найденный по идентификатору.</returns>
		Faq GetById(Guid id);

		/// <summary>
		/// Получить список ЧаВо.
		/// </summary>
		/// <param name="faqId">Идентификатор ЧаВо.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список ЧаВо.</returns>
		List<Faq> Get(
			Guid? faqId = null,
			int? pageSize = null,
			int? pageNumber = null);

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="faq">Сохраняемый ЧаВо.</param>
		/// <returns>Сохраненный ЧаВо с заполненным идентификатором</returns>
		Guid Save(FaqBase faq);

		/// <summary>
		/// Удалить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ЧаВо.</param>
		void Delete(Guid id);
	}
}
