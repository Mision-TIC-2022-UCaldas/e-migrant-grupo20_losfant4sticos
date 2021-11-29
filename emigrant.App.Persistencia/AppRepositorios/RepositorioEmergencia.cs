using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using emigrant.App.Dominio;

namespace emigrant.App.Persistencia
{
    public class RepositorioEmergencia : IRepositorioEmergencia
    {
               private readonly AppContextDb _appContext;
        public IEnumerable<Emergencia> Emergencia { get; set; }

        public RepositorioEmergencia(AppContextDb appContext)
        {
            _appContext = appContext;
        }

        Emergencia IRepositorioEmergencia.Add(Emergencia Emergencia)
        {
            try
            {
                var add = _appContext.Emergencias.Add(Emergencia); //INSERT en la BD
                _appContext.SaveChanges();
                return add.Entity;
            }
            catch
            {
                throw;
            }
        }

        IEnumerable<Emergencia> IRepositorioEmergencia.GetAll(string? entidad)
        {
            if (entidad != null)
            {
                return _appContext.Emergencias.Where(p => p.NumeroDocumetoMigrante.Contains(entidad)); //like sobre la tabla
            }
                return _appContext.Emergencias;  //select * from EntidadColaboradoras
        }

        Emergencia IRepositorioEmergencia.Get(int? id)
        {
            return _appContext.Emergencias.FirstOrDefault(p => p.Id == id);
        }

        Emergencia IRepositorioEmergencia.Update(Emergencia Emergencia)
        {
            var Search = _appContext.Emergencias.FirstOrDefault(p => p.Id == Emergencia.Id); //SELECT
            if (Search != null)
            {
                Search.TipoEmergencia = Emergencia.TipoEmergencia; //
                Search.FechaEmergencia = Emergencia.FechaEmergencia;
                Search.IdMigrante = Emergencia.IdMigrante;
                Search.Observacion = Emergencia.Estado;
                _appContext.SaveChanges();  //UPDATE 
            }
            return Search;
        }

        void IRepositorioEmergencia.Delete(int id)
        {
            var Buscar = _appContext.Emergencias.FirstOrDefault(p => p.Id == id);
            if (Buscar == null)
                return;
            _appContext.Emergencias.Remove(Buscar);
            _appContext.SaveChanges();
        }
    }
}