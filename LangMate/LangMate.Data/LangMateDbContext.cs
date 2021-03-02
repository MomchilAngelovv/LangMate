namespace LangMate.Data
{
	using LangMate.Data.Models;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

	public class LangMateDbContext : IdentityDbContext<LangMateUser, LangMateRole, string>
	{
		public LangMateDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
