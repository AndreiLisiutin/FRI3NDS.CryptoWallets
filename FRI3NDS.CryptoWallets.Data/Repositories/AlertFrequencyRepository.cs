using AutoMapper;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Data.UnitOfWork;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data.Repositories
{
	/// <summary>
	/// Репозиторий типов частоты оповещений.
	/// </summary>
	public class AlertFrequencyRepository : RepositoryBase<AlertFrequency>, IAlertFrequencyRepository
	{
		private static List<AlertFrequency> _list = new List<AlertFrequency>()
		{
			new AlertFrequency()
			{
				AlertFrequencyId = 1,
				Name = "Один раз"
			},
			new AlertFrequency()
			{
				AlertFrequencyId = 2,
				Name = "Всегда"
			}
		};

		public AlertFrequencyRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns></returns>
		public AlertFrequency GetById(int id)
		{
			return _list.FirstOrDefault(e => e.AlertFrequencyId == id);
		}

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns></returns>
		public List<AlertFrequency> Get()
		{
			return _list;
		}
	}
}
