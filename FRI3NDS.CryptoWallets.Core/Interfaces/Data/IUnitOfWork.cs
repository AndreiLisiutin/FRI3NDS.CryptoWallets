using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data
{
	/// <summary>
	/// Единица работы (Паттерн Unit of Work).
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		#region Repositories
		
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
