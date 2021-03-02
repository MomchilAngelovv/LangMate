namespace LangMate.Data.Models
{
	using System;

	using Microsoft.AspNetCore.Identity;

	public class LangMateUser : IdentityUser<string>, IEntityMetaData
	{
		public LangMateUser()
		{
			this.Id = Guid.NewGuid().ToString("N");
			this.CreatedOn = DateTime.UtcNow;
		}

		public DateTime CreatedOn { get; set; }
		public DateTime? LastModiefiedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string Information { get; set; }
	}
}
