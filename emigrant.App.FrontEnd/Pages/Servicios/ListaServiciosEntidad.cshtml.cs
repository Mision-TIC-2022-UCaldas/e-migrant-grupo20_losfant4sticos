using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using emigrant.App.Persistencia;
using emigrant.App.Dominio;


namespace emigrant.App.Frontend
{
    public class ListaServiciosEntidadModel : PageModel
    {
        private readonly IRepositorioServicio repositorioServicio;
        public IEnumerable<Servicio> servicios { get; set; }
        public Servicio Servicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public int FiltroBusqueda { get; set; }

        public ListaServiciosEntidadModel()
        {
            this.repositorioServicio = new RepositorioServicio(new emigrant.App.Persistencia.AppContextDb());
        }

        //SE EJECUTA AL INICIO - tabla con lista de servicios y filtro

        public void OnGet(int EntidadId)
        {
        servicios = repositorioServicio.GetServicioPorFiltroEnt(EntidadId);
        }


        // public IActionResult OnPost()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }
        //     if (Servicio.ServicioId > 0)
        //     {
        //     repositorioServicio.GetServicioPorFiltroEnt(Servicio.ServicioId);
        //     }
        //     return Page();
        // }

    }
}

