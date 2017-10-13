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
	public class QuestionController : ControllerBase
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
		[HttpGet("{id}")]
		public Question GetById(Guid id)
		{
			return QuestionService.GetById(id);
		}

		/// <summary>
		/// Получить список вопросов пользователя.
		/// </summary>
		/// <returns>Список вопросов пользователя.</returns>
		[HttpGet]
		public List<Question> Get()
		{
			return QuestionService.Get();
		}

		/// <summary>
		/// Сохранить вопрос пользователя.
		/// </summary>
		/// <param name="question">Сохраняемый вопрос пользователя.</param>
		/// <returns>Сохраненный вопрос пользователя с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]QuestionBase question)
		{
			return QuestionService.Save(question);
		}

		/// <summary>
		/// Удалить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса пользователя.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			QuestionService.Delete(id);
		}
	}
}
