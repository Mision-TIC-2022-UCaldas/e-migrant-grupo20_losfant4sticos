using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using emigrant.App.Dominio;
using emigrant.App.Persistencia.AppRepositorios;
using emigrant.App.Persistencia;

namespace emigrant.App.Presentacion.Pages.EntidadCol
{
    public class ListEntidadModel : PageModel
    {
        private readonly IRepositorioEntidadColaboradora _appContext;
        public IEnumerable<EntidadColaboradora> Entidades { get; set; }

        public string BuscarEntidad;

        public ListEntidadModel()
        {
            this._appContext = new RepositorioEntidadColaboradora(new AppContextDb());
        }

        public void OnGet()
        {
            Entidades = _appContext.GetAll(BuscarEntidad);
        }

        public IActionResult OnPost(string? BuscarEntidad)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Entidades = _appContext.GetAll(BuscarEntidad);
            return Page();
        }
    }
}