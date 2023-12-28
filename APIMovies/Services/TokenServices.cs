using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace APIMovies.Services
{
	public class TokenServices
	{
		private readonly IConfiguration _configuration;
		public TokenServices(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GenerateToken(IdentityUser user, IList<string> roles)
		{
			var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier,user.Id),
			};

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var token = new JwtSecurityToken(
				_configuration["JwtSettings:Issuer"],
				_configuration["JwtSettings: Audience"],
				claims,
				expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings: DurationInMinutes"])),
				signingCredentials: credentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
