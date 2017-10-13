using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Сервис оповещений.
	/// </summary>
	public class AlertService : ServiceBase, IAlertService
	{
		public AlertService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		/// <returns>Оповешение.</returns>
		public Alert GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AlertRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список оповещений.
		/// </summary>
		/// <returns></returns>
		public List<Alert> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AlertRepository.Get();
			}
		}

		/// <summary>
		/// Сохренить оповещение.
		/// </summary>
		/// <param name="alert">Сохраняемое оповещение.</param>
		/// <returns>Сохраненное оповещение с заполненным идентификатором</returns>
		public Guid Save(AlertBase alert)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AlertRepository.Save(alert);
			}
		}

		/// <summary>
		/// Удалить оповещение по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор оповещения.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.AlertRepository.Delete(id);
			}
		}
	}
}
