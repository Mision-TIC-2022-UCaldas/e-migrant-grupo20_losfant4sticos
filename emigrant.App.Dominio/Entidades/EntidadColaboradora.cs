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
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string Nit { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public int Ciudad { get; set; }
        public int Departamento { get; set; }
        public int Pais { get; set; }
    }
}