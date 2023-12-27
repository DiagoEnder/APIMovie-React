using APIMovies.Services;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private CommentServices _commentServices;

		public CommentsController(CommentServices commentServices)
		{
			_commentServices = commentServices;
		}

		[HttpPost("add-cmt")]
		public IActionResult AddComment([FromBody] CommentVM comment)
		{
			try
			{
				_commentServices.AddComment(comment);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}
