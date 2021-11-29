using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;

namespace emigrant.App.Persistencia
{
    public interface IRepositorioServicioEnUso
    {
        IEnumerable<ServicioEnUso> GetAllServicios();
        IEnumerable<ServicioEnUso> GetServicioPorFiltro(int filtro);
        ServicioEnUso AddServicio(ServicioEnUso Servicio);
        ServicioEnUso UpdateServicio(ServicioEnUso Servicio);
        void DeleteServicio(int idServicio);    
        ServicioEnUso GetServicio(int idServicio);
         
    }
}