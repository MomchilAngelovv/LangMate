namespace LangMate.Web.Controllers
{
	using LangMate.Services;
	using LangMate.Web.Common.AsyncHttpClient;
	using LangMate.Web.Models.ExternalApisResponses;
	using LangMate.Web.Models.Home;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private readonly IAsyncHttpClient httpClient;
		private readonly IAuthService authService;

		public HomeController(
			ILogger<HomeController> logger,
			IAsyncHttpClient httpClient,
			IAuthService authService)
		{
			this.logger = logger;
			this.httpClient = httpClient;
			this.authService = authService;
		}

		[HttpGet]
		public IActionResult Dashboard()
		{
			var viewModel = new DashboardViewModel();
			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Dashboard(DashboardViewModel viewModel)
		{
			var rapidApiAuthHeaders = this.authService.GetRapidApiAuthHeaders();
			var requestData = new Dictionary<string, string>
			{
				["q"] = viewModel.TextFrom,
				["source"] = viewModel.LanguageFrom,
				["target"] = viewModel.LanguageTo
			};

			var translatedTextResponse = await this.httpClient.PostAsync<TranslatedTextResponseModel>("https://google-translate1.p.rapidapi.com/language/translate/v2", rapidApiAuthHeaders, requestData);

			viewModel.TextTo = translatedTextResponse.Data.Translations.ToList().First().TranslatedText;
			viewModel.TranslateSuccess = true;
			return this.View(viewModel);
		}
	}
}
