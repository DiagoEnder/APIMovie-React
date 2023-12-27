namespace APIMovies.Models
{
	public class Movie_Type
	{
		public int Id { get; set; }

		public int IdMovie { get; set; }
		public Movies Movies { get; set; }

		public int IdType { get; set; }
		public TypeMovie TypeMovie { get; set; }
	}
}
