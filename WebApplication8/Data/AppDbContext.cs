using Microsoft.EntityFrameworkCore;
using WebApplication8.Data.Models;

namespace WebApplication8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Library> Library { get; set; }
        public DbSet <Book> Book { get; set; }
    }
}