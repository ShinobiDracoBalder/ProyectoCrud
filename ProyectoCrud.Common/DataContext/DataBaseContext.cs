using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Common.Entities;

namespace ProyectoCrud.Common.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }
        public virtual DbSet<Contacto> Contacto { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
