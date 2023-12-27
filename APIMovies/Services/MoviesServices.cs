using APIMovies.Models;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.Services
{
	public class MoviesServices
	{
		private ApplicationDbContext _context;
		private IWebHostEnvironment _webhost;

		public MoviesServices(ApplicationDbContext context, IWebHostEnvironment webhost)
		{
			_context = context;
			_webhost = webhost;
		}

		public  void  AddBookWithTypeAsync(MovieVM movie)
		{
			var _movie = new Movies();
			if (movie != null)
			{
				_movie.NameMovie = movie.NameMovie;
				_movie.Description = movie.Description;
				_movie.State = movie.State;
				_movie.Img = movie.Img;
				_movie.LinkAddress = movie.LinkAddress;


				_context.Movies.Add(_movie);
				_context.SaveChanges();

				foreach (var id in movie.ListTypes)
				{
					var _movie_type = new Movie_Type()
					{
						IdMovie = _movie.Id,
						IdType = id
					};
					_context.Movie_Types.Add(_movie_type);
					 _context.SaveChanges();
				}
				
			}

			

		

		}

		//private string UploadedFile(MovieVM mv)
		//{
		//	string uniqueFileName = null;

		//	if (mv.ImgFront != null)
		//	{
		//		string uploadsFolder = Path.Combine(_webhost.WebRootPath, "Photos");
		//		uniqueFileName = Guid.NewGuid().ToString() + "_" + mv.ImgFront.FileName;
		//		string filePath = Path.Combine(uploadsFolder, uniqueFileName);

		//		using (var fileStream = new FileStream(filePath, FileMode.Create))
		//		{
		//			mv.ImgFront.CopyTo(fileStream);
		//		}
		//	}

		//	return uniqueFileName;
		//}

		public List<Movies> GetAllMovies() => _context.Movies.ToList();

		public List<MovieWithTypeVM> GetAllMoviesWithType()
		{
			var _Movie = _context.Movies.Select(mov => new MovieWithTypeVM()
			{
				Id = mov.Id,
				NameMovie = mov.NameMovie,
				Description = mov.Description,
				State = mov.State,
				Img = mov.Img,
				LinkAddress = mov.LinkAddress,
				Rating = mov.Comments.Average(n => n.Rate),
				ListTypes = mov.Movie_Type.Select(n => n.TypeMovie.Name).ToList()
			}).ToList();

			return _Movie;
		}

		public List<MovieWithAdminVM> GetAllMoviesForAdmin()
		{
			var _Movie = _context.Movies.Select(mov => new MovieWithAdminVM()
			{
				Id = mov.Id,
				NameMovie = mov.NameMovie,
				Description = mov.Description,
				State = mov.State,
				Img = mov.Img,
				LinkAddress = mov.LinkAddress,
				
				Rating = mov.Comments.Average(n => n.Rate),
				ListTypes = mov.Movie_Type.Select(n => n.TypeMovie.Name).ToList()
			}).ToList();

			return _Movie;
		}

		public IQueryable<GetMovieByTypeVM> GetMovieByTypeId(int id)
		{

			var _listmv = _context.Movie_Types
					.Where(mt => mt.IdType == id)
								.Join(_context.Movies, mty => mty.IdMovie, mv => mv.Id,
																					(mty, mv) => new GetMovieByTypeVM()
																					{
																						NameType = mty.TypeMovie.Name,
																						DescriptionType = mty.TypeMovie.Description,

																						NameMovie = mv.NameMovie,
																						Description = mv.Description,
																						State = mv.State,
																						Img = mv.Img,
																						LinkAddress = mv.LinkAddress,
																						Rating = mv.Comments.Average(n => n.Rate),
																						ListTypes = mv.Movie_Type.Select(n => n.TypeMovie.Name).ToList()
																					});


			return _listmv;


		}

		public MovieDetailVM MovieDetail(int id)
		{
			var _mv = _context.Movies.Where(m => m.Id == id).Select(mv => new MovieDetailVM()
			{
				

				NameMovie = mv.NameMovie,
				Description = mv.Description,
				State = mv.State,
				Img = mv.Img,
				LinkAddress = mv.LinkAddress,
				slRate = mv.Comments.Count(m => m.IdMovie == id) ,
				Rating = mv.Comments.Average(n => n.Rate),
				ListTypes = mv.Movie_Type.Select(n => n.TypeMovie.Name).ToList()
			}).FirstOrDefault();

			return _mv;
		}

		public  IQueryable<MovieWithTypeVM> GetMovieByName(string name)
		{
			var _mov = _context.Movies.Where(m => m.NameMovie.Contains(name)).Select( m => new MovieWithTypeVM()
			{
				

				NameMovie = m.NameMovie,
				Description = m.Description,
				State = m.State,
				Img = m.Img,
				LinkAddress = m.LinkAddress,
				Rating = m.Comments.Average(n => n.Rate),
				ListTypes = m.Movie_Type.Select(n => n.TypeMovie.Name).ToList()
			});
			

			
			
			return _mov;
			
		
		}

		public void UpdateMovies(MovieUpdateVM movieVM)
		{
			var _movie = _context.Movies.FirstOrDefault(m => m.Id == movieVM.Id);
			if (_movie != null)
			{
				_movie.NameMovie = movieVM.NameMovie;
				_movie.LinkAddress = movieVM.LinkAddress;
				
				_movie.State = movieVM.State;
				_movie.Img = movieVM.Img;
				_movie.Description = movieVM.Description;
				_context.Movies.Update(_movie);
				_context.SaveChanges();


				var listold = _context.Movie_Types.Where(x => x.IdMovie == movieVM.Id).ToList();
					_context.Movie_Types.RemoveRange(listold);
					_context.SaveChanges();
				foreach(var id in movieVM.ListTypes)
				{
					var list = new Movie_Type()
					{
						IdMovie = _movie.Id,
						IdType = id
					};


					_context.Movie_Types.Add(list);
					_context.SaveChanges();
					
				}

			}
		}

		public void DeleteMovie(int id)
		{
			var _movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			if(_movie != null)
			{
				_context.Movies.Remove(_movie);
				_context.SaveChanges();

				var _tm = _context.Movie_Types.Where(m => m.IdMovie == id).ToList();

				_context.Movie_Types.RemoveRange(_tm);
				_context.SaveChanges();
			}

			
		}


	}
}
