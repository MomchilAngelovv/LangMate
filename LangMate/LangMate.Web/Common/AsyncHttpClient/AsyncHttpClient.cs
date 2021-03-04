namespace LangMate.Web.Common.AsyncHttpClient
{
	using System;
	using System.Net.Http;
	using System.Text.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;

	public class AsyncHttpClient : IAsyncHttpClient
	{
		private readonly IHttpClientFactory httpClientFactory;

		public AsyncHttpClient(
			IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		public async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null)
		{
			var httpClient = this.httpClientFactory.CreateClient();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(url),
			};

			InsertHeadersInRequest(request, headers);

			using var response = await httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
			{
				//throw error maybe...
			}

			var dataModel = await MapResponseToModelAsync<T>(response);
			return dataModel;
		}

		public async Task<T> PostAsync<T>(string url, Dictionary<string, string> headers = null, Dictionary<string, string> bodyData = null, string contentType = "application/json")
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(url),
			};

			InsertHeadersInRequest(request, headers);

			if (bodyData != null)
			{
				request.Content = new FormUrlEncodedContent(bodyData);
			}

			using var response = await client.SendAsync(request);

			if (response.IsSuccessStatusCode == false)
			{
				//throw error maybe...
			}

			var dataModel = await MapResponseToModelAsync<T>(response);
			return dataModel;
		}

		private static void InsertHeadersInRequest(HttpRequestMessage request, Dictionary<string, string> headers)
		{
			if (headers != null)
			{
				foreach (var header in headers)
				{
					request.Headers.Add(header.Key, header.Value);
				}
			}
		}

		private static async Task<T> MapResponseToModelAsync<T>(HttpResponseMessage response)
		{
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
