using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий ЧаВо.
	/// </summary>
	public class FaqRepository : RepositoryBase<FaqBase>, IFaqRepository
	{
		public FaqRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ЧаВо.</param>
		/// <returns>ЧаВо, найденный по идентификатору.</returns>
		public Faq GetById(Guid id)
		{
			return Get(faqId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список ЧаВо.
		/// </summary>
		/// <param name="faqId">Идентификатор ЧаВо.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список ЧаВо.</returns>
		public List<Faq> Get(
			Guid? faqId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_faq_id", faqId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Faq> list = CallProcedure<Faq>("Faq$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить документ.
		/// </summary>
		/// <param name="faq">Сохраняемый ЧаВо.</param>
		/// <returns>Сохраненный ЧаВо с заполненным идентификатором</returns>
		public Guid Save(FaqBase faq)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_faq_id", faq.FaqId, DbType.Guid);
			@params.Add("_question", faq.Question, DbType.String);
			@params.Add("_answer", faq.Answer, DbType.String);
			@params.Add("_created_on", faq.CreatedOn, DbType.Date);

			Guid faqId = CallProcedure<Guid>("Faq$Save", @params)
				.FirstOrDefault();

			faq.FaqId = faqId;
			return faqId;
		}

		/// <summary>
		/// Удалить ЧаВо по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор ЧаВо.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Faq$Delete", @params);
		}
	}
}
