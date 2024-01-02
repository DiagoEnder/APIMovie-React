namespace APIMovies.Models
{
	public class UserInfo
	{
		public string? Id { get; set; }
		
		public string? Name { get; set; }
		
		public string? Img { get; set; }

		public List<Comment> comments { get; set; }

		

	}
}
