using System;

namespace LangMate.Data.Models
{
	public class Language : IEntityMetaData
	{
		public Language()
		{
			this.CreatedOn = DateTime.UtcNow;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string IsoCode { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime? LastModiefiedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string Information { get; set; }
	}
}
