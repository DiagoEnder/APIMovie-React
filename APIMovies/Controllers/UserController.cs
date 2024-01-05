using APIMovies.Models;
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
		private readonly ApplicationDbContext _context;
		public UserController(UserServices userServices, ApplicationDbContext context)
		{
			_userServices = userServices;
			_context = context;
		}


		[HttpGet("all-user")]
		public IActionResult AllUser()
		{
			try
			{
				var user = _userServices.AllUser();
				if (user == null)
				{
					return Ok("");
				}
				else
				{
					return Ok(user);
				}
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpGet("MyAccount/{id}")]
		public IActionResult GetUser (string id)
		{
			var user = _userServices.Info(id);
			if(user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}

		[HttpGet("Summary")]
		public IActionResult Summary()
		{
			var sluser = _context.UserInfo.Count();
			var slcmt = _context.Comments.Count();
			var slmovie = _context.Movies.Count();

			var sum = new
			{
				user = sluser,
				cmt = slcmt,
				movies = slmovie
			};

			return Ok(sum);
		}
	}
}
