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
    public class FormServiciosModel : PageModel
    {
        
         private readonly IRepositorioServicio repositorioServicio;
        
       [BindProperty]
        public Servicio Servicio { get; set; }  

        public FormServiciosModel()
        {
           this.repositorioServicio=new RepositorioServicio(new emigrant.App.Persistencia.AppContextDb()) ;
        }

//LISTAR TODOS 
/*
        public void OnGet(string filtro)
        {
           Servicios= new Servicio();
           servicios= repositorioServicio.GetAllServicios();
        }
*/

/// BUSCAR SERVICIO

        public IActionResult OnGet(int? servicioId)
        {
         //   tipo_documentos= repositorioTipoDoc.GetAlltipo_doc();

            if (servicioId.HasValue)
            {
                Servicio = repositorioServicio.GetServicio(servicioId.Value);
                
            }
            else
            {
                Servicio = new Servicio();
                
            }
            if (Servicio == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }
// ACTUALIZAR O AÑADIR NUEVO
       public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
            return Page();
            }
            if(Servicio.ServicioId>0)
            {
            Servicio = repositorioServicio.UpdateServicio(Servicio);
            
            }
            else if (Servicio.ServicioId==0)
            {
                
             repositorioServicio.AddServicio(Servicio);
               
            }
             return Page();
           
        }

    }
}
       