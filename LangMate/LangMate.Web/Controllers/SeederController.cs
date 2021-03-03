using LangMate.Data.Models;
using LangMate.Services;
using LangMate.Web.Common;
using LangMate.Web.Common.AsyncHttpClient;
using LangMate.Web.Models.ExternalApisResponses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LangMate.Web.Controllers
{
	public class SeederController : Controller
	{
		private readonly UserManager<LangMateUser> userManager;
		private readonly RoleManager<LangMateRole> roleManager;
		private readonly IAsyncHttpClient httpClient;
		private readonly ILanguagesService languagesService;
		private readonly IAuthService authService;

		public SeederController(
			UserManager<LangMateUser> userManager,
			RoleManager<LangMateRole> roleManager,
			IAsyncHttpClient httpClient,
			ILanguagesService languagesService,
			IAuthService authService)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.httpClient = httpClient;
			this.languagesService = languagesService;
			this.authService = authService;
		}

		[HttpPost]
		public async Task<IActionResult> Languages()
		{
			var rapidApiAuthHeaders = this.authService.GetRapidApiAuthHeaders();

			var languages = await this.httpClient
				.GetAsync<LanguagesResponseModel>("https://google-translate1.p.rapidapi.com/language/translate/v2/languages", rapidApiAuthHeaders);

			var languageAbbreviations = languages.Data.Languages
				.Select(l => l.Language)
				.ToList();

			await this.languagesService.CreateLanguagesAsync(languageAbbreviations);
			return this.Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Roles()
		{
			if (this.roleManager.Roles.Any() == false)
			{
				var adminRole = new LangMateRole
				{
					Name = GlobalConstants.Roles.Administrator
				};

				var userRole = new LangMateRole
				{
					Name = GlobalConstants.Roles.User
				};

				await this.roleManager.CreateAsync(adminRole);
				await this.roleManager.CreateAsync(userRole);

				var adminUser = await this.userManager.FindByEmailAsync("MomchilAngelov0040@gmail.com");
				await this.userManager.AddToRoleAsync(adminUser, GlobalConstants.Roles.Administrator);
			}
			
			return this.Ok();
		}
	}
}
