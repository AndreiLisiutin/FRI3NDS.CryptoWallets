using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Cors;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Базовый контроллер.
	/// </summary>
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ControllerBase : Controller
	{
        /// <summary>
        /// Сервис локализации.
        /// </summary>
        protected IStringLocalizer Localizer { get; set; }

        public ControllerBase()
        {
        }

        /// <summary>
        /// Базовый контроллер.
        /// </summary>
        /// <param name="localizer">Сервис локализации.</param>
        public ControllerBase(IStringLocalizer localizer)
        {
            this.Localizer = localizer;
        }

		/// <summary>
		/// Создать слепок данных о пользователе для его токена.
		/// </summary>
		/// <param name="user">Модель пользователя.</param>
		/// <returns>Модель пользователя для токена.</returns>
		protected ClaimsIdentity CreateClaimsIdentity(UserBase user)
		{
			return new ClaimsIdentity(
				new GenericIdentity(user.Login, "TokenAuth"),
				new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString(), ClaimValueTypes.Integer32, TokenAuthenticationOptions.Issuer, TokenAuthenticationOptions.Issuer),
					new Claim(ClaimTypes.Name, user.Login, ClaimValueTypes.String, TokenAuthenticationOptions.Issuer, TokenAuthenticationOptions.Issuer)
				}
			);
		}

		/// <summary>
		/// Получить идентификатор пользователя, вошедшего в систему.
		/// </summary>
		protected Guid GetCurrentUserId()
		{
			if (User.Identity.IsAuthenticated)
			{
                Guid? userId = GetUserId(User);
                if ((userId ?? default(Guid)) != default(Guid))
                {
                    return userId.Value;
                }
			}
			throw new InvalidOperationException("Пользователь не авторизован.");
		}

        /// <summary>
        /// Получить идентификатор пользователя из модели Principal пользователя.
        /// </summary>
        /// <param name="claimsPrincipal">Модель Principal пользователя.</param>
        /// <returns>Идентификатор пользователя.</returns>
        protected Guid? GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier)
                    && Guid.TryParse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value, out Guid id))
            {
                return id;
            }
            return null;
        }
	}
}
