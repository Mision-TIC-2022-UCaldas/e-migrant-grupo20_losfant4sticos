using emigrant.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace emigrant.App.Persistencia
{

    public class RepositorioMigrante : IRepositorioMigrante
    {
        private readonly AppContextDb _appContext;
        public RepositorioMigrante(AppContextDb appContext)
        {
            _appContext = appContext;
        }

        Migrante IRepositorioMigrante.AddMigrante(Migrante migrante)
        {
            var migranteAdicionado = _appContext.Migrantes.Add(migrante);
            _appContext.SaveChanges();
            return migranteAdicionado.Entity;
        }

        void IRepositorioMigrante.DeleteMigrante(int migranteId)
        {
            var migranteEncontrado = _appContext.Migrantes.FirstOrDefault(p => p.MigranteId == migranteId);
            if (migranteEncontrado == null)
                return;
            _appContext.Migrantes.Remove(migranteEncontrado);
            _appContext.SaveChanges();

        }


        IEnumerable<Migrante> IRepositorioMigrante.GetAllMigrantes()
        {

            return _appContext.Migrantes;
        }


        public Migrante GetMigrante(int migranteId)
        {
            var MigranteGet = _appContext.Migrantes.FirstOrDefault(m => m.MigranteId == migranteId);
            return MigranteGet;

        }
        public IEnumerable<Migrante> BuscarMigrante(string migranteBuscar)
        {
            return _appContext.Migrantes.Where(p => p.Nombre == migranteBuscar || p.Apellidos == migranteBuscar || p.NumeroDocumento == migranteBuscar || p.NumeroTelefono == migranteBuscar);
            //|| p.SituacionLaboral == bool.Parse(migranteBuscar)
        }

        Migrante IRepositorioMigrante.UpdateMigrante(Migrante migrante)
        {
            var propietarioEncontrado = _appContext.Migrantes.FirstOrDefault(p => p.MigranteId == migrante.MigranteId);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Nombre = migrante.Nombre;
                propietarioEncontrado.Apellidos = migrante.Apellidos;
                propietarioEncontrado.TipoDocumento = migrante.TipoDocumento;
                propietarioEncontrado.NumeroDocumento = migrante.NumeroDocumento;
                propietarioEncontrado.NumeroTelefono = migrante.NumeroTelefono;
                propietarioEncontrado.DireccionActual = migrante.DireccionActual;
                propietarioEncontrado.SituacionLaboral = migrante.SituacionLaboral;
                propietarioEncontrado.PaisOrigen = migrante.PaisOrigen;
                propietarioEncontrado.FechaNacimiento = migrante.FechaNacimiento;
                propietarioEncontrado.DirrecionElectronica = migrante.DirrecionElectronica;
                propietarioEncontrado.CiudadResidencia = migrante.CiudadResidencia;




                _appContext.SaveChanges();

            }


            return propietarioEncontrado;

        }

        public IEnumerable<Migrante> GetAllMigrantesFamiliarAmigo(int migranteId)
        {
            return _appContext.Migrantes.Include(x => x.AmigoFamiliar).Where(m => m.MigranteId == migranteId);
        }

        public Migrante AsignarFamiliarAmigo(int migranteId, AmigoFamiliar familiarAmigo)
        {
            var migrante = _appContext.Migrantes.Include(x => x.AmigoFamiliar).FirstOrDefault(m => m.MigranteId == migranteId);
            migrante.AmigoFamiliar.Add(familiarAmigo);
            _appContext.SaveChanges();
            return migrante;



        }


        public List<Migrante> GetFamiliaresAmigos(int migranteId)
        {
            try
            {
                var migrante = _appContext.Migrantes.Include(x => x.AmigoFamiliar).FirstOrDefault(p => p.MigranteId == migranteId);
                List<Migrante> amigofamiliarencontrado = new List<Migrante>();
                if (migrante != null)
                {
                    foreach (var amigoFamiliar in migrante.AmigoFamiliar)
                    {
                        amigofamiliarencontrado.Add(_appContext.Migrantes.FirstOrDefault(m => m.MigranteId == amigoFamiliar.FamAmigId));
                    }
                    return amigofamiliarencontrado;
                }
                return null;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        public Migrante GetMigranteDocument(string numeroDocumento)
        {
            return _appContext.Migrantes.FirstOrDefault(m => m.NumeroDocumento == numeroDocumento);
        }

        public void DeleteFamAmig(int famAmigId, int migranteId)
        {
            var migrante = _appContext.Migrantes.Include(x => x.AmigoFamiliar).FirstOrDefault(m => m.MigranteId == migranteId);

            foreach (var familiarAmigo in migrante.AmigoFamiliar)
            {
                if (migrante.AmigoFamiliar != null)
                {
                    if (familiarAmigo.FamAmigId == famAmigId)
                    {
                        migrante.AmigoFamiliar.Remove(familiarAmigo);
                        _appContext.AmigoFamiliars.Remove(familiarAmigo);
                        _appContext.SaveChanges();
                    }
                }
                break;
            }


        }
        public IEnumerable<Migrante> BuscarMigranteAsignar(string migranteBuscar, int migranteId)
        {
            return _appContext.Migrantes.Where(p => p.NumeroDocumento == migranteBuscar && p.MigranteId != migranteId);
            //|| p.SituacionLaboral == bool.Parse(migranteBuscar)
        }
    }
}
