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
    public class DeleteEntidadModel : PageModel
    {
        private readonly IRepositorioEntidadColaboradora _appContext;

        [BindProperty]
        public EntidadColaboradora Entidad { get; set;}

        public DeleteEntidadModel()//Construstor de clase
        {
            this._appContext = new RepositorioEntidadColaboradora(new AppContextDb());
        }

        public IActionResult OnGet(int entidadId)
        {
            Entidad = _appContext.Get(entidadId);
            if(Entidad == null)
            {
                return RedirectToPage("/Error");
            }else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Entidad.Id>0)
            {
                _appContext.Delete(Entidad.Id);
            }
            return Page();
        }
    }
}