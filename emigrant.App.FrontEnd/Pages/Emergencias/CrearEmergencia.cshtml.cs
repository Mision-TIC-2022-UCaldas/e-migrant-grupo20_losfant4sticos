using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using emigrant.App.Dominio;
using emigrant.App.Persistencia;

namespace emigrant.App.FrontEnd.Pages
{
    public class CrearEmergenciaModel : PageModel
    {
        private readonly IRepositorioEmergencia _appContext;

        [BindProperty]
        public Emergencia Emergencia { get; set; }
        public string ValidarEmergencia { get; set; }
        public string FechaEmergencia { get; set; }

        public CrearEmergenciaModel()
        {
            this._appContext = new RepositorioEmergencia(new AppContextDb());
        }

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? emergenciaId)
        {
            if (emergenciaId.HasValue)
            {
                Emergencia = _appContext.Get(emergenciaId.Value);
            }
            else
            {
                Emergencia = new Emergencia();
            }
            if (Emergencia == null)
            {
                return RedirectToPage("/Error");
            }
            else
                return Page();

        }

        //se ejecuta al presionar Editar en el formulario
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Emergencia.Id > 0)
            {
               Emergencia = _appContext.Update( Emergencia );
            }
            else
            {
                _appContext.Add(Emergencia);
            }
            return Page();
        }
    }
}
