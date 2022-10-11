using app_cop.Models;
using Microsoft.EntityFrameworkCore;

namespace app_cop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Empleados> Empleado { get; set; }
        public DbSet<Roles> Rol { get; set; }
        public DbSet<Movimientos> Movimiento { get; set; }
        public DbSet<TipoMovimientos> TipoMovimiento { get; set; }

    }
}
