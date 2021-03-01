using Microsoft.AspNetCore.Mvc;

namespace LangMate.Web.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Register()
		{
			return this.View();
		}

		public IActionResult Login()
		{
			return this.View();
		}

		[HttpPost]	
		public IActionResult Logout()
		{
			return this.View();
		}
	}
}
