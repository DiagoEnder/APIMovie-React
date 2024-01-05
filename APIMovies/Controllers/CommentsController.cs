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

		[HttpGet("get-cmt/{id}")]
		public IActionResult GetCmtByIdMV(int id)
		{
			var lst = _commentServices.GetListCmtWithMovie(id);
			if (lst.Count > 0)
			{
				
				return Ok(lst);
			}else
			{
				return NotFound();
			}
		}

		[HttpGet("allcomment")]
		public IActionResult GetAll()
		{
			try
			{
				var lst = _commentServices.GetAll();
				return Ok(lst);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}
