using APIMovies.Models;
using APIMovies.ViewModels;

namespace APIMovies.Services
{
	public class CommentServices
	{
		private ApplicationDbContext _context;
		public CommentServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public void AddComment(CommentVM cm)
		{
			var _cmt = new Comment()
			{
				IdMovie = cm.IdMovie,
				IdUser = cm.IdUser,
				Cmt = cm.Cmt,
				Rate = cm.Rate,
				Created = DateTime.Now
			};

			_context.Comments.Add(_cmt);
			_context.SaveChanges();
		}

		public List<CommentWithUser> GetListCmtWithMovie(int idmv)
		{
			var _LstCmt = _context.Comments.Where(n =>  n.IdMovie == idmv).Select(cmt => new CommentWithUser()
			{
				Name = cmt.UserInfo.Name,
				img = cmt.UserInfo.Img,
				dateCreated = cmt.Created.ToString("dd/MM/yyyy"),
				Rate = cmt.Rate,
				Cmt = cmt.Cmt

			}).ToList();

			return _LstCmt;
		} 
	}
}
