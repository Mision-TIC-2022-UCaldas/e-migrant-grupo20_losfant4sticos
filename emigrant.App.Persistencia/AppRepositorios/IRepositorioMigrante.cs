using emigrant.App.Dominio;
using System.Collections.Generic;


namespace emigrant.App.Persistencia
{

    public interface IRepositorioMigrante
    {

        Migrante AddMigrante(Migrante Migrante);
        IEnumerable<Migrante> GetAllMigrantes();
        Migrante UpdateMigrante(Migrante migrante);
        void DeleteMigrante(int migranteId);
        public Migrante GetMigrante(int migranteId);
        public IEnumerable<Migrante> BuscarMigrante(string migranteBuscar);
        IEnumerable<Migrante> GetAllMigrantesFamiliarAmigo(int migranteId);
        public Migrante AsignarFamiliarAmigo(int migranteId, AmigoFamiliar familiarAmigoiD);
        List<Migrante> GetFamiliaresAmigos(int migranteId);
        Migrante GetMigranteDocument(string numeroDocumento);
        //public List<Migrante> AddListMigrante(Migrante migrante, int migranteId);
        //public List<Migrante> GetListMigrante(int migranteId);
        void DeleteFamAmig(int famAmigId, int migranteId);
        IEnumerable<Migrante> BuscarMigranteAsignar(string migranteBuscar, int migranteId);
    }




}
