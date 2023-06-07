using WebApplication6.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication6.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("TestConnection"));
        }
        public DbSet<Products> Product { get; set; }
    }
}
