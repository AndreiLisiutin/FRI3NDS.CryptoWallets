using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	public class UserService : ServiceBase, IUserService
	{
		public UserService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Пользователь, найденная по идентификатору.</returns>
		public User GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.UserRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список пользователей.
		/// </summary>
		/// <returns>Список пользователей.</returns>
		public List<User> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.UserRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="user">Сохраняемый пользователь.</param>
		/// <returns>Сохраненный пользователь с заполненным идентификатором</returns>
		public Guid Save(UserBase user)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.UserRepository.Save(user);
			}
		}

		/// <summary>
		/// Удалить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.UserRepository.Delete(id);
			}
		}
	}
}
