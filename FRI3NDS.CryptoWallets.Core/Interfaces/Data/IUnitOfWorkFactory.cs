using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data
{
	/// <summary>
	/// Фабрика единиц работы.
	/// </summary>
	public interface IUnitOfWorkFactory
	{
		/// <summary>
		/// Создать новую единицу работы с заданной конфигурацией.
		/// </summary>
		/// <returns>Экземпляр единицы работы.</returns>
		IUnitOfWork Create();

		/// <summary>
		/// Создать новую единицу работы с заданной конфигурацией.
		/// </summary>
		/// <returns>Экземпляр единицы работы.</returns>
		IAdminUnitOfWork CreateAdmin();
	}
}
