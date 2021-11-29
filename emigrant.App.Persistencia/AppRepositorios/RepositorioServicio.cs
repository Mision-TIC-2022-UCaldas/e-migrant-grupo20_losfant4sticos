using System;
using System.Collections.Generic;
using System.Linq;
using emigrant.App.Dominio;

namespace emigrant.App.Persistencia
{
    public class RepositorioServicio : IRepositorioServicio
    {

        private readonly AppContextDb _appContext;
        public RepositorioServicio(AppContextDb appContext)
        {
            _appContext = appContext;
        }

        //IMPLEMENTACION METODOS

        Servicio IRepositorioServicio.AddServicio(Servicio servicio)
        {
            try
            {
                var servicioAdicionado = _appContext.Servicios.Add(servicio);
                if (servicio.FechaInicio < servicio.FechaFinal)
                {
                    _appContext.SaveChanges();
                    

                }
                else
                {
                    return null;
                }
                return servicioAdicionado.Entity;
            }
            catch
            {
                throw;
            }

        }

        void IRepositorioServicio.DeleteServicio(int ServicioId)
        {
            var servicioEncontrado = _appContext.Servicios.FirstOrDefault(p => p.ServicioId == ServicioId);
            if (servicioEncontrado == null)
                return;
            _appContext.Servicios.Remove(servicioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Servicio> IRepositorioServicio.GetAllServicios()
        {
            return _appContext.Servicios;
        }

        Servicio IRepositorioServicio.GetServicio(int ServicioId)
        {
            return _appContext.Servicios.FirstOrDefault(p => p.ServicioId == ServicioId);
        }
        Servicio IRepositorioServicio.GetEntidad(int EntidadId)
        {
            return _appContext.Servicios.FirstOrDefault(p => p.EntidadId == EntidadId);
        }
        Servicio IRepositorioServicio.UpdateServicio(Servicio servicio)
        {
            var servicioEncontrado = _appContext.Servicios.FirstOrDefault(p => p.ServicioId == servicio.ServicioId);
            if (servicioEncontrado != null)
            {
                          
                servicioEncontrado.ServicioId = servicio.ServicioId;
                servicioEncontrado.EntidadId = servicio.EntidadId;
                servicioEncontrado.Nombre = servicio.Nombre;
                servicioEncontrado.Categoria = servicio.Categoria;
                servicioEncontrado.MaximoMigrantes = servicio.MaximoMigrantes;
                servicioEncontrado.FechaInicio = servicio.FechaInicio;
                servicioEncontrado.FechaFinal = servicio.FechaFinal;
                servicioEncontrado.EstadoServicio = servicio.EstadoServicio;

                _appContext.SaveChanges();

            }
            return servicioEncontrado;
        }

        //Para tabla con filtro o con todos los servicios
        public IEnumerable<Servicio> servicios { get; set; }
        IEnumerable<Servicio> IRepositorioServicio.GetServicioPorFiltro(string filtro) // el parámetro es opcional 
        {

            if (filtro != null)  //Si se tienen servicios
            {
                servicios = _appContext.Servicios.Where(s => s.Nombre.Contains(filtro) ||  s.Categoria.Contains(filtro));
            }
            else
                servicios = _appContext.Servicios;
            return servicios;
        }

        IEnumerable<Servicio> IRepositorioServicio.GetServicioPorFiltroEnt(int filtro) // el parámetro es opcional 
        {

            if (filtro != 0)  //Si se tienen servicios
            {
                servicios = _appContext.Servicios.Where(s => s.EntidadId == filtro);
            }
            else
                servicios = _appContext.Servicios;
            return servicios;
        }


    }
}
