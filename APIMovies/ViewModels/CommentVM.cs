using APIMovies.Models;

namespace APIMovies.ViewModels
{
	public class CommentVM
	{
		public int IdMovie { get; set; }
		

		public string  IdUser { get; set; }
		
		public string Cmt { get; set; }
		public int Rate { get; set; }
		public DateTime Created { get; set; }
	}

	public class CommentWithUser
	{
		public string Name { get; set; }
		public string img {  get; set; }
		public string dateCreated { get; set; }
		public string Cmt { get; set; }
		public int Rate { get; set; }
	}
}
