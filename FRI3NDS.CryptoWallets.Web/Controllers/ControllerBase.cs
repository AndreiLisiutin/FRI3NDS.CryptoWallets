using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace FRI3NDS.CryptoWallets.Web.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ControllerBase : Controller
	{

	}
}
