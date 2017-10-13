using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	public class ServiceBase
	{
		/// <summary>
		/// Фабрика единиц работы. 
		/// Смысла выносить в базовый класс это пока нет, но на всякий вынесем.
		/// </summary>
		private IUnitOfWorkFactory _unitOfWorkFactory;

		/// <summary>
		/// Конструктор тестового сервиса для работы с данными.
		/// </summary>
		/// <param name="unitOfWorkFactory">Фабрика единиц работы.</param>
		public ServiceBase(IUnitOfWorkFactory unitOfWorkFactory)
		{
			this._unitOfWorkFactory = unitOfWorkFactory;
		}

		/// <summary>
		/// Создать единицу работы с подключением к базе данных.
		/// </summary>
		/// <returns>Единица работы.</returns>
		protected IUnitOfWork CreateUnitOfWork()
		{
			return this._unitOfWorkFactory.Create();
		}

		/// <summary>
		/// Создать единицу работы с подключением к базе данных для Админов.
		/// </summary>
		/// <returns>Админская единица работы.</returns>
		protected IAdminUnitOfWork CreateAdminUnitOfWork()
		{
			return this._unitOfWorkFactory.CreateAdmin();
		}
	}
}
