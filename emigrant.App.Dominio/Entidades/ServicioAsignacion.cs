using System;
using System.ComponentModel.DataAnnotations;

namespace emigrant.App.Dominio
{
    public class ServicioAsignacion
    {
        public int ServicioAsignacionId { get; set; }
        public int EntidadId { get; set; }
        [Required(ErrorMessage =  "este campo es obligatorio")]
        public string EntidadNombre { get; set; }
        public int ServicioId { get; set; }
       [Required(ErrorMessage =  "este campo es obligatorio")]
       public string ServicioNombre { get; set; }
       public int MigranteId { get; set; }

        public string MigranteNombre { get; set; }
        
        public string Estado { get; set; }
     //   [Required(ErrorMessage =  "este campo es obligatorio")]
 
    }
}