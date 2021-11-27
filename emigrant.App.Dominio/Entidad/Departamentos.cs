using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emigrant.App.Dominio
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string CodigoDane { get; set; }
        public string NombreDepartamento { get; set; }
    }
}