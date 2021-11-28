
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace emigrant.App.Dominio
{
    public class Migrante
    {

        public int MigranteId { get; set; }
        [Required(ErrorMessage = "este campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "este campo es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "este campo es obligatorio")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "este campo es obligatorio")]
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "este campo es obligatorio")]
        public Pais PaisOrigen { get; set; }
        public string FechaNacimiento { get; set; }
        public string DirrecionElectronica { get; set; }
        public string NumeroTelefono { get; set; }
        public string DireccionActual { get; set; }
        public Ciudad CiudadResidencia { get; set; }
        public bool SituacionLaboral { get; set; }
        //public AmigosFamiliares AmigosFamiliares { get; set; }
        public List<AmigoFamiliar> AmigoFamiliar { get; set; }
    }
}