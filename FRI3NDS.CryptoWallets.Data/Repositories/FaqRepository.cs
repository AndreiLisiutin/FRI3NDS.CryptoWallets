using AutoMapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий ЧаВо.
	/// </summary>
	public class FaqRepository : RepositoryBase<FaqBase>, IFaqRepository
	{
		private static FakeStore<FaqBase, Faq> store = new FakeStore<FaqBase, Faq>();

		public FaqRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>ЧаВо, найденный по идентификатору.</returns>
		public Faq GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список ЧаВо.
		/// </summary>
		/// <returns>Список ЧаВо.</returns>
		public List<Faq> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="faq">Сохраняемый ЧаВо.</param>
		/// <returns>Сохраненный ЧаВо с заполненным идентификатором</returns>
		public Guid Save(FaqBase faq)
		{
			return store.Save(faq).FaqId;
		}

		/// <summary>
		/// Удалить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ЧаВо.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
