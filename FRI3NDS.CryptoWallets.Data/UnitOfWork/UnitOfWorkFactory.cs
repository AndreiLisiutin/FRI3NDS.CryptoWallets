﻿using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.UnitOfWork
{
	/// <summary>
	/// Фабрика единиц работы.
	/// </summary>
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private IConfiguration _configuration;

		/// <summary>
		/// Конструктор фабрики единиц работы.
		/// </summary>
		/// <param name="configuration">Конфигурация приложения.</param>
		public UnitOfWorkFactory(IConfiguration configuration)
		{
			this._configuration = configuration;
		}

		/// <summary>
		/// Создать новую единицу работы с заданной конфигурацией.
		/// </summary>
		/// <returns>Экземпляр единицы работы.</returns>
		public IUnitOfWork Create()
		{
			return new UnitOfWork(this._configuration);
		}

		/// <summary>
		/// Создать новую единицу работы с заданной конфигурацией.
		/// </summary>
		/// <returns>Экземпляр единицы работы.</returns>
		public IAdminUnitOfWork CreateAdmin()
		{
			return new AdminUnitOfWork(this._configuration);
		}
	}
}
