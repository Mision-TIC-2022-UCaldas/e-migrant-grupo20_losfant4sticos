using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;

namespace emigrant.App.Persistencia
{
    public interface IRepositorioServicioAsignacion
    {
         
        IEnumerable<ServicioAsignacion> GetAllServicios();
        IEnumerable<ServicioAsignacion> GetServicioPorFiltro(int filtro);
        ServicioAsignacion AddServicio(ServicioAsignacion ServicioAsignacion);
     /*   ServicioAsignacion UpdateServicio(ServicioAsignacion ServicioAsignacion);
        void DeleteServicio(int idServicio);    */
        ServicioAsignacion GetServicio(int idServicio);
 
    }
}