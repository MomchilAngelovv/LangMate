using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LangMate.Web.Common.AsyncHttpClient
{
	public class AsyncHttpClient : IAsyncHttpClient
	{
		private readonly IHttpClientFactory httpClientFactory;

		public AsyncHttpClient(
			IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		public async Task<T> GetAsync<T>(string url, Dictionary<string,string> headers = null)
		{
            var httpClient = this.httpClientFactory.CreateClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "6c01749c84mshd87345a43cae61cp18b915jsne8b54cbda4ce" },
                    { "x-rapidapi-host", "google-translate1.p.rapidapi.com" },
                },
            };

			if (headers != null)
			{
				foreach (var header in headers)
				{
					request.Headers.Add(header.Key, header.Value);
				}
			}

			using var response = await httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
			{
				//throw error maybe...
			}

			var responseBody = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				AllowTrailingCommas = true,
				PropertyNameCaseInsensitive = true,
			};

			var mappedData = JsonSerializer.Deserialize<T>(responseBody, options);
			return mappedData;
		}
	}
}
