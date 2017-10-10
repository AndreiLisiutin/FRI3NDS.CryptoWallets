using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin;
using FRI3NDS.CryptoWallets.Data.Repositories._Admin;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.UnitOfWork
{
	/// <summary>
	/// Единица работы (Паттерн Unit of Work).
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Имя узла конфигурации, хранящее значение строки подключения к БД.
		/// </summary>
		private const string _CONNECTION_STRING_NAME = "Data:CryptoWallets:ConnectionString";
		private Lazy<DataContext> _dataContext;

		/// <summary>
		/// Контекст подключения к базе.
		/// </summary>
		protected DataContext DataContext => this._dataContext.Value;

		#region Repositories

		#endregion

		/// <summary>
		/// Конструктор единицы работы.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта. 
		/// Должен быть заполнен узел для строки подключения к базе данных (<see cref="_CONNECTION_STRING_NAME"/>).</param>
		public UnitOfWork(IConfiguration configuration)
		{
			this._dataContext = new Lazy<DataContext>(() => this._CreateDataContext(configuration), true);
		}

		/// <summary>
		/// Установка соединения с базой данных.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта.</param>
		/// <returns>Контекст данных.</returns>
		private DataContext _CreateDataContext(IConfiguration configuration)
		{
			string connectionString = configuration[_CONNECTION_STRING_NAME];
			IDbConnection connection = new NpgsqlConnection(connectionString);
			connection.Open();
			return new DataContext(connection, null);
		}

		/// <summary>
		/// Открыть транзакцию.
		/// </summary>
		public void BeginTransaction()
		{
			this.DataContext.Transaction = this.DataContext.Connection.BeginTransaction();
		}

		/// <summary>
		/// Подтвердить транзакцию, если она открыта.
		/// </summary>
		public void CommitTransaction()
		{
			if (this.DataContext.Transaction != null)
			{
				this.DataContext.Transaction.Commit();
				this.DataContext.Transaction.Dispose();
				this.DataContext.Transaction = null;
			}
		}

		/// <summary>
		/// Откатить транзакцию, если она открыта.
		/// </summary>
		public void RollbackTransaction()
		{
			if (this.DataContext.Transaction != null)
			{
				this.DataContext.Transaction.Rollback();
				this.DataContext.Transaction.Dispose();
				this.DataContext.Transaction = null;
			}
		}

		/// <summary>
		/// Освободить неуправляемые ресурсы единицы работы такие, как подключение к базе данных и транзакция.
		/// Если транзакция не закрыта, она откатывается.
		/// </summary>
		public void Dispose()
		{
			if (this._dataContext.IsValueCreated)
			{
				this.RollbackTransaction();
				if (this.DataContext.Connection != null)
				{
					this.DataContext.Connection.Dispose();
					this.DataContext.Connection = null;
				}
			}
		}
	}

	/// <summary>
	/// Админская едница работы. Чтоб не засорять основной сайт.
	/// </summary>
	public class AdminUnitOfWork : UnitOfWork, IAdminUnitOfWork
	{
		/// <summary>
		/// Конструктор единицы работы.
		/// </summary>
		/// <param name="configuration">Конфигурация запускаемого проекта. 
		/// Должен быть заполнен узел для строки подключения к базе данных (<see cref="_CONNECTION_STRING_NAME"/>).</param>
		public AdminUnitOfWork(IConfiguration configuration)
			: base(configuration)
		{
		}

		#region Repositories

		/// <summary>
		/// Репозиторий динамический, страшный.
		/// </summary>
		public I_DynamicRepository _DynamicRepository => new _DynamicRepository(this.DataContext);

		/// <summary>
		/// Репозиторий версий базы данных.
		/// </summary>
		public I_VersionRepository _VersionRepository => new _VersionRepository(this.DataContext);

		#endregion
	}
}
