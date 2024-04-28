using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Entity_Framework__Introduction_2.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=blog.db");
            base.OnConfiguring(options);
        }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Blog> blogs = [
                new Blog() { Id = 1, Name = "Blog One", Url = "https://www.google.com/" }, 
                new Blog() { Id = 2, Name = "Blog Two", Url = "https://www.youtube.com/" }, 
                new Blog() { Id = 3, Name = "Blog Three", Url = "https://www.netflix.com/" }
                ];
            
            modelBuilder.Entity<Blog>().HasData(blogs);
        }
    }
}
