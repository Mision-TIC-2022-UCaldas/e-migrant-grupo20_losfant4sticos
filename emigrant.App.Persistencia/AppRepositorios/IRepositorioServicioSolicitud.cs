using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;


namespace emigrant.App.Persistencia
{
    public interface IRepositorioServicioSolicitud
    {
        IEnumerable<ServicioSolicitud> GetAllServicios();
        IEnumerable<ServicioSolicitud> GetServicioPorFiltro(string filtro);
        IEnumerable<ServicioSolicitud> GetServicioPorFiltroEnt(int filtro);
        ServicioSolicitud AddServicio(ServicioSolicitud Servicio);
      //  ServicioSolicitud UpdateServicio(ServicioSolicitud Servicio);
        void DeleteServicio(int idServicio);    
        ServicioSolicitud GetServicio(int idServicio);
    }
}