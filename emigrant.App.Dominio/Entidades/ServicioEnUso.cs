namespace emigrant.App.Dominio
{
    public class ServicioEnUso
    {
       
         public int ServicioEnUsoId { get; set; }
         public int EntidadId { get; set; }
      //  [Required(ErrorMessage =  "este campo es obligatorio")]
        public int ServicioId { get; set; }
     //   [Required(ErrorMessage =  "este campo es obligatorio")]
        public int MigranteId { get; set; }
        public string Estado { get; set; }
     //   [Required(ErrorMessage =  "este campo es obligatorio")] 
    }
}