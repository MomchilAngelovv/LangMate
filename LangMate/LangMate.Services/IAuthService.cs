using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Services
{
	public interface IAuthService
	{
		public Dictionary<string, string> GetRapidApiAuthHeaders();
	}
}
