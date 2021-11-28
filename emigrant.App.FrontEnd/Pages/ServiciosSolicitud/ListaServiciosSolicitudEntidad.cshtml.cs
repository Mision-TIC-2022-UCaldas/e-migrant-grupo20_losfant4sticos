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
    public class ListaServiciosSolicitudEntidadModel : PageModel
    {
        private readonly IRepositorioServicioSolicitud repositorioServicioSolicitud;
        public IEnumerable<ServicioSolicitud> servicios { get; set; }
        public ServicioSolicitud ServicioSolicitud { get; set; }

        [BindProperty(SupportsGet = true)]
        public int FiltroBusqueda { get; set; }

        public ListaServiciosSolicitudEntidadModel()
        {
            this.repositorioServicioSolicitud = new RepositorioServicioSolicitud(new emigrant.App.Persistencia.AppContextDb());
        }

        //SE EJECUTA AL INICIO - tabla con lista de servicios y filtro

        public void OnGet(int filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            servicios = repositorioServicioSolicitud.GetServicioPorFiltroEnt(filtroBusqueda);
        }

    }
}


