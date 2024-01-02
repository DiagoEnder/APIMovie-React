using APIMovies.Models;

namespace APIMovies.ViewModels
{
	public class MovieVM
	{		
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }

		public string Img {  get; set; }
		

		public string LinkAddress { get; set; }
		
		public List<int> ListTypes { get; set; }
	}

	public class MovieWithTypeVM
	{
		public int Id { get; set; }
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }


		public double? Rating { get; set; }
		public List<string> ListTypes { get; set; }
	}

	public class MovieWithAdminVM
	{
		public int Id { get; set; }
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }

		
		public double? Rating { get; set; }
		public List<string> ListTypes { get; set; }
	}

	public class MovieUpdateVM
	{
		public int Id { get; set; }
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }	
		public List<int> ListTypes { get; set; }
		
	}

	public class GetMovieByTypeVM
	{
		public int Id { get; set; }
		public string NameType { get;set; }
		public string DescriptionType { get; set; }


		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }


		public double? Rating { get; set; }
		public List<string> ListTypes { get; set; }


	}

	public class MovieDetailVM
	{
		public int Id { get; set; }
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }
		public int slRate { get; set; }



		public double? Rating { get; set; }
		public List<string> ListTypes { get; set; }

	}
}
