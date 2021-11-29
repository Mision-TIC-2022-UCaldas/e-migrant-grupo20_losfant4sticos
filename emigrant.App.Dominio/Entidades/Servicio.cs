using System;
using System.ComponentModel.DataAnnotations;

namespace emigrant.App.Dominio
{
    public class Servicio
    {
        public int ServicioId { get; set; }
      
        [Required(ErrorMessage = "Este campo es obligatorio")]
         public string Nombre { get; set; }
       

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int EntidadId { get; set; }
        
        public string EntidadNombre {get; set;}

        public int MaximoMigrantes { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime? FechaInicio { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime? FechaFinal { get; set; }
        
       // [Required(ErrorMessage = "Este campo es obligatorio")]
        public string EstadoServicio { get; set; }
      //  [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Categoria { get; set; }


    }
}