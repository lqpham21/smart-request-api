using Microsoft.EntityFrameworkCore;
using SmartRequest.Models;

namespace SmartRequest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
    }
}
