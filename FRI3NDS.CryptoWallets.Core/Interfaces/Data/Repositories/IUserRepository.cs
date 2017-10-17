using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий пользователей.
	/// </summary>
	public interface IUserRepository : IRepositoryBase<UserBase>
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
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="email">Email пользователя.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <returns>Список пользователей.</returns>
        List<User> Get(
            Guid? userId = null,
            string login = null,
            string email = null,
            int? pageSize = null,
            int? pageNumber = null);

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
	}
}
