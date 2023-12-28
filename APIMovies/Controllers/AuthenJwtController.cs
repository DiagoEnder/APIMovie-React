using APIMovies.Models;
using APIMovies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenJwtController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly TokenServices _tokenServices;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthenJwtController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenServices tokenServices, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenServices = tokenServices;
			_roleManager = roleManager;
		}

		[HttpPost]
		[Route("register-admin")]
		public async Task<IActionResult> RegisTerAdmin([FromBody] UserDetails userDetails)
		{
			var userExists = await _userManager.FindByNameAsync(userDetails.UserName);

			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
								new Models.Response { Status = "Error", Message = "User đã có trong hệ thống" });
			}

			var identityUser = new IdentityUser()
			{
				UserName = userDetails.UserName,
				Email = userDetails.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
			};

			var result = await _userManager.CreateAsync(identityUser, userDetails.Password);


			if (!result.Succeeded)
				return StatusCode(StatusCodes.Status500InternalServerError,
					new Models.Response { Status = "Error", Message = "Co loi khi tao User! Kiem tra va thu lai." });
			if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
				await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
			if (!await _roleManager.RoleExistsAsync(UserRoles.User))
				await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
			if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _userManager.AddToRoleAsync(identityUser, UserRoles.Admin);
			}
			if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _userManager.AddToRoleAsync(identityUser, UserRoles.User);
			}


			return Ok(new Models.Response { Status = "Success", Message = "User dc tao thanh cong!" });

		}

		[HttpPost]
		[Route("register-User")]
		public async Task<IActionResult> RegisTerUser([FromBody] UserDetails userDetails)
		{
			var userExists = await _userManager.FindByNameAsync(userDetails.UserName);

			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
								new Models.Response { Status = "Error", Message = "User đã có trong hệ thống" });
			}

			var identityUser = new IdentityUser()
			{
				UserName = userDetails.UserName,
				Email = userDetails.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
			};

			var result = await _userManager.CreateAsync(identityUser, userDetails.Password);


			if (!result.Succeeded)
				return StatusCode(StatusCodes.Status500InternalServerError,
					new Models.Response { Status = "Error", Message = "Co loi khi tao User! Kiem tra va thu lai." });

			//if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
			//	await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

			if (!await _roleManager.RoleExistsAsync(UserRoles.User))
				await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

			//if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			//{
			//	await _userManager.AddToRoleAsync(identityUser, UserRoles.Admin);
			//}

			if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _userManager.AddToRoleAsync(identityUser, UserRoles.User);
			}


			return Ok(new Models.Response { Status = "Success", Message = "User dc tao thanh cong!" });

		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
		{
			var user = await _userManager.FindByNameAsync(credentials.UserName);

			if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
			{
				var roles = await _userManager.GetRolesAsync(user);
				var token = _tokenServices.GenerateToken(user, roles);

				return Ok(new { Token = token });

			}

			return Unauthorized();
		}
	}
}
