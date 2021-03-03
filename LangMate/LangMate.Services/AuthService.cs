using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Services
{
	public class AuthService : IAuthService
	{
		public Dictionary<string, string> GetRapidApiAuthHeaders()
		{
			var authHeaders = new Dictionary<string, string>
			{
				["x-rapidapi-key"] = "6c01749c84mshd87345a43cae61cp18b915jsne8b54cbda4ce",
				["x-rapidapi-host"] = "google-translate1.p.rapidapi.com"
			};

			return authHeaders;
		}
	}
}
