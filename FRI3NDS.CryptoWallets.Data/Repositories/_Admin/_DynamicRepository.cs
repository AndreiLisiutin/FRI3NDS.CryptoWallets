using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories._Admin
{
	public class _DynamicRepository : UnsafeRepositoryBase, I_DynamicRepository
	{
		/// <summary>
		/// Конструктор репозитория.
		/// </summary>
		/// <param name="dataContext">Контекст данных (подключение к базе и транзакция).</param>
		public _DynamicRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Сделать что-то страшное.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public List<IDictionary<string, object>> Sql(string query, object parameters = null)
		{
			return this._ExecuteQuery(query);
		}
	}
}
