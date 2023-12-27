using System.ComponentModel.DataAnnotations.Schema;

namespace APIMovies.Models
{
	public class Movies
	{
		public int Id { get; set; }
		public string NameMovie { get; set; }
		public string? Description { get; set; }
		public string State { get; set; }
		public string Img { get; set; }
		public string LinkAddress { get; set; }
		[NotMapped]
		public double? Rating { get; set; }
		public List<Movie_Type> Movie_Type { get; set; }
		
		public List<Comment> Comments { get; set; }



	}
}
