using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin;
using FRI3NDS.CryptoWallets.Data.Repositories;
using FRI3NDS.CryptoWallets.Data.Repositories._Admin;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

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

		/// <summary>
		/// Репозиторий типов частоты оповещений.
		/// </summary>
		public IAlertFrequencyRepository AlertFrequencyRepository => new AlertFrequencyRepository(this.DataContext);

		/// <summary>
		/// Репозиторий оповещений.
		/// </summary>
		public IAlertRepository AlertRepository => new AlertRepository(this.DataContext);

		/// <summary>
		/// Репозиторий вложений в документ (файлов).
		/// </summary>
		public IAttachmentRepository AttachmentRepository => new AttachmentRepository(this.DataContext);

		/// <summary>
		/// Репозиторий сертификатов 1С пользователя.
		/// </summary>
		public ICertificateRepository CertificateRepository => new CertificateRepository(this.DataContext);

		/// <summary>
		/// Репозиторий статусов сертификатов.
		/// </summary>
		public ICertificateStateRepository CertificateStateRepository => new CertificateStateRepository(this.DataContext);

		/// <summary>
		/// Репозиторий типов сертификатов.
		/// </summary>
		public ICertificateTypeRepository CertificateTypeRepository => new CertificateTypeRepository(this.DataContext);

		/// <summary>
		/// Репозиторий городов.
		/// </summary>
		public ICityRepository CityRepository => new CityRepository(this.DataContext);

		/// <summary>
		/// Репозиторий стран.
		/// </summary>
		public ICountryRepository CountryRepository => new CountryRepository(this.DataContext);

		/// <summary>
		/// Репозиторий валют.
		/// </summary>
		public ICurrencyRepository CurrencyRepository => new CurrencyRepository(this.DataContext);

		/// <summary>
		/// Репозиторий курсов валюты.
		/// </summary>
		public ICurrencyRateRepository CurrencyRateRepository => new CurrencyRateRepository(this.DataContext);

		/// <summary>
		/// Репозиторий типов валют.
		/// </summary>
		public ICurrencyTypeRepository CurrencyTypeRepository => new CurrencyTypeRepository(this.DataContext);

		/// <summary>
		/// Репозиторий документов.
		/// </summary>
		public IDocumentRepository DocumentRepository => new DocumentRepository(this.DataContext);

		/// <summary>
		/// Репозиторий ЧаВо.
		/// </summary>
		public IFaqRepository FaqRepository => new FaqRepository(this.DataContext);

		/// <summary>
		/// Репозиторий вопросов пользователя.
		/// </summary>
		public IQuestionRepository QuestionRepository => new QuestionRepository(this.DataContext);

		/// <summary>
		/// Репозиторий регионов.
		/// </summary>
		public IRegionRepository RegionRepository => new RegionRepository(this.DataContext);

		/// <summary>
		/// Репозиторий транзакций.
		/// </summary>
		public ITransactionRepository TransactionRepository => new TransactionRepository(this.DataContext);

		/// <summary>
		/// Репозиторий шагов транзакции.
		/// </summary>
		public ITransactonActionRepository TransactonActionRepository => new TransactonActionRepository(this.DataContext);

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		public IUserRepository UserRepository => new UserRepository(this.DataContext);

		/// <summary>
		/// Репозиторий кошельков.
		/// </summary>
		public IWalletRepository WalletRepository => new WalletRepository(this.DataContext);

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
	/// Админская единица работы. Чтоб не засорять основной сайт.
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
