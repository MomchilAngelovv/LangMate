using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Data.Models
{
	public class LangMateRole : IdentityRole<string>, IEntityMetaData
	{
		public LangMateRole()
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
