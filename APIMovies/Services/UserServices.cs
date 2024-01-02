using APIMovies.Models;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace APIMovies.Services
{
	public class UserServices
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		public UserServices(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}


		public UserVM Info(string id)
		{
			var user = _context.UserInfo.FirstOrDefault(x => x.Id == id);

			if (user == null)
			{
				return null;
			}

			var email = _userManager.FindByIdAsync(id).Result;
			if (email == null) return null;

			var vm = new UserVM();
			vm.Id = user.Id;
			vm.Img = user.Img;
			vm.Name = user.Name;
			vm.Email = email.Email;

			return vm;


		}
	}
}
