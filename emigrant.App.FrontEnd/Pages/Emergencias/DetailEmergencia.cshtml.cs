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
    public class DetailEmergenciaModel : PageModel
    {
        private readonly IRepositorioEmergencia _appContext;
        public Emergencia Emergencia {get; set;}

        //Constructor
        public DetailEmergenciaModel()
        {
            this._appContext = new RepositorioEmergencia( new AppContextDb());
        }

        public IActionResult OnGet(int emergenciaId)
        {
            Emergencia = _appContext.Get(emergenciaId);
            if(Emergencia == null)
            {
                return RedirectToPage("/Error");
            }else{
                return Page();
            }
        }
    }
}