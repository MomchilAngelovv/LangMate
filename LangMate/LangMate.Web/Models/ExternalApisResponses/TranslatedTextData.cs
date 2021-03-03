namespace LangMate.Web.Models.ExternalApisResponses
{
	using System.Collections.Generic;

	public class TranslatedTextData
	{
		public ICollection<TranslatedTextDataTranslatedText> Translations { get; set; }
	}
}
