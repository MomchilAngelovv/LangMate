namespace LangMate.Web.Models.Home
{
	public class DashboardViewModel
	{
		public string TextFrom { get; set; }
		public string LanguageFrom { get; set; }
		public string TextTo { get; set; }
		public string LanguageTo { get; set; }
		public bool TranslateSuccess { get; set; }
	}
}
