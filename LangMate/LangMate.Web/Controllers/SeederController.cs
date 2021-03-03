using LangMate.Web.Common.AsyncHttpClient;
using LangMate.Web.Models.ExternalApisResponses;
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
		private readonly IAsyncHttpClient httpClient;

		public SeederController(IAsyncHttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		[HttpPost]
		public async Task<IActionResult> Languages()
		{
			var languages = await this.httpClient.GetAsync<LanguagesResponseModel>("https://google-translate1.p.rapidapi.com/language/translate/v2/languages");
			return this.Ok();
		}
	}
}
