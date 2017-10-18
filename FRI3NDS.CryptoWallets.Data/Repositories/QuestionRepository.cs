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
	/// Репозиторий вопросов пользователя.
	/// </summary>
	public class QuestionRepository : RepositoryBase<QuestionBase>, IQuestionRepository
	{
		public QuestionRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса.</param>
		/// <returns>Вопрос пользователя, найденный по идентификатору.</returns>
		public Question GetById(Guid id)
		{
			return Get(questionId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список вопросов пользователя.
		/// </summary>
		/// <param name="questionId">Идентификатор вопроса.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список вопросов пользователя.</returns>
		public List<Question> Get(
			Guid? questionId = null,
			Guid? userId = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_question_id", questionId, DbType.Guid);
			@params.Add("_user_id", userId, DbType.Guid);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Question> list = CallProcedure<Question>("Question$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить вопрос пользователя.
		/// </summary>
		/// <param name="question">Сохраняемый вопрос пользователя.</param>
		/// <returns>Сохраненный вопрос пользователя с заполненным идентификатором</returns>
		public Guid Save(QuestionBase question)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_question_id", question.QuestionId, DbType.Guid);
			@params.Add("_user_id", question.UserId, DbType.Guid);
			@params.Add("_question", question.Question, DbType.String);
			@params.Add("_email", question.Email, DbType.String);
			@params.Add("_created_on", question.CreatedOn, DbType.Date);

			Guid questionId = CallProcedure<Guid>("Question$Save", @params)
				.FirstOrDefault();

			question.QuestionId = questionId;
			return questionId;
		}

		/// <summary>
		/// Удалить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса пользователя.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Question$Delete", @params);
		}
	}
}
