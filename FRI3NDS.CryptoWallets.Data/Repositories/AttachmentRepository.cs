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
	/// Репозиторий вложений в документ.
	/// </summary>
	public class AttachmentRepository : RepositoryBase<AttachmentBase>, IAttachmentRepository
	{
		private static FakeStore<AttachmentBase, Attachment> store = new FakeStore<AttachmentBase, Attachment>();

		public AttachmentRepository(DataContext dataContext)
			: base(dataContext)
		{
		}

		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		public Attachment GetById(Guid id)
		{
			return store.GetById(id);
		}

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <returns>Список вложений в документ.</returns>
		public List<Attachment> Get()
		{
			return store.Get();
		}

		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		public Guid Save(AttachmentBase attachment)
		{
			return store.Save(attachment).AttachmentId;
		}

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		public void Delete(Guid id)
		{
			store.Delete(id);
		}
	}
}
