using Dapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
    /// <summary>
    /// Репозиторий пользователей.
    /// </summary>
    public class UserRepository : RepositoryBase<UserBase>, IUserRepository
    {
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
            return this.Get(userId: id).FirstOrDefault();
        }

        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="email">Email пользователя.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <returns>Список пользователей.</returns>
        public List<User> Get(
            Guid? userId = null,
            string login = null,
            string email = null,
            int? pageSize = null,
            int? pageNumber = null)
        {
            DynamicParameters @params = new DynamicParameters();
            @params.Add("_user_id", userId, DbType.Guid);
            @params.Add("_login", login, DbType.String);
            @params.Add("_email", email, DbType.String);
            @params.Add("_page_size", pageSize, DbType.Int32);
            @params.Add("_page_number", pageNumber, DbType.Int32);

            List<User> list = CallProcedure<User>("User$Query", @params);
            return list;
        }
        
        /// <summary>
        /// Сохранить пользователя.
        /// </summary>
        /// <param name="user">Сохраняемый пользователь.</param>
        /// <returns>Сохраненный пользователь с заполненным идентификатором</returns>
        public Guid Save(UserBase user)
        {
            DynamicParameters @params = new DynamicParameters();
            @params.Add("_user_id", user.UserId, DbType.Guid);
            @params.Add("_email", user.Email, DbType.String);
            @params.Add("_password", user.PasswordHash, DbType.String);
            @params.Add("_login", user.Login, DbType.String);
            @params.Add("_is_email_confirmed", user.IsEmailConfirmed, DbType.Boolean);
            @params.Add("_is_phone_confirmed", user.IsPhoneConfirmed, DbType.Boolean);
            @params.Add("_first_name", user.FirstName, DbType.String);
            @params.Add("_last_name", user.LastName, DbType.String);
            @params.Add("_created_on", user.CreatedOn, DbType.Date);

            Guid userId = CallProcedure<Guid>("User$Save", @params).FirstOrDefault();

            user.UserId = userId;
            return userId;
        }

        /// <summary>
        /// Удалить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public void Delete(Guid id)
        {
            DynamicParameters @params = new DynamicParameters();
            @params.Add("_id", id, DbType.Guid);

            CallProcedure<Guid>("User$Delete", @params);
        }
    }
}
