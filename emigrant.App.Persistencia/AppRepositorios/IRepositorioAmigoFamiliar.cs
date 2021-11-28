using emigrant.App.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emigrant.App.Persistencia
{
    public interface IRepositorioAmigoFamiliar
    {
        AmigoFamiliar AddAmigoFamiliar(AmigoFamiliar AmigoFamiliar);
        IEnumerable<AmigoFamiliar> GetAllAmigoFamiliar(int migranteId);
        AmigoFamiliar UpdateAmigoFamiliar(AmigoFamiliar AmigoFamiliar);
        void DeleteAmigoFamiliar(int AmigoFamiliarId);
        public AmigoFamiliar GetAmigoFamiliar(int AmigoFamiliarId);
        public IEnumerable<AmigoFamiliar> BuscarAmigoFamiliar(string AmigoFamiliarBuscar);
    }
}
