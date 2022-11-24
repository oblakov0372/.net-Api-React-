using BookProject.Resource.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookProject.Resource.Api.Repository
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ProjectDbContext()
        {
            Users = Set<User>();
            Books = Set<Book>();
            Orders = Set<Order>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UB31SED\\SQLEXPRESS;Database=BookProject1;Trusted_Connection=True;");
        }
    }
}
