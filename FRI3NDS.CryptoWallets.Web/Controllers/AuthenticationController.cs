using FRI3NDS.CryptoWallets.Core.Models.Domain;
using FRI3NDS.CryptoWallets.Utils;
using FRI3NDS.CryptoWallets.Web.Infrastructure;
using FRI3NDS.CryptoWallets.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с аутентификацией и учетными записями пользователей.
	/// </summary>
	[Route("api/Authentication")]
	public class AuthenticationController : ControllerBase
	{
		IHubContext<ChatHub> _context;
		/// <summary>
		/// Конструктор контроллера для работы с аутентификацией и учетными записями пользователей.
		/// </summary>
		public AuthenticationController(IStringLocalizer localizer, IHubContext<ChatHub> context)
		{
			this._context = context;
			var hello = localizer["HELLO", "world"];
		}

		/// <summary>
		/// Действие входа в приложение, получение токена доступа.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		/// <returns>Информация о токене доступа.</returns>
		[Route("GetToken")]
		[HttpPost]
		public TokenInfo GetToken([FromBody]UserLoginModel user)
		{
			this._context.Clients.All.InvokeAsync("Send", "hello");


			UserBase existUser = new UserBase() { Login = user.Login, UserId = Guid.NewGuid() };
			Argument.Require(existUser != null, "Введенные данные пользователя не верны.");
			TokenInfo token = this._GenerateToken(existUser);
			return token;
		}

		/// <summary>
		/// Обновление токена доступа.
		/// </summary>
		/// <param name="refreshTokenRequest">Данные о токене обновления токенов.</param>
		/// <returns>Информация о новом токене доступа.</returns>
		[Route("RefreshToken")]
		[HttpPost]
		public TokenInfo RefreshToken([FromBody]RefreshTokenModel refreshTokenRequest)
		{
			Argument.Require(refreshTokenRequest?.RefreshToken != null, "Некорректный запрос, пустой токен обновления токенов.");

			var handler = new JwtSecurityTokenHandler();
			SecurityToken validatedToken;
			var person = handler.ValidateToken(refreshTokenRequest.RefreshToken, TokenAuthenticationOptions.Parameters, out validatedToken);
			var userId = Guid.Parse(person.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
			Argument.Require(userId == refreshTokenRequest.UserId, "Пользователь токена некорректный.");
			UserBase user = new UserBase() { UserId = userId, Login = "tokenRefreshed" };
			var token = _GenerateToken(user);
			return token;
		}

		/// <summary>
		/// Выход из приложение, очистка токена.
		/// </summary>
		/// <returns>Ничего интересного.</returns>
		[Route("ClearAuthToken")]
		[HttpPost]
		public StatusCodeResult ClearAuthToken()
		{
			//даже не нужно, скорее всего
			return Ok();
		}

		/// <summary>
		/// Зарегистрироваться в системе.
		/// </summary>
		/// <param name="user">Данные для создания пользователя.</param>
		/// <returns>Информация о токене доступа.</returns>
		[Route("SignUp")]
		[HttpPost]
		public TokenInfo Registrer([FromBody]UserLoginModel user)
		{
			UserBase existUser = new UserBase() { Login = "andrey", Email = "lisutin.andrey@gmail.com" };
			TokenInfo token = this._GenerateToken(existUser);
			return token;
		}

		/// <summary>
		/// Сгенерировать токен доступа.
		/// </summary>
		/// <param name="user">Пользователь системы.</param>
		/// <returns>Информация о сгенерированном токене.</returns>
		private TokenInfo _GenerateToken(UserBase user)
		{
			var handler = new JwtSecurityTokenHandler();
			var createdOn = DateTime.Now;
			var expiresOn = createdOn + TokenAuthenticationOptions.ExpiresSpan;

			ClaimsIdentity identity = CreateClaimsIdentity(user);
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = TokenAuthenticationOptions.Issuer,
				Audience = TokenAuthenticationOptions.Audience,
				SigningCredentials = TokenAuthenticationOptions.SigningCredentials,
				Subject = identity,
				Expires = expiresOn,
				IssuedAt = createdOn,
				NotBefore = DateTime.Now
			});

			var token = handler.WriteToken(securityToken);

			SecurityToken validatedToken;
			var result = handler.ValidateToken(token, new TokenValidationParameters()
			{
				IssuerSigningKey = TokenAuthenticationOptions.Key,
				ValidAudience = TokenAuthenticationOptions.Audience,
				ValidIssuer = TokenAuthenticationOptions.Issuer,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateIssuerSigningKey = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.FromMinutes(0)
			}, out validatedToken);


			var refreshToken = _GenerateRefreshToken(user);
			return new TokenInfo()
			{
				CreatedOn = createdOn,
				ExpiresOn = expiresOn,
				Token = token,
				RefreshToken = refreshToken,
				TokenType = TokenAuthenticationOptions.TokenType
			};
		}

		private string _GenerateRefreshToken(UserBase user)
		{
			var handler = new JwtSecurityTokenHandler();
			var createdOn = DateTime.Now;
			var expiresOn = createdOn + TokenAuthenticationOptions.RefreshExpiresSpan;

			ClaimsIdentity identity = CreateClaimsIdentity(user);
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = TokenAuthenticationOptions.Issuer,
				Audience = TokenAuthenticationOptions.Audience,
				SigningCredentials = TokenAuthenticationOptions.SigningCredentials,
				Subject = identity,
				Expires = expiresOn,
				IssuedAt = createdOn,
				NotBefore = DateTime.Now
			});

			var token = handler.WriteToken(securityToken);

			return token;
		}

		/// <summary>
		/// Тестовое действие - вернуть имя пользователя.
		/// </summary>
		/// <returns>Имя пользователя.</returns>
		[Route("Test")]
		[HttpGet]
		[Authorize]
		public UserBase GetUserInfo()
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			return new UserBase() { Login = claimsIdentity.Name };
		}
	}

}
