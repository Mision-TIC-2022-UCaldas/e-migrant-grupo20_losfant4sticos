using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;


namespace emigrant.App.Persistencia
{
    public interface IRepositorioServicio
    {
        IEnumerable<Servicio> GetAllServicios();
        IEnumerable<Servicio> GetServicioPorFiltro(string filtro);
        IEnumerable<Servicio> GetServicioPorFiltroEnt(int filtro);
        Servicio AddServicio(Servicio Servicio);
        Servicio UpdateServicio(Servicio Servicio);
        void DeleteServicio(int idServicio);    
        Servicio GetServicio(int idServicio);

        Servicio GetEntidad(int idServicio);
 
    }
}