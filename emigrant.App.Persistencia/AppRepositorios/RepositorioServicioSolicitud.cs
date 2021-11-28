using System;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;


namespace emigrant.App.Persistencia
{
   public class RepositorioServicioSolicitud : IRepositorioServicioSolicitud
    {
        private readonly AppContextDb _appContext;
        public RepositorioServicioSolicitud(AppContextDb appContext)
        {
            _appContext = appContext;
        }

    //IMPLEMENTACION METODOS

        ServicioSolicitud IRepositorioServicioSolicitud.AddServicio(ServicioSolicitud servicio)
        {
            var servicioAdicionado = _appContext.ServicioSolicitudes.Add(servicio);
            _appContext.SaveChanges();
            return servicioAdicionado.Entity;

        }

        void IRepositorioServicioSolicitud.DeleteServicio(int ServicioId)
        {
            var servicioEncontrado = _appContext.Servicios.FirstOrDefault(p => p.ServicioId == ServicioId);
            if (servicioEncontrado == null)
                return;
            _appContext.Servicios.Remove(servicioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<ServicioSolicitud> IRepositorioServicioSolicitud.GetAllServicios()
        {
            return _appContext.ServicioSolicitudes;
        }

        ServicioSolicitud IRepositorioServicioSolicitud.GetServicio(int ServicioId)
        {
            return _appContext.ServicioSolicitudes.FirstOrDefault(p => p.ServicioSolicitudId == ServicioId);
        }
/*
       Servicio IRepositorioServicioSolicitud.UpdateServicio(Servicio servicio)
        {
            var servicioEncontrado = _appContext.Servicios.FirstOrDefault(p => p.ServicioId == servicio.ServicioId);
            if (servicioEncontrado != null)
            {
                 servicioEncontrado.Nombre = servicio.Nombre ;
                 int ServicioId = servicio.ServicioId;
                 /*servicioEncontrado.Id = id;
                 servicioEncontrado.doc_cli = servicio.doc_cli  ;
                 servicioEncontrado.dir_cli = servicio.dir_cli ;
                 servicioEncontrado.ema_cli = servicio.ema_cli ;
                 servicioEncontrado.tel_cli = servicio.tel_cli ;
              

                _appContext.SaveChanges();

            }
            return servicioEncontrado;
        }
*/
//Para tabla con filtro o con todos los servicios
  public IEnumerable<ServicioSolicitud> servicios {get; set;} 
  IEnumerable<ServicioSolicitud> IRepositorioServicioSolicitud.GetServicioPorFiltro(string filtro) // el parámetro es opcional 
        {

            if (filtro != "")  //Si se tienen servicios
            {
                    servicios = _appContext.ServicioSolicitudes.Where(s => s.MigranteId == filtro); 
            }
                else
                 servicios=_appContext.ServicioSolicitudes;
                 return servicios;
        }

  IEnumerable<ServicioSolicitud> IRepositorioServicioSolicitud.GetServicioPorFiltroEnt(int filtro) // el parámetro es opcional 
        {

            if (filtro != 0)  //Si se tienen servicios
            {
                    servicios = _appContext.ServicioSolicitudes.Where(s => s.EntidadId == filtro); 
            }
                else
                 servicios=_appContext.ServicioSolicitudes;
                 return servicios;
        }
    }
}


