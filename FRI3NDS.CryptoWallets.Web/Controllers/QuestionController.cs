using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер вопросов пользователя.
	/// </summary>
	[Route("api/Question")]
	public class QuestionController: ControllerBase, IQuestionService
	{
		/// <summary>
		/// Сервис вопросов пользователя.
		/// </summary>
		protected IQuestionService QuestionService { get; private set; }

		/// <summary>
		/// Контроллер вопросов пользователя.
		/// </summary>
		/// <param name="questionService">Сервис вопросов пользователя.</param>
		public QuestionController(IQuestionService questionService)
		{
			this.QuestionService = questionService;
		}

		/// <summary>
		/// Получить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вопрос пользователя, найденный по идентификатору.</returns>
		public Question GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
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
			using (var uow = this.CreateUnitOfWork())
			{
				uow.QuestionRepository.Delete(id);
			}
		}
	}
}
