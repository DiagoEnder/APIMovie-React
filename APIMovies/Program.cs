
using APIMovies.Models;
using APIMovies.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace APIMovies
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddCors(options =>
			{
			options.AddPolicy("AllowSpecificOrigin",
					builder => builder
							  .WithOrigins("http://localhost:3000")
							  .AllowAnyMethod()
							  .AllowAnyHeader()
							  .AllowCredentials());
							  
			});

			builder.Services.AddDbContext<ApplicationDbContext>(
				options => options.UseSqlServer(builder.Configuration.GetConnectionString("Movie")));

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(
				options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
				{
					options.SlidingExpiration = true;
					options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
				});

			builder.Services.AddControllers();

			builder.Services.AddTransient<TypesServices>();
			builder.Services.AddTransient<MoviesServices>();
			builder.Services.AddTransient<UsersServices>();
			builder.Services.AddTransient<CommentServices>();


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
					Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
				RequestPath = "/Photos"
			});

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			
			app.UseCors("AllowSpecificOrigin");
			app.MapControllers();

			app.Run();
		}
	}
}
