using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using emigrant.App.Dominio;
using emigrant.App.Persistencia.AppRepositorios;

namespace emigrant.App.Presentacion.Pages.EntidadCol
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

        public IActionResult OnGet(int id)
        {
            Entidad = _appContext.Get(id);
            if(Entidad == null)
            {
                return RedirectToPage("./NotFound");
            }else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _appContext.Delete(Entidad.Id);
                return Page();
            }else{
                return Page();
            }
        }
    }
}