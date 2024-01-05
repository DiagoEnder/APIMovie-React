
using APIMovies.Models;
using APIMovies.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

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
			//jwt
			builder.Services.AddIdentity<IdentityUser,IdentityRole>(	
						options =>
							{
								options.Password.RequireDigit = true;
								options.Password.RequireUppercase = true;
								options.Password.RequireLowercase = true;
								options.Password.RequiredLength = 6;
								options.Password.RequireNonAlphanumeric = true;
								options.Password.RequiredUniqueChars = 4;
							}
						).AddEntityFrameworkStores<ApplicationDbContext>()
							.AddDefaultTokenProviders();
			var jwtSettings = builder.Configuration.GetSection("JwtSettings");
			var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);


			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
			//builder.Services.AddIdentity<IdentityUser, IdentityRole>(
			//	options => options.SignIn.RequireConfirmedAccount = true)
			//	.AddEntityFrameworkStores<ApplicationDbContext>();

			//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			//	.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
			//	{
			//		options.SlidingExpiration = true;
			//		options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
			//	});

			builder.Services.AddControllers();

			builder.Services.AddTransient<TypesServices>();
			builder.Services.AddTransient<MoviesServices>();
			builder.Services.AddTransient<UsersServices>();
			builder.Services.AddTransient<CommentServices>();
			builder.Services.AddTransient<TokenServices>();
			builder.Services.AddTransient<UserServices>();


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//Log.Logger = new LoggerConfiguration()
			//	.MinimumLevel.Information()
			//	.WriteTo.Console()
			//	.WriteTo.File("logs/mylogtest-.txt", rollingInterval: RollingInterval.Day)
			//	.CreateLogger();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.ReadFrom.Configuration(builder.Configuration).CreateLogger();

			builder.Host.UseSerilog();
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
			app.UseSerilogRequestLogging();
			
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			
			app.UseCors("AllowSpecificOrigin");
			app.MapControllers();

			app.Run();
		}
	}
}
