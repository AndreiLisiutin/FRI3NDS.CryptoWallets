using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Сервис оповещений.
	/// </summary>
	public class AttachmentService : ServiceBase, IAttachmentService
	{
		public AttachmentService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		public Attachment GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AttachmentRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <returns>Список вложений в документ.</returns>
		public List<Attachment> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AttachmentRepository.Get();
			}
		}

		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		public Guid Save(AttachmentBase attachment)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.AttachmentRepository.Save(attachment);
			}
		}

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		public void Delete(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				uow.AttachmentRepository.Delete(id);
			}
		}
	}
}
