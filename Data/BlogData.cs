using ExploringCalifornia2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploringCalifornia2.Data
{
    public class BlogData: DbContext
    {
        public BlogData(DbContextOptions<BlogData> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }
    }
}
