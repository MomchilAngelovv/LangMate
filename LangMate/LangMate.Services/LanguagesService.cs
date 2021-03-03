using LangMate.Data;
using LangMate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Services
{
	public class LanguagesService : ILanguagesService
	{
		private readonly LangMateDbContext db;

		public LanguagesService(
			LangMateDbContext db)
		{
			this.db = db;
		}

		public async Task<int> CreateLanguagesAsync(List<string> languageAbbreviations)
		{
			var existinglanguageAbbreviations = this.db.Languages
				.Select(l => l.Name)
				.ToList();

			var newLanguages = new List<Language>();

			foreach (var languageAbbreviation in languageAbbreviations)
			{
				if (existinglanguageAbbreviations.Contains(languageAbbreviation) == false)
				{
					var language = new Language
					{
						Name = languageAbbreviation,
						IsoCode = languageAbbreviation.ToUpper()
					};

					newLanguages.Add(language);
				}
			}

			await this.db.Languages.AddRangeAsync(newLanguages);
			await this.db.SaveChangesAsync();

			return newLanguages.Count;
		}
	}
}
