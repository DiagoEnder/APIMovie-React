using APIMovies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserServices _userServices;
		public UserController(UserServices userServices)
		{
			_userServices = userServices;
		}


		[HttpGet("user")]
		public IActionResult GetUser (string id)
		{
			var user = _userServices.Info(id);
			if(user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}
	}
}
