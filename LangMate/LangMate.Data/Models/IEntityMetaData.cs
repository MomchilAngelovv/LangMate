namespace LangMate.Data.Models
{
	using System;

	public interface IEntityMetaData
	{
		public DateTime CreatedOn { get; set; }
		public DateTime? LastModiefiedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string Information { get; set; }
	}
}
