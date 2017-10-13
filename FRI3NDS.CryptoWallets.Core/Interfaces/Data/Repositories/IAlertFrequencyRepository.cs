﻿using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories
{
	/// <summary>
	/// Репозиторий типов частоты оповещений.
	/// </summary>
	public interface IAlertFrequencyRepository: IRepositoryBase<AlertFrequency>
	{
		/// <summary>
		/// Получить тип частоты оповещений по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns></returns>
		AlertFrequency GetById(int id);

		/// <summary>
		/// Получить список типов частоты оповещений.
		/// </summary>
		/// <returns></returns>
		List<AlertFrequency> Get();
	}
}