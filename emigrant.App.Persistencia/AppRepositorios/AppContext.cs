using emigrant.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace emigrant.App.Persistencia.AppRepositorios
{
    public class AppContextDb : DbContext
    {
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<EntidadColaboradora> EntidadColaboradora { get; set; }
         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; user id=sa; password=1234567890; Initial Catalog=hackaton;");

            }


        }

    }


}