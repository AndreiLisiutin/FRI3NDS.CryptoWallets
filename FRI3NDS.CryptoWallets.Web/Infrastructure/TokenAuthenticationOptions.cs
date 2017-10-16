using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace FRI3NDS.CryptoWallets.Web.Infrastructure
{
	/// <summary>
	/// Опции аутентификации по токену.
	/// </summary>
	public class TokenAuthenticationOptions
	{
		private static Lazy<RsaSecurityKey> _Key => new Lazy<RsaSecurityKey>(() =>
		{
			using (var key = new RSACryptoServiceProvider(2048))
			{
				return new RsaSecurityKey(key.ExportParameters(true));
			}
		});
		public static string Audience { get; } = "ExampleAudience";
		public static string Issuer { get; } = "ExampleIssuer";
		public static RsaSecurityKey Key { get; } = _Key.Value;
		public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

		public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(1);
		public static TimeSpan RefreshExpiresSpan { get; } = TimeSpan.FromDays(30);
		public static string TokenType { get; } = "Bearer";

		/// <summary>
		/// Параметры аутентификации по токену.
		/// </summary>
		public static TokenValidationParameters Parameters =>
			new TokenValidationParameters()
			{
				IssuerSigningKey = TokenAuthenticationOptions.Key,
				ValidAudience = TokenAuthenticationOptions.Audience,
				ValidIssuer = TokenAuthenticationOptions.Issuer,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateIssuerSigningKey = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.FromMinutes(0)
			};
	}
}
