using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace emigrant.App.Dominio
{
    public class Emergencia
    {
        public int Id { get; set; }
        public string TipoEmergencia { get; set; }
        public DateTime FechaEmergencia { get; set; }
        public int IdMigrante { get; set; }
        public string NumeroDocumetoMigrante { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string NombreMigrante { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string Observacion  { get; set; }
        
        public string Estado { get; set; }

    }
}