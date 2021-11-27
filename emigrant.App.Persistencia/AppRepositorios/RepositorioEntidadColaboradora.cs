using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using emigrant.App.Dominio;

namespace emigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioEntidadColaboradora : IRepositorioEntidadColaboradora
    {
        // Instanciamos el objecto de la clase AppContext
        private readonly AppContextDb _appContext;
        public IEnumerable<EntidadColaboradora> EntidadColaboradora { get; set; }

        public RepositorioEntidadColaboradora(AppContextDb appContext)
        {
            _appContext = appContext;
        }

        EntidadColaboradora IRepositorioEntidadColaboradora.Add(EntidadColaboradora EntidadColaboradora)
        {
            try
            {
                var add = _appContext.EntidadColaboradora.Add(EntidadColaboradora); //INSERT en la BD
                _appContext.SaveChanges();
                return add.Entity;
            }
            catch
            {
                throw;
            }
        }

        IEnumerable<EntidadColaboradora> IRepositorioEntidadColaboradora.GetAll(string? entidad)
        {
            if (entidad != null)
            {
                return _appContext.EntidadColaboradora.Where(p => p.Name.Contains(entidad)); //like sobre la tabla
            }
                return _appContext.EntidadColaboradora;  //select * from EntidadColaboradoras
        }

        EntidadColaboradora IRepositorioEntidadColaboradora.Get(int? idFormador)
        {
            return _appContext.EntidadColaboradora.FirstOrDefault(p => p.Id == idFormador);
        }

        EntidadColaboradora IRepositorioEntidadColaboradora.Update(EntidadColaboradora EntidadColaboradora)
        {
            var Search = _appContext.EntidadColaboradora.FirstOrDefault(p => p.Id == EntidadColaboradora.Id); //SELECT
            if (Search != null)
            {
                Search.Nit = EntidadColaboradora.Nit; //
                Search.Name = EntidadColaboradora.Name;
                Search.Direccion = EntidadColaboradora.Direccion;
                Search.Telefono = EntidadColaboradora.Telefono;
                Search.Ciudad = EntidadColaboradora.Ciudad;
                Search.Departamento = EntidadColaboradora.Departamento;
                Search.Pais = EntidadColaboradora.Pais;
                _appContext.SaveChanges();  //UPDATE 
            }
            return Search;
        }

        void IRepositorioEntidadColaboradora.Delete(int idFormador)
        {
            var FormadorEncontrado = _appContext.EntidadColaboradora.FirstOrDefault(p => p.Id == idFormador);
            if (FormadorEncontrado == null)
                return;
            _appContext.EntidadColaboradora.Remove(FormadorEncontrado);
            _appContext.SaveChanges();
        }
    }
}