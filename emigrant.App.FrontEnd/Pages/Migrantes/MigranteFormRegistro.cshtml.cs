using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emigrant.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using emigrant.App.Dominio;


namespace emigrant.App.FrontEnd.Pages.Migrantes
{
    public class MigranteFormRegistro : PageModel
    {
        private readonly IRepositorioMigrante repositorioCrear;
        public Migrante Migrante { get; set; }
        public String ValidarEntidad { get; set; }

        public MigranteFormRegistro(IRepositorioMigrante repositorioCrear)
        {
            this.repositorioCrear = repositorioCrear;
        }


        public IActionResult OnPostRegistrar(Migrante migrante)
        {
            try
            {
                if (migrante == null)
                {


                    return RedirectToPage("./NoFound");
                }
                else
                {

                    var Migrante = repositorioCrear.AddMigrante(migrante);
                    return Redirect($"~/Migrantes/MigranteDetalle?MigranteId={Migrante.MigranteId}");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                ValidarEntidad = "Error";
                return Page();

            }
           

        }


    }



}

