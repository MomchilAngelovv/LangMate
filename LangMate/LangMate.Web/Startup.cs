namespace LangMate.Web
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.Hosting;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using LangMate.Data;
	using LangMate.Data.Models;
	using LangMate.Web.Common.AsyncHttpClient;

	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(
			IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			//Database
			services.AddDbContext<LangMateDbContext>(options =>
			{
				options.UseSqlServer(this.configuration.GetConnectionString("SqlConnectionString"));
			});

			//Identity
			services.AddIdentity<LangMateUser, LangMateRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 0;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;

				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;
			})
			.AddEntityFrameworkStores<LangMateDbContext>()
			.AddDefaultTokenProviders();

			//Login and Access options
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Users/Login";
				options.AccessDeniedPath = "/Home/AccessDenied";
			});

			//MVC options
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddHttpClient();

			//Services
			services.AddTransient<IAsyncHttpClient, AsyncHttpClient>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
