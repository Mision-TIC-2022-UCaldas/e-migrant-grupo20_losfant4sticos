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
    public class DetailEntidadModel : PageModel
    {
        private readonly IRepositorioEntidadColaboradora _appContext;
        public EntidadColaboradora Entidad {get; set;}

        //Constructor
        public DetailEntidadModel()
        {
            this._appContext = new RepositorioEntidadColaboradora( new AppContextDb());
        }

        public IActionResult OnGet(int entidadId)
        {
            Entidad = _appContext.Get(entidadId);
            if(Entidad == null)
            {
                return RedirectToPage("/Error");
            }else{
                return Page();
            }
        }
    }
}