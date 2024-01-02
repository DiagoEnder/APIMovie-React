using APIMovies.Models;
using APIMovies.ViewModels;

namespace APIMovies.Services
{
	public class UsersServices
	{
		private ApplicationDbContext _context;
		public UsersServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public void AddUser(UserVM userVM)
		{
			var _user = new UserInfo()
			{
				Name = userVM.Name,
				Img = userVM.Img
			};
			
		}


	}
}
