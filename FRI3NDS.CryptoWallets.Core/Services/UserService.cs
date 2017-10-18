using FRI3NDS.CryptoWallets.Core.Infrastructure;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Utils;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	public class UserService : ServiceBase, IUserService
	{
		public UserService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
			: base(unitOfWorkFactory, localizer)
		{
		}

		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Пользователь, найденная по идентификатору.</returns>
		public User GetById(Guid id)
		{
			using (var uow = CreateUnitOfWork())
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
			using (var uow = CreateUnitOfWork())
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
			using (var uow = CreateUnitOfWork())
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
			using (var uow = CreateUnitOfWork())
			{
				uow.UserRepository.Delete(id);
			}
		}

		/// <summary>
		/// Создать нового пользователя.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		/// <returns>Данные пользователя с идентификатором.</returns>
		public UserBase CreateUser(UserBase user)
		{
			Argument.Require(!string.IsNullOrWhiteSpace(user.Login), Localizer["ERROR_EMPTY", Localizer["User.Login"]]);
			Argument.Require(!string.IsNullOrWhiteSpace(user.PasswordHash), Localizer["ERROR_EMPTY", Localizer["User.Password"]]);
			Argument.Require(!string.IsNullOrWhiteSpace(user.Email), Localizer["ERROR_EMPTY", Localizer["User.Email"]]);

			user.UserId = Guid.Empty; //TODO: заменить на что-то общее
			user.PasswordHash = _HashPassword(user.PasswordHash);
			user.CreatedOn = DateTime.Now;
			using (var unitOfWork = CreateUnitOfWork())
			{
				User existingUser = unitOfWork.UserRepository.Get(login: user.Login)
					.FirstOrDefault();
				Argument.Require(existingUser == null, Localizer["User.Error.AlreadyExists"]);

				user.UserId = unitOfWork.UserRepository.Save(user);
			}
			return user;
		}

		/// <summary>
		/// Проверить существование пользователя с заданными логином и паролем.
		/// </summary>
		/// <param name="login">Логин.</param>
		/// <param name="password">Пароль.</param>
		/// <returns>Пользователь, если существует, или NULL.</returns>
		public UserBase VerifyUser(string login, string password)
		{
			Argument.Require(!string.IsNullOrWhiteSpace(login), Localizer["ERROR_EMPTY", Localizer["User.Login"]]);
			Argument.Require(!string.IsNullOrWhiteSpace(password), Localizer["ERROR_EMPTY", Localizer["User.Password"]]);

			using (var unitOfWork = this.CreateUnitOfWork())
			{
				UserBase user = unitOfWork.UserRepository.Get(login: login)
					.FirstOrDefault();
				if (user == null)
				{
					return null;
				}

				bool isUserExists = this._VerifyPassword(password, user.PasswordHash);
				return isUserExists ? user : null;
			}
		}

		private string _HashPassword(string password)
		{
			return SecurePasswordHasher.Hash(password);
		}
		private bool _VerifyPassword(string password, string hash)
		{
			return SecurePasswordHasher.Verify(password, hash);
		}

	}
}
