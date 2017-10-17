using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	public interface IUserService : IServiceBase
	{
		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <returns>Пользователь, найденная по идентификатору.</returns>
		User GetById(Guid id);

		/// <summary>
		/// Получить список пользователей.
		/// </summary>
		/// <returns>Список пользователей.</returns>
		List<User> Get();

		/// <summary>
		/// Сохранить пользователя.
		/// </summary>
		/// <param name="user">Сохраняемый пользователь.</param>
		/// <returns>Сохраненный пользователь с заполненным идентификатором</returns>
		Guid Save(UserBase user);

		/// <summary>
		/// Удалить пользователя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		void Delete(Guid id);

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="user">Данные пользователя.</param>
        /// <returns>Данные пользователя с идентификатором.</returns>
        UserBase CreateUser(UserBase user);

        /// <summary>
        /// Проверить существование пользователя с заданными логином и паролем.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Пользователь, если существует, или NULL.</returns>
        UserBase VerifyUser(string login, string password);
    }
}
