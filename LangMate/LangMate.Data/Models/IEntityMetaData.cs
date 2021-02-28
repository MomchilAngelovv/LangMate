using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Data.Models
{
	public interface IEntityMetaData
	{
		public DateTime CreatedOn { get; set; }
		public DateTime? LastModiefiedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
		public string Information { get; set; }
	}
}
