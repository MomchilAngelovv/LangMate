using LangMate.Data.Models;
using LangMate.Web.Common;
using LangMate.Web.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LangMate.Web.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserManager<LangMateUser> userManager;

		public UsersController(UserManager<LangMateUser> userManager)
		{
			this.userManager = userManager;
		}

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
		[HttpPost] 
		public async Task<IActionResult> Register(RegisterViewModel viewModel)
		{
            if (ModelState.IsValid == false)
            {
                return this.View(viewModel);
            }

            var userByEmail = await userManager.FindByEmailAsync(viewModel.Email);

            if (userByEmail != null)
            {
				TempData[GlobalConstants.Errors.UserAlreadyExists] = GlobalConstants.Errors.UserAlreadyExists;
                return this.View(viewModel);
            }

            var newUser = new LangMateUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
            };

            var result = await userManager.CreateAsync(newUser, viewModel.Password);

            if (result.Succeeded == false)
            {
                return this.View(viewModel);
            }

            return this.RedirectToAction(nameof(Login));
        }
	}
}
