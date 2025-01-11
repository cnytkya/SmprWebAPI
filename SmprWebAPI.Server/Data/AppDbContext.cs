using Microsoft.EntityFrameworkCore;
using SmprWebAPI.Server.Models;

namespace SmprWebAPI.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}