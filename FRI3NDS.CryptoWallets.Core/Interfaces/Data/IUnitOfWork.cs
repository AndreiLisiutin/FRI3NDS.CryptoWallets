using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin;
using System;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data
{
	/// <summary>
	/// Единица работы (Паттерн Unit of Work).
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		#region Repositories

		/// <summary>
		/// Репозиторий типов частоты оповещений.
		/// </summary>
		IAlertFrequencyRepository AlertFrequencyRepository { get; }

		/// <summary>
		/// Репозиторий оповещений.
		/// </summary>
		IAlertRepository AlertRepository { get; }

		/// <summary>
		/// Репозиторий вложений в документ (файлов).
		/// </summary>
		IAttachmentRepository AttachmentRepository { get; }

		/// <summary>
		/// Репозиторий сертификатов 1С пользователя.
		/// </summary>
		ICertificateRepository CertificateRepository { get; }

		/// <summary>
		/// Репозиторий статусов сертификатов.
		/// </summary>
		ICertificateStateRepository CertificateStateRepository { get; }

		/// <summary>
		/// Репозиторий типов сертификатов.
		/// </summary>
		ICertificateTypeRepository CertificateTypeRepository { get; }

		/// <summary>
		/// Репозиторий городов.
		/// </summary>
		ICityRepository CityRepository { get; }

		/// <summary>
		/// Репозиторий стран.
		/// </summary>
		ICountryRepository CountryRepository { get; }

		/// <summary>
		/// Репозиторий валют.
		/// </summary>
		ICurrencyRepository CurrencyRepository { get; }

		/// <summary>
		/// Репозиторий курсов валюты.
		/// </summary>
		ICurrencyRateRepository CurrencyRateRepository { get; }

		/// <summary>
		/// Репозиторий типов валют.
		/// </summary>
		ICurrencyTypeRepository CurrencyTypeRepository { get; }

		/// <summary>
		/// Репозиторий документов.
		/// </summary>
		IDocumentRepository DocumentRepository { get; }

		/// <summary>
		/// Репозиторий ЧаВо.
		/// </summary>
		IFaqRepository FaqRepository { get; }

		/// <summary>
		/// Репозиторий вопросов пользователя.
		/// </summary>
		IQuestionRepository QuestionRepository { get; }

		/// <summary>
		/// Репозиторий регионов.
		/// </summary>
		IRegionRepository RegionRepository { get; }

		/// <summary>
		/// Репозиторий транзакций.
		/// </summary>
		ITransactionRepository TransactionRepository { get; }

		/// <summary>
		/// Репозиторий шагов транзакции.
		/// </summary>
		ITransactonActionRepository TransactonActionRepository { get; }

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		IUserRepository UserRepository { get; }

		/// <summary>
		/// Репозиторий кошельков.
		/// </summary>
		IWalletRepository WalletRepository { get; }

		#endregion

		/// <summary>
		/// Открыть транзакцию.
		/// </summary>
		void BeginTransaction();

		/// <summary>
		/// Подтвердить транзакцию, если она открыта.
		/// </summary>
		void CommitTransaction();

		/// <summary>
		/// Откатить транзакцию, если она открыта.
		/// </summary>
		void RollbackTransaction();
	}

	public interface IAdminUnitOfWork : IUnitOfWork
	{
		#region Repositories


		I_DynamicRepository _DynamicRepository { get; }

		/// <summary>
		/// Репозиторий версий базы данных.
		/// </summary>
		I_VersionRepository _VersionRepository { get; }

		#endregion
	}
}
