using APIMovies.Models;
using APIMovies.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies.Services
{
	public class TypesServices
	{
		private ApplicationDbContext _context;

		public TypesServices(ApplicationDbContext context)
		{
			_context = context;
		}	

		public void AddType(TypeVM typeVM)
		{
			var _type = new TypeMovie()
			{
				Name = typeVM.Name,
				Description = typeVM.Description
			};

			_context.Types.Add(_type);
			_context.SaveChanges();
		}

		public List<TypeVM> GetAlltype()
		{
			var typelist = _context.Types.Select(m => new TypeVM()
			{
				Id = m.Id,
				Name = m.Name,
				Description = m.Description,

			}).ToList();
			return typelist;
		}

		public int  UpdateType(TypeVM typeVM)
		{
			var _uptype = _context.Types.Where(x => x.Id == typeVM.Id).FirstOrDefault();

			if(_uptype != null) 
			{
				_uptype.Name = typeVM.Name;
				_uptype.Description = typeVM.Description;							
				_context.Types.Update(_uptype);
					_context.SaveChanges();
				return 1;
			}
			return 0;								
	
		}

		public void Delete(int id)
		{

			var _type = _context.Types.FirstOrDefault(x => x.Id == id);

			if(_type != null)
			{
				_context.Types.Remove(_type);
				_context.SaveChanges();				
			}
			
		}

		
	}
}
