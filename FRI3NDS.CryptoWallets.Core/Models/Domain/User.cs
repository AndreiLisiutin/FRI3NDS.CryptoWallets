using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Пользователь системы.
	/// </summary>
	public class UserBase
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public Guid UserId { get; set; }

		/// <summary>
		/// Логин.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Адрес почты.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Хэш пароля.
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// Номер телефона.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Подтвержден ли Email.
		/// </summary>
		public bool IsEmailConfirmed { get; set; }

		/// <summary>
		/// Подтвержден ли номер телефона.
		/// </summary>
		public bool IsPhoneConfirmed { get; set; }

		/// <summary>
		/// Дата регистрации пользователя.
		/// </summary>
		public DateTime CreatedOn { get; set; }
	}

	/// <summary>
	/// Пользователь системы.
	/// </summary>
	public class User: UserBase
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public string FullName { get; set; }
	}
}
