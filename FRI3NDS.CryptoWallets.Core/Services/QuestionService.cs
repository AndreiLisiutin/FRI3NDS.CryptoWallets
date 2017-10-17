using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий вопросов пользователя.
	/// </summary>
	public class QuestionService : ServiceBase, IQuestionService
	{
		public QuestionService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вопрос пользователя, найденный по идентификатору.</returns>
		public Question GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.QuestionRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список вопросов пользователя.
		/// </summary>
		/// <returns>Список вопросов пользователя.</returns>
		public List<Question> Get()
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.QuestionRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить вопрос пользователя.
		/// </summary>
		/// <param name="question">Сохраняемый вопрос пользователя.</param>
		/// <returns>Сохраненный вопрос пользователя с заполненным идентификатором</returns>
		public Guid Save(QuestionBase question)
		{
			using (var uow = CreateUnitOfWork())
			{
				return uow.QuestionRepository.Save(question);
			}
		}

		/// <summary>
		/// Удалить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса пользователя.</param>
		public void Delete(Guid id)
		{
			using (var uow = CreateUnitOfWork())
			{
				uow.QuestionRepository.Delete(id);
			}
		}
	}
}
