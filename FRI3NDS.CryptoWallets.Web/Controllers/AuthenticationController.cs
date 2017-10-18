using FRI3NDS.CryptoWallets.Core.Interfaces.Services;
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
using System.Security.Claims;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с аутентификацией и учетными записями пользователей.
	/// </summary>
	[Route("api/Authentication")]
	public class AuthenticationController : ControllerBase
	{
		/// <summary>
		/// Сервис работы с пользователями.
		/// </summary>
		protected IUserService UserService { get; private set; }

		/// <summary>
		/// Конструктор контроллера для работы с аутентификацией и учетными записями пользователей.
		/// </summary>
		public AuthenticationController(IUserService userService, IStringLocalizer localizer, IHubContext<ChatHub> context)
			: base(localizer)
		{
			this.UserService = userService;
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
			Argument.Require(user != null, Localizer["ERROR_ARGUMENT_NULL", nameof(user)]);
			UserBase existUser = UserService.VerifyUser(user.Login, user.Password);
			Argument.Require(existUser != null, Localizer["User.Error.InvalidCredentials"]);
			TokenInfo token = _GenerateToken(existUser);
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
			Argument.Require(refreshTokenRequest?.RefreshToken != null, Localizer["ERROR_ARGUMENT_NULL", nameof(refreshTokenRequest)]);

			var handler = new JwtSecurityTokenHandler();
			var person = handler.ValidateToken(refreshTokenRequest.RefreshToken, TokenAuthenticationOptions.Parameters, out SecurityToken validatedToken);
			var userId = GetUserId(person);
			Argument.Require(userId.HasValue && userId == refreshTokenRequest.UserId, Localizer["User.Error.TokenUserInvalid"]);

			UserBase user = UserService.GetById(userId.Value);
			Argument.Require(user != null, Localizer["ERROR_NOT_FOUND", Localizer["User"]]);
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
			Argument.Require(user != null, Localizer["ERROR_ARGUMENT_NULL", nameof(user)]);
			UserBase newUser = new UserBase()
			{
				Login = user.Login,
				Email = user.Email,
				PasswordHash = user.Password
			};
			newUser = UserService.CreateUser(newUser);
			TokenInfo token = this._GenerateToken(newUser);
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

			var refreshToken = _GenerateRefreshToken(user);
			return new TokenInfo()
			{
				UserId = user.UserId,
				CreatedOn = createdOn,
				ExpiresOn = expiresOn,
				Token = token,
				RefreshToken = refreshToken,
				TokenType = TokenAuthenticationOptions.TokenType
			};
		}

		/// <summary>
		/// Сгенерить токен обновления токенов.
		/// </summary>
		/// <param name="user">Пользователь.</param>
		/// <returns>Токен обновления токенов.</returns>
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
