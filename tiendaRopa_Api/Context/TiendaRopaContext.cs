using Microsoft.EntityFrameworkCore;
using tiendaRopa_Api.Models;

namespace tiendaRopa_Api.Context
{
    public class TiendaRopaContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public TiendaRopaContext(DbContextOptions<TiendaRopaContext> options) : base(options) { }
    }
}