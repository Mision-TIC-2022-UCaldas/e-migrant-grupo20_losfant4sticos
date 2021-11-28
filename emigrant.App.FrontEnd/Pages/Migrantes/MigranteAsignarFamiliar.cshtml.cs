using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emigrant.App.Dominio;
using emigrant.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace emigrant.App.FrontEnd.Pages.Migrantes
{
    public class MigranteAsignarFamiliar : PageModel
    {
        private readonly IRepositorioMigrante repositorioMigrante;
        private readonly IRepositorioAmigoFamiliar repositorioAmigoFamiliar;
        public List<Migrante> MigranteLista { get; set; }
        public IEnumerable<Migrante> Migrantes { get; set; }
        public AmigoFamiliar AmigoFamiliar { get; set; }
        public Migrante Migrante { get; set; }
        List<AmigoFamiliar> ListaAmigoFamiliar { get; set; }



        public MigranteAsignarFamiliar(IRepositorioMigrante repositorioCrear, IRepositorioAmigoFamiliar repositorioAmigoFamiliar)
        {
            this.repositorioMigrante = repositorioCrear;
            this.repositorioAmigoFamiliar = repositorioAmigoFamiliar;
        }

        public void OnGet(int migranteId)
        {
            Migrante = repositorioMigrante.GetMigrante(migranteId);
             

        }
     
        public IActionResult OnPostBuscar(string migranteBuscar, int migranteId)

        {
            Migrante = repositorioMigrante.GetMigrante(migranteId);

            if (migranteBuscar != null)
            {
                Migrantes = repositorioMigrante.BuscarMigranteAsignar(migranteBuscar, migranteId);
                return Page();
            }
            else
            {
                Migrantes = null;

            }   
            return Page(); 


        }


        public IActionResult OnPostAniadirFamAmg(int migranteId, int amigoFamiliarId)
        {
            AmigoFamiliar nuevofamiliar = new AmigoFamiliar();
            AmigoFamiliar nuevofamiliar2 = new AmigoFamiliar();
            nuevofamiliar.FamAmigId = amigoFamiliarId;
            nuevofamiliar.Migrante = repositorioMigrante.GetMigrante(amigoFamiliarId);
            nuevofamiliar2 = repositorioAmigoFamiliar.AddAmigoFamiliar(nuevofamiliar);
            repositorioMigrante.AsignarFamiliarAmigo(migranteId, nuevofamiliar2);
            return Redirect($"~/Migrantes/MigranteDetalle?MigranteId={migranteId}"); ;

        }






    }
}

