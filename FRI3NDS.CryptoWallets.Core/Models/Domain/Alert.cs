using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Models.Domain
{
	/// <summary>
	/// Оповещение об изменении курса.
	/// </summary>
	public class AlertBase
	{
		/// <summary>
		/// Идентификатор оповещения.
		/// </summary>
		public Guid AlertId { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		/// <see cref="User"/>
		public Guid UserId { get; set; }

		/// <summary>
		/// Идентификатор главной валюты.
		/// </summary>
		/// <see cref="Currency"/>
		public Guid CurrencyId { get; set; }

		/// <summary>
		/// Идентификатор валюты, по отношении к которой должна измениться главная.
		/// </summary>
		/// <see cref="Currency"/>
		public Guid CompareCurrencyId { get; set; }

		/// <summary>
		/// Минимальный порог срабатывания оповещения.
		/// </summary>
		public double? MinValue { get; set; }

		/// <summary>
		/// Максимальный порог срабатывания оповещения.
		/// </summary>
		public double? MaxValue { get; set; }

		/// <summary>
		/// Частота срабатывания (один раз/всегда).
		/// </summary>
		/// <see cref="AlertFrequency"/>
		public int AlertFrequencyId { get; set; }

		/// <summary>
		/// Емайл пользователя.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Номер телефона пользователя.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Посылать ли оповещения по телефону.
		/// </summary>
		public bool IsPhoneAlert { get; set; }

		/// <summary>
		/// Посылать ли оповещения на электронную почту.
		/// </summary>
		public bool IsEmailAlert { get; set; }

		/// <summary>
		/// Активное ли в данный момент оповещение.
		/// </summary>
		public bool IsActive { get; set; }
	}

	/// <summary>
	/// Оповещение об изменении курса.
	/// </summary>
	public class Alert: AlertBase
	{

	}
}
