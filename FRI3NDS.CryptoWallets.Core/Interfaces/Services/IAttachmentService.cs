using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Services
{
	/// <summary>
	/// Сервис вложений в документ.
	/// </summary>
	public interface IAttachmentService
	{
		/// <summary>
		/// Получить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Вложение в документ (файл), найденное по идентификатору.</returns>
		Attachment GetById(Guid id);

		/// <summary>
		/// Получить список вложений в документ.
		/// </summary>
		/// <returns>Список вложений в документ.</returns>
		List<Attachment> Get();

		/// <summary>
		/// Сохранить вложение в документ.
		/// </summary>
		/// <param name="attachment">Сохраняемое вложение в документ.</param>
		/// <returns>Сохраненное вложение в документ с заполненным идентификатором</returns>
		Guid Save(AttachmentBase attachment);

		/// <summary>
		/// Удалить вложение в документ по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор вложения в документ.</param>
		void Delete(Guid id);
	}
}
