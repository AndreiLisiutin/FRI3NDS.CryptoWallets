using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер пользователей.
	/// </summary>
	[Route("api/User")]
	public class UserController: ControllerBase, IUserService
	{
		/// <summary>
		/// Сервис пользователей.
		/// </summary>
		protected IUserService UserService { get; private set; }

		/// <summary>
		/// Контроллер пользователей.
		/// </summary>
		/// <param name="userService">Сервис пользователей.</param>
		public UserController(IUserService userService)
		{
			this.UserService = userService;
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
