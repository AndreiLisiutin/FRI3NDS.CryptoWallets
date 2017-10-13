using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
	/// <summary>
	/// Репозиторий городов.
	/// </summary>
	public class CityService : ServiceBase, ICityService
	{
		public CityService(IUnitOfWorkFactory unitOfWorkFactory)
			: base(unitOfWorkFactory)
		{
		}

		/// <summary>
		/// Получить город по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор города.</param>
		/// <returns>Город, найденный по его идентификатору.</returns>
		public City GetById(Guid id)
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CityRepository.GetById(id);
			}
		}

		/// <summary>
		/// Получить список городов.
		/// </summary>
		/// <returns>Список городов.</returns>
		public List<City> Get()
		{
			using (var uow = this.CreateUnitOfWork())
			{
				return uow.CityRepository.Get();
			}
		}
	}
}
