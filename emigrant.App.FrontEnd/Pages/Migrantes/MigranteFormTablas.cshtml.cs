using emigrant.App.Dominio;
using emigrant.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace emigrant.App.FrontEnd.Pages.Migrantes
{
    public class MigranteFormTablas : PageModel
    {

        private readonly IRepositorioMigrante repositorioMigrante;
        public List<Migrante> MigranteLista { get; set; }
        public IEnumerable<Migrante> Migrantes { get; set; }

        public MigranteFormTablas(IRepositorioMigrante repositorioCrear)
        {
            this.repositorioMigrante = repositorioCrear;
        }

        public void OnGet()
        {

            Migrantes = null;

        }
        public IActionResult OnPostBuscar(string migranteBuscar)

        {
            if (migranteBuscar != null)
            {
                Migrantes = repositorioMigrante.BuscarMigrante(migranteBuscar);
                return Page();
            }
            else
            {
                Migrantes = repositorioMigrante.GetAllMigrantes();
            }
            return Page();


        }






    }
}
