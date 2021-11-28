using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emigrant.App.Dominio
{
    public class AmigoFamiliar
    {
        public int AmigoFamiliarId { get; set; }
        public int FamAmigId { get; set; }
        public Migrante Migrante { get; set; }
    }
}
