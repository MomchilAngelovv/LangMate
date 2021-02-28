using LangMate.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangMate.Data
{
	public class LangMateDbContext : IdentityDbContext<LangMateUser, LangMateRole, string>
	{
		public LangMateDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
