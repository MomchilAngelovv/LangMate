namespace LangMate.Web.Controllers
{
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Identity;

	using LangMate.Web.Common;
	using LangMate.Data.Models;
	using LangMate.Web.Models.Users;

	public class UsersController : Controller
	{
		private readonly UserManager<LangMateUser> userManager;
		private readonly SignInManager<LangMateUser> signInManager;

		public UsersController(
			UserManager<LangMateUser> userManager,
			SignInManager<LangMateUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return this.View();
		}
		[HttpGet]
		public IActionResult Login()
		{
			return this.View();
		}
		[HttpGet]
		public IActionResult Profile()
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

			await this.userManager.AddToRoleAsync(newUser, GlobalConstants.Roles.User);
            return this.RedirectToAction(nameof(Login));
        }
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			if (ModelState.IsValid == false)
			{
				return this.View(viewModel);
			}

			var result = await signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, true);

			if (result.Succeeded == false)
			{
				TempData[GlobalConstants.Errors.InvalidLoginCredentials] = GlobalConstants.Errors.InvalidLoginCredentials;
				return this.View();
			}

			return this.Redirect("/Home/Index");
		}
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
	}
}
