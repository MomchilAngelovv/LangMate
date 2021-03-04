namespace LangMate.Web.Models.Home
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class DashboardViewModel
	{
		public string TextFrom { get; set; }
		public string LanguageFrom { get; set; }
		[BindNever]
		public string TextTo { get; set; }
		public string LanguageTo { get; set; }
		public bool TranslateSuccess { get; set; }
	}
}
