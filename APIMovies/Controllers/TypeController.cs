using APIMovies.Services;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TypeController : ControllerBase
	{
		private TypesServices _typesServices;

		public TypeController(TypesServices typesServices)
		{
			_typesServices = typesServices;
		}

		[HttpPost("add-type")]
		public IActionResult AddTypee([FromBody] TypeVM typeVM)
		{
			try
			{
				_typesServices.AddType(typeVM);
				return Ok("Added Successfully");
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpGet("all-type")]
		public IActionResult GetAllType()
		{
			var tp = _typesServices.GetAlltype();
			return Ok(tp);
		}

		[HttpPut("update-type")]
		public IActionResult UpdateType([FromBody] TypeVM typeVM)
		{
			
			
				var tp = _typesServices.UpdateType(typeVM);
			if (tp == 1)
			{
				return Ok("Updated Successfully!");
			}
			return BadRequest("False");
			
		}

		[HttpDelete("delete-type/{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				_typesServices.Delete(id);
				return Ok($"Deleted Successfully TypeId: {id}");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}


}
