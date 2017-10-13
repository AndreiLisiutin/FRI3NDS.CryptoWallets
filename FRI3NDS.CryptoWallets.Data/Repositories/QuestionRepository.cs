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
	/// Репозиторий вопросов пользователя.
	/// </summary>
	public class QuestionRepository : RepositoryBase<QuestionBase>, IQuestionRepository
	{
		private static FakeStore<QuestionBase, Question> store = new FakeStore<QuestionBase, Question>();

		public QuestionRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вопрос пользователя, найденный по идентификатору.</returns>
		public Question GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список вопросов пользователя.
		/// </summary>
		/// <returns>Список вопросов пользователя.</returns>
		public List<Question> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить вопрос пользователя.
		/// </summary>
		/// <param name="question">Сохраняемый вопрос пользователя.</param>
		/// <returns>Сохраненный вопрос пользователя с заполненным идентификатором</returns>
		public Guid Save(QuestionBase question)
		{
			return store.Save(question).QuestionId;
		}

		/// <summary>
		/// Удалить вопрос пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вопроса пользователя.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
