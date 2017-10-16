using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
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
				ClaimsIdentity identity = User.Identity as ClaimsIdentity;
				if (identity.HasClaim(c => c.Type == ClaimTypes.NameIdentifier)
					&& Guid.TryParse(identity.FindFirst(ClaimTypes.NameIdentifier).Value, out Guid id))
				{
					return id;
				}
			}
			throw new InvalidOperationException("Пользователь не авторизован.");
		}
	}
}
