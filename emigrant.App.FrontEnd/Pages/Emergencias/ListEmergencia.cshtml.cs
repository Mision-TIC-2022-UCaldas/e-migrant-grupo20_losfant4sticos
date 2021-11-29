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
    public class ListEmergenciaModel : PageModel
    {
        private readonly IRepositorioEmergencia _appContext;
        public IEnumerable<Emergencia> Emergencia { get; set; }

        public string BuscarEmergencia;

        public ListEmergenciaModel()
        {
            this._appContext = new RepositorioEmergencia(new AppContextDb());
        }

        public void OnGet()
        {
            Emergencia = _appContext.GetAll(BuscarEmergencia);
        }

        public IActionResult OnPost(string? BuscarEmergencia)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Emergencia = _appContext.GetAll(BuscarEmergencia);
            return Page();
        }
    }
}