using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.Models
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Movies> Movies { get; set; }
		public DbSet<TypeMovie> Types { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Movie_Type> Movie_Types { get; set; }
		public DbSet<UserInfo>  userInfos { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Movie_Type>()
				.HasOne(m => m.Movies)
				.WithMany(t => t.Movie_Type)
				.HasForeignKey(a => a.IdMovie);

			builder.Entity<Movie_Type>()
				.HasOne(t => t.TypeMovie)
				.WithMany(m => m.Movies_Type)
				.HasForeignKey(a => a.IdType);

			base.OnModelCreating(builder);
		}
	}
}
