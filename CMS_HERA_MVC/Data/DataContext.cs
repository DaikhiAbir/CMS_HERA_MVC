using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS_HERA_MVC.Models;

namespace CMS_HERA_MVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Taxe> Taxes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxe>().ToTable("Taxe");
          
        }
    }
}
