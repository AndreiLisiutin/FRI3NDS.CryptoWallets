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
	/// Репозиторий оповещений.
	/// </summary>
	public class AlertRepository : RepositoryBase<AlertBase>, IAlertRepository
	{
		public AlertRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповещение.</returns>
		public Alert GetById(Guid id)
		{
			return Get(alertId: id).FirstOrDefault();
		}

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <param name="alertId">Идентификатор оповещения.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="currencyId">Идентификатор главной валюты.</param>
		/// <param name="isActive">Активное ли в данный момент оповещение.</param>
		/// <param name="pageSize">Размер страницы.</param>
		/// <param name="pageNumber">Номер страницы.</param>
		/// <returns>Список оповещений.</returns>
		public List<Alert> Get(
			Guid? alertId = null,
			Guid? userId = null,
			Guid? currencyId = null,
			bool? isActive = null,
			int? pageSize = null,
			int? pageNumber = null)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_alert_id", alertId, DbType.Guid);
			@params.Add("_user_id", userId, DbType.Guid);
			@params.Add("_currency_id", currencyId, DbType.Guid);
			@params.Add("_is_active", isActive, DbType.Boolean);
			@params.Add("_page_size", pageSize, DbType.Int32);
			@params.Add("_page_number", pageNumber, DbType.Int32);

			List<Alert> list = CallProcedure<Alert>("Alert$Query", @params);
			return list;
		}

		/// <summary>
		/// Сохранить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		public Guid Save(AlertBase alert)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_alert_id", alert.AlertId, DbType.Guid);
			@params.Add("_user_id", alert.UserId, DbType.Guid);
			@params.Add("_currency_id", alert.CurrencyId, DbType.Guid);
			@params.Add("_compare_currency_id", alert.CompareCurrencyId, DbType.Guid);
			@params.Add("_min_value", alert.MinValue, DbType.Decimal);
			@params.Add("_max_value", alert.MaxValue, DbType.Decimal);
			@params.Add("_alert_frequency_id", alert.AlertFrequencyId, DbType.Int32);
			@params.Add("_email", alert.Email, DbType.String);
			@params.Add("_phone", alert.Phone, DbType.String);
			@params.Add("_is_phone_alert", alert.IsPhoneAlert, DbType.Boolean);
			@params.Add("_is_email_alert", alert.IsEmailAlert, DbType.Boolean);
			@params.Add("_is_active", alert.IsActive, DbType.Boolean);

			Guid alertId = CallProcedure<Guid>("Alert$Save", @params)
				.FirstOrDefault();

			alert.AlertId = alertId;
			return alertId;
		}

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		public void Delete(Guid id)
		{
			DynamicParameters @params = new DynamicParameters();
			@params.Add("_id", id, DbType.Guid);

			CallProcedure<Guid>("Alert$Delete", @params);
		}
	}
}
