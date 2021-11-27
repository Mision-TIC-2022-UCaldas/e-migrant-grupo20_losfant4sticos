using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using emigrant.App.Dominio;

namespace emigrant.App.Persistencia.AppRepositorios
{
    public interface IRepositorioEntidadColaboradora
    {
        //Firma para los metodos o clases definidas en capa Dominio.
        EntidadColaboradora Add(EntidadColaboradora entidad);
        IEnumerable<EntidadColaboradora> GetAll(string? entidad);
        EntidadColaboradora Get(int? id);
        EntidadColaboradora Update(EntidadColaboradora entidad);
        void Delete(int id);
    }
}