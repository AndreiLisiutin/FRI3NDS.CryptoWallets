using FRI3NDS.CryptoWallets.Core.Interfaces.Data;
using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
using FRI3NDS.CryptoWallets.Core.Models.Domain;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace FRI3NDS.CryptoWallets.Core.Services
{
    /// <summary>
    /// Репозиторий стран.
    /// </summary>
    public class CountryService : ServiceBase, ICountryService
    {
        public CountryService(IUnitOfWorkFactory unitOfWorkFactory, IStringLocalizer localizer)
            : base(unitOfWorkFactory, localizer)
        {
        }

        /// <summary>
        /// Получить страну по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор страны.</param>
        /// <returns>Страна, найденная по ее идентификатору.</returns>
        public Country GetById(Guid id)
        {
            using (var uow = CreateUnitOfWork())
            {
                return uow.CountryRepository.GetById(id);
            }
        }

        /// <summary>
        /// Получить список стран.
        /// </summary>
        /// <returns>Список стран.</returns>
        public List<Country> Get()
        {
            using (var uow = CreateUnitOfWork())
            {
                return uow.CountryRepository.Get();
            }
        }
    }
}
