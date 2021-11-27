using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace emigrant.App.Dominio
{
    public class EntidadColaboradora
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int Ciudad { get; set; }
        public int Departamento { get; set; }
        public int Pais { get; set; }
    }
}