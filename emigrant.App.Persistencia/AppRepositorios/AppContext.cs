using emigrant.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace emigrant.App.Persistencia
{
    public class AppContextDb : DbContext
    {
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<EntidadColaboradora> EntidadColaboradora { get; set; }
        public DbSet<ServicioSolicitud> ServicioSolicitudes { get; set; }
        public DbSet<ServicioAsignacion> ServicioAsignaciones { get; set; }
        public DbSet<ServicioEnUso> ServicioEnUsos { get; set; }
        public DbSet<AmigoFamiliar> AmigoFamiliars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntidadColaboradora>()
                .HasIndex(e => e.Nit)
                .IsUnique();

            builder.Entity<Migrante>()
                .HasIndex(e => e.NumeroDocumento)
                .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; user id=sa; password=1234567890; Initial Catalog=grupo20fanta;");
            }
        }
    }
}
