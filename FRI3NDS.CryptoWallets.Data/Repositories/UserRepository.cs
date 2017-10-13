using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	public class UserRepository : RepositoryBase<UserBase>, IUserRepository
	{
		private static FakeStore<UserBase, User> store = new FakeStore<UserBase, User>();

		public UserRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Пользователь, найденная по идентификатору.</returns>
		public User GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список пользователей.
		/// </summary>
		/// <returns>Список пользователей.</returns>
		public List<User> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="user">Сохраняемый пользователь.</param>
		/// <returns>Сохраненный пользователь с заполненным идентификатором</returns>
		public Guid Save(UserBase user)
		{
			return store.Save(user).UserId;
		}

		/// <summary>
		/// Удалить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
