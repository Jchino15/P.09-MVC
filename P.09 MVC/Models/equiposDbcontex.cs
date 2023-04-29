using Microsoft.EntityFrameworkCore;

namespace P._09_MVC.Models
{
    public class equiposDbcontex : DbContext
    {

        public equiposDbcontex(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<equipos> equipos { get; set; }
    }
}
