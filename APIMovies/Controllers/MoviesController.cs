using APIMovies.Services;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace APIMovies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private MoviesServices _movieService;
		private IWebHostEnvironment _webhost;

		public MoviesController(MoviesServices movieService, IWebHostEnvironment webhost)
		{
			_movieService = movieService;
			_webhost = webhost;
		}


		

		[HttpPost("addmovie")]
		public IActionResult AddMovie(MovieVM movie)
		{
			
			try
			{
				_movieService.AddBookWithTypeAsync(movie);
				return Ok("Added successfully");

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);

			}






		}

		[HttpGet("GetAllMovies")]
		public IActionResult GetAllMovies()
		{
			try
			{
				var _allmovie = _movieService.GetAllMoviesWithType();
				return Ok(_allmovie);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpGet("GetAllMoviesAd")]
		public IActionResult GetAllMoviesAdmin()
		{
			try
			{
				var _allmovie = _movieService.GetAllMoviesForAdmin();
				return Ok(_allmovie);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpGet("get-movie-by-idtype/{id}")]
		public IActionResult GetMovie( int id)
		{
			var _movie = _movieService.GetMovieByTypeId(id).ToList();
			if(_movie.Count == 0)
			{
				return NotFound();
			}

			return Ok(_movie);

		}

		[HttpGet("get-movie-by-name/{name}")]
		public IActionResult GetMovieByName(string name)
		{
			var _mv = _movieService.GetMovieByName(name).ToList();

			if( _mv.Count == 0)
			{
				return NotFound();
			}
			
			return Ok(_mv);

		}

		[HttpGet("detail-movie/{id}")]
		public IActionResult Detail(int id)
		{
			
			
				var _mv = _movieService.MovieDetail(id);
				if( _mv != null )
				{
					return Ok(_mv);
				}
				return NotFound();
			
		}

		[HttpPost("update-movie")]
		public IActionResult UpdateMovie(MovieUpdateVM movieVM)
		{
			try
			{
				_movieService.UpdateMovies(movieVM);
				return Ok("Updated Successfully");
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("deletemovie/{id}")]
		public IActionResult Delete(int id)
		{

			try
			{
				_movieService.DeleteMovie(id);
				return Ok($"Delete Successfully ID: {id}");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}




		[HttpPost("SaveFile")]
		public IActionResult SaveFile()
		{
			try
			{
				var httpRequest = Request.Form;
				var postedFile = httpRequest.Files[0];
				string filename = postedFile.FileName;
				var physicalPath = _webhost.ContentRootPath + "/Photos/" + filename;

				using (var stream = new FileStream(physicalPath, FileMode.Create))
				{
					postedFile.CopyTo(stream);

				}
				return new JsonResult(filename);
			}
			catch (Exception ex)
			{
				return new JsonResult("anony.png");
			}
		}

	}
}
