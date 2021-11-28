using System;
using System.ComponentModel.DataAnnotations;

namespace emigrant.App.Dominio
{
    public class ServicioSolicitud
    {
        public int ServicioSolicitudId { get; set; }

       // [Required(ErrorMessage = "este campo es obligatorio")]
        public int EntidadId { get; set; }

        public string EntidadNombre { get; set; }

       // [Required(ErrorMessage = "este campo es obligatorio")]
        public int ServicioId { get; set; }


        public string ServicioNombre { get; set; }

       // [Required(false)]
        public string MigranteId { get; set; }
        public string MigranteNombre { get; set; }

        public string Estado { get; set; }
    }
}