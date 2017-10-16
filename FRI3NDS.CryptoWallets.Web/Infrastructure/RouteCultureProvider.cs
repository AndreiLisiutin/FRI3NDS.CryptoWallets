using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Web.Infrastructure
{
	/// <summary>
	/// Провайдер настройки локализации потока запроса.
	/// </summary>
	public class RouteCultureProvider : IRequestCultureProvider
	{
		private CultureInfo _defaultCulture;

		/// <summary>
		/// Заголовок запроса, передающий язык запроса.
		/// </summary>
		private const string LANGUAGE_HEADER = "Language";

		/// <summary>
		/// Провайдер настройки локализации потока запроса.
		/// </summary>
		/// <param name="requestCulture">Локаль по умолчанию.</param>
		public RouteCultureProvider(RequestCulture requestCulture)
		{
			this._defaultCulture = requestCulture.Culture;
		}

		/// <summary>
		/// Определить язык потока запроса.
		/// </summary>
		/// <param name="httpContext">Контекст запроса.</param>
		/// <returns>Язык запроса в задаче.</returns>
		public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
		{
			string culture = _defaultCulture.ToString();
			if (httpContext.Request.Headers.ContainsKey(LANGUAGE_HEADER))
			{
				culture = httpContext.Request.Headers[LANGUAGE_HEADER];
			}
			return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(culture, culture));
		}
	}
}
