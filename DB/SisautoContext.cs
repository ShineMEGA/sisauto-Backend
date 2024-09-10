using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class SisautoContext : IdentityDbContext // DbContext // heredar de la clase dbcontext
    {
        public SisautoContext(DbContextOptions<SisautoContext> options)
            : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<DetalleOrdenes> DetalleOrdenes { get; set; }

    }
}
