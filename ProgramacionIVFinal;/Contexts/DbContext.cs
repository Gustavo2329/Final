
using Backend.API.RESTful.Contexts;
using Backend.API.RESTful.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.RESTful.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DetalleVentaModel> DetallesVenta { get; set; }
    }
}