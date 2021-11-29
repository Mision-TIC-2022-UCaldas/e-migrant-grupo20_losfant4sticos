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
    public class FormServiciosSolicitudModel : PageModel
    {
         private readonly IRepositorioServicioSolicitud repositorioServicioSolicitud;
         private readonly IRepositorioServicio repositorioServicio;
       [BindProperty]
        public ServicioSolicitud servicioSolicitud { get; set; }  
        public Servicio servicio { get; set; }  

        public FormServiciosSolicitudModel()
        {
           this.repositorioServicioSolicitud=new RepositorioServicioSolicitud(new emigrant.App.Persistencia.AppContextDb()) ;
           this.repositorioServicio=new RepositorioServicio(new emigrant.App.Persistencia.AppContextDb()) ;
        }

//LISTAR TODOS 
/*
        public void OnGet(string filtro)
        {
           Serviciosolicitados= new Serviciosolicitado();
           serviciosolicitados= repositorioServiciosolicitado.GetAllServiciosolicitados();
        }
*/

/// obtener codigo del SERVICIO (trae el id de la entidad, el id del tipo de servicio)

        public IActionResult OnGet(int ServicioId)
        {

        servicio = repositorioServicio.GetServicio(ServicioId);

            if (servicio==null)
            {
                return RedirectToPage("./NotFound");
                
            }
            else
                return Page();

        }
// ACTUALIZAR O AÑADIR NUEVO servicio solicitud
       public IActionResult OnPost(Servicio servicio)
        {
              //   ServicioSolicitud servicioSolicitud=new  ServicioSolicitud();
                 
                 servicioSolicitud.EntidadId  = servicio.EntidadId  ;
                 servicioSolicitud.ServicioId = servicio.ServicioId  ;
                 servicioSolicitud.ServicioNombre  = servicio.Nombre  ;
                 
            repositorioServicioSolicitud.AddServicio(servicioSolicitud);

            return Page();
        }

    }
}