using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using emigrant.App.Dominio;
namespace emigrant.App.Persistencia
{
    public interface IRepositorioEmergencia
    {
        Emergencia Add(Emergencia emergencia);
        IEnumerable<Emergencia> GetAll(string? emergenciaId);
        Emergencia Get(int? id);
        Emergencia Update(Emergencia emergencia);
        void Delete(int id);
    }
}