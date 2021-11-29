using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using emigrant.App.Dominio;
using emigrant.App.Persistencia;

namespace emigrant.App.FrontEnd.Pages.EntidadCol
{
    public class CrearEntidadModel : PageModel
    {
        private readonly IRepositorioEntidadColaboradora _appContext;

        [BindProperty]
        public EntidadColaboradora Entidad { get; set; }
        public String ValidarEntidad { get; set; }

        public CrearEntidadModel()
        {
            this._appContext = new RepositorioEntidadColaboradora(new AppContextDb());
        }

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? entidadId)
        {
            if (entidadId.HasValue)
            {
                Entidad = _appContext.Get(entidadId.Value);
            }
            else
            {
                Entidad = new EntidadColaboradora();
            }
            if (Entidad == null)
            {
                return RedirectToPage("/Error");
            }
            else
                return Page();

        }

        //se ejecuta al presionar Editar en el formulario
        public IActionResult OnPost()
        {
            try{
                if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Entidad.Id > 0)
            {
               Entidad = _appContext.Update( Entidad );
            }
            else
            {
                _appContext.Add(Entidad);
            }
            return Page();
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
