namespace LangMate.Web.Common.AsyncHttpClient
{
	using System.Threading.Tasks;
	using System.Collections.Generic;

	public interface IAsyncHttpClient
	{
		public Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null);
		public Task<T> PostAsync<T>(string url, Dictionary<string, string> headers = null, Dictionary<string, string> bodyData = null, string contentType = "application/json");
	}
}
