namespace APIMovies.Models
{
	public class Comment
	{
		public int Id { get; set; }


		public int IdMovie { get; set; }
		public Movies Movies { get; set; }

		public string IdUser { get; set; }
		public UserInfo UserInfo { get; set; }

		public string Cmt {  get; set; }
		public int Rate { get; set; }
		public DateTime Created { get; set; } 
	}
}
