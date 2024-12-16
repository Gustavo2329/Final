using Backend.API.RESTful.Models;
using Microsoft.EntityFrameworkCore;
using PBackend.API.RESTful.Models;

namespace Backend.API.RESTful.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ArticuloModel> Articulos { get; set; }
        public DbSet<DetallesVEntasModel> DetallesVentas { get; set; }
        public DbSet<VentasModel> Ventas { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloModel>().HasKey(c => c.Id_Articulo);
            modelBuilder.Entity<DetallesVentasModel>().HasKey(c => c.Id_DetallesVentas);
            modelBuilder.Entity<VentasModel>().HasKey(c => c.Id_Ventas);
        

            base.OnModelCreating(modelBuilder);
        }
    }
}
