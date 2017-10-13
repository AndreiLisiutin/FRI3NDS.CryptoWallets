using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	/// <summary>
	/// Базовый контроллер.
	/// </summary>
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ControllerBase : Controller
	{

	}
}
