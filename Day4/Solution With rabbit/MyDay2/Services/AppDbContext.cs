using Microsoft.EntityFrameworkCore;

namespace MyDay2.Services
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected readonly DbContextOptions Configuration;
        public AppDbContext(DbContextOptions configuration) : base(configuration)
        {
            Configuration = configuration;
        }

    }
}
