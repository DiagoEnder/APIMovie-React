namespace APIMovies.Models
{
	public class TypeMovie
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }

		public List<Movies> Movies { get; set; }
		public List<Movie_Type> Movies_Type { get; set; }
	}
}
