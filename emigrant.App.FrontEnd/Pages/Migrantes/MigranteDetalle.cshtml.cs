using emigrant.App.Dominio;
using emigrant.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace emigrant.App.FrontEnd.Pages.Migrantes
{
    public class MigranteDetalleModel : PageModel
    {

        private readonly IRepositorioMigrante repositorioMigrante;
        private readonly IRepositorioAmigoFamiliar repositorioAmigoFamiliar;
        public Migrante Migrante { get; set; }
        public IEnumerable<Migrante> Migrantes { get; set; }
        public IEnumerable<AmigoFamiliar> AmigoFamiliares { get; set; }
        public AmigoFamiliar AmigoFamiliar { get; set; }
        public List<Migrante> MigranteInterar { get; set; }
        public String ValidarEntidad { get; set; }
        public MigranteDetalleModel(IRepositorioMigrante repositorioMigrante, IRepositorioAmigoFamiliar repositorioAmigoFamiliar)
        {
            this.repositorioMigrante = repositorioMigrante;
            this.repositorioAmigoFamiliar = repositorioAmigoFamiliar;
        }
        public IActionResult OnGet(string numeroDocumento, int migranteId)
        {
            try
            {
                Migrante = repositorioMigrante.GetMigranteDocument(numeroDocumento);
                if (Migrante != null)
                {
                    MigranteInterar = repositorioMigrante.GetFamiliaresAmigos(Migrante.MigranteId);
                }
                else
                {
                    Migrante = repositorioMigrante.GetMigrante(migranteId);
                    MigranteInterar = repositorioMigrante.GetFamiliaresAmigos(migranteId);
                }
                if (Migrante==null)
                {
                    var ex = "No se encontro el documento en la base de deatos";
                    ModelState.AddModelError("Error", ex);
                    ValidarEntidad = "Error";
                    return Redirect("../Index");
                }
                return Page();
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                ValidarEntidad = "Error";
                return Redirect("../Index");
            }
       
        }
        public IActionResult OnPost(Migrante migrante)
        {
            AmigoFamiliares = repositorioAmigoFamiliar.GetAllAmigoFamiliar(migrante.MigranteId);
            Migrante = repositorioMigrante.GetMigrante(migrante.MigranteId);
            if (migrante.MigranteId > 0)
            {


                repositorioMigrante.UpdateMigrante(migrante); ;
            }
            else
            {
                repositorioMigrante.AddMigrante(migrante); ;
            }
            return Page();
        }

        public IActionResult OnPostBuscar(string migranteBuscar, Migrante migrante)

        {
            AmigoFamiliares = repositorioAmigoFamiliar.GetAllAmigoFamiliar(migrante.MigranteId);
            Migrante = repositorioMigrante.GetMigrante(migrante.MigranteId);
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

        public IActionResult OnPostDelete(int famAmigId, int migranteId)
        {
            AmigoFamiliares = repositorioAmigoFamiliar.GetAllAmigoFamiliar(migranteId);
            Migrante = repositorioMigrante.GetMigrante(migranteId);
            
            if (famAmigId > 0)
            {


                repositorioMigrante.DeleteFamAmig(famAmigId, migranteId);
            }
            MigranteInterar = repositorioMigrante.GetFamiliaresAmigos(migranteId);
            return Page();
        }


    }




}
