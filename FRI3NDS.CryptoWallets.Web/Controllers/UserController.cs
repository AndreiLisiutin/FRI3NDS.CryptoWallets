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
	public class UserController: ControllerBase
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
		[HttpGet("{id}")]
		public User GetById(Guid id)
		{
			return UserService.GetById(id);
		}

		/// <summary>
		/// Получить список пользователей.
		/// </summary>
		/// <returns>Список пользователей.</returns>
		[HttpGet]
		public List<User> Get()
		{
			return UserService.Get();
		}

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="user">Сохраняемый пользователь.</param>
		/// <returns>Сохраненный пользователь с заполненным идентификатором</returns>
		[HttpPost]
		public Guid Save([FromBody]UserBase user)
		{
			return UserService.Save(user);
		}

		/// <summary>
		/// Удалить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			UserService.Delete(id);
		}
	}
}
