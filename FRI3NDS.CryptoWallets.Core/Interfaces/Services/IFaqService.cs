using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий ЧаВо.
	/// </summary>
	public interface IFaqService : IServiceBase
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
		/// <returns>Список ЧаВо.</returns>
		List<Faq> Get();

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
