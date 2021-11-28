using emigrant.App.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emigrant.App.Persistencia
{
    public class RepositorioAmigoFamiliar : IRepositorioAmigoFamiliar
    {
        private readonly AppContextDb _appContext;
        public RepositorioAmigoFamiliar(AppContextDb appContext)
        {
            _appContext = appContext;
        }

        public AmigoFamiliar AddAmigoFamiliar(AmigoFamiliar amigoFamiliar)
        {
            var AmigoFamiliarAdicionado = _appContext.AmigoFamiliars.Add(amigoFamiliar);
            _appContext.SaveChanges();
            return AmigoFamiliarAdicionado.Entity;
        }


        public IEnumerable<AmigoFamiliar> BuscarAmigoFamiliar(string AmigoFamiliarBuscar)
        {
            throw new NotImplementedException();
        }

        public void DeleteAmigoFamiliar(int AmigoFamiliarId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AmigoFamiliar> GetAllAmigoFamiliar(int migranteId)
        {
            return _appContext.AmigoFamiliars.Where(p => p.FamAmigId == migranteId);
            //return _appContext.Migrantes.Include(x => x.AmigoFamiliars).FirstOrDefault()
        }

        public AmigoFamiliar GetAmigoFamiliar(int AmigoFamiliarId)
        {
            throw new NotImplementedException();
        }

        public AmigoFamiliar UpdateAmigoFamiliar(AmigoFamiliar AmigoFamiliar)
        {
            throw new NotImplementedException();
        }
    }
}
