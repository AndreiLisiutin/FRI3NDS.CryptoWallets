using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий вопросов пользователя.
	/// </summary>
	public interface IQuestionRepository : IRepositoryBase<QuestionBase>
	{
		/// <summary>
		/// Получить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вопрос пользователя, найденный по идентификатору.</returns>
		Question GetById(Guid id);

		/// <summary>
		/// Получить список вопросов пользователя.
		/// </summary>
		/// <param name="questionId">Идентификатор вопроса.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список вопросов пользователя.</returns>
		List<Question> Get(
			Guid? questionId = null,
			Guid? userId = null,
			int? pageSize = null,
			int? pageNumber = null);

		/// <summary>
		/// Сохранить вопрос пользователя.
		/// </summary>
		/// <param name="question">Сохраняемый вопрос пользователя.</param>
		/// <returns>Сохраненный вопрос пользователя с заполненным идентификатором</returns>
		Guid Save(QuestionBase question);

		/// <summary>
		/// Удалить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса пользователя.</param>
		void Delete(Guid id);
	}
}
