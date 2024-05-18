using BlazingBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
	public DbSet<BlogPost> BlogPosts { get; set; }
	public DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
#if DEBUG
		/*Never do this in production*/
		optionsBuilder.LogTo(Console.WriteLine);
#endif
	}

	/*Seed data for the default user*/
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<User>()
			.HasData(
			    new User
				{
					Id = 1,
					FirstName = "Test",
					LastName = "Test",
					Email = "Test@test.com",
					Salt = "TestSaltyeteyybshshsnbs",
					Hash = "TestHash/=uuebdbdsushjs"
				}
			);
	}
}
