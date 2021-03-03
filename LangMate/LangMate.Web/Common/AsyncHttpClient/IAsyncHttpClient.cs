using System.Collections.Generic;
using System.Threading.Tasks;

namespace LangMate.Web.Common.AsyncHttpClient
{
	public interface IAsyncHttpClient
	{
		public Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null);
	}
}
