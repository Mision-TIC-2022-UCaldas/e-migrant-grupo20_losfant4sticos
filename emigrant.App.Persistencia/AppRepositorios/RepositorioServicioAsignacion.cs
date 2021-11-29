using System;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;


namespace emigrant.App.Persistencia
{
    public class RepositorioServicioAsignacion : IRepositorioServicioAsignacion
    {

        private readonly AppContextDb _appContext;
        public RepositorioServicioAsignacion(AppContextDb appContext)
        {
            _appContext = appContext;
        }

    //IMPLEMENTACION METODOS

        ServicioAsignacion IRepositorioServicioAsignacion.AddServicio(ServicioAsignacion servicio)
        {
            var servicioAdicionado = _appContext.ServicioAsignaciones.Add(servicio);
            _appContext.SaveChanges();
            return servicioAdicionado.Entity;

        }
/*
        void IRepositorioServicioAsignacion.DeleteServicio(int ServicioId)
        {
            var servicioEncontrado = _appContext.Servicios.FirstOrDefault(p => p.ServicioId == ServicioId);
            if (servicioEncontrado == null)
                return;
            _appContext.Servicios.Remove(servicioEncontrado);
            _appContext.SaveChanges();
        }
*/
        IEnumerable<ServicioAsignacion> IRepositorioServicioAsignacion.GetAllServicios()
        {
            return _appContext.ServicioAsignaciones;
        }

        ServicioAsignacion IRepositorioServicioAsignacion.GetServicio(int ServicioId)
        {
            return _appContext.ServicioAsignaciones.FirstOrDefault(p => p.ServicioAsignacionId == ServicioId);
        }
/*
       Servicio IRepositorioServicioAsignacion.UpdateServicio(Servicio servicio)
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
  public IEnumerable<ServicioAsignacion> servicios {get; set;} 
  IEnumerable<ServicioAsignacion> IRepositorioServicioAsignacion.GetServicioPorFiltro(int filtro) // el parámetro es opcional 
        {

            if (filtro != 0)  //Si se tienen servicios
            {
                    servicios = _appContext.ServicioAsignaciones.Where(s => s.MigranteId == filtro); 
            }
                else
                 servicios=_appContext.ServicioAsignaciones;
                 return servicios;
        }

    }

}
