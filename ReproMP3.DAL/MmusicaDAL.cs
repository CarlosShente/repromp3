using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReproMP3.EN;
using Microsoft.EntityFrameworkCore;
namespace ReproMP3.DAL
{
    public class MmusicaDAL
    {
        public static async Task<int> CrearAsync(Mmusica pMmusica)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pMmusica);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Mmusica pMmusica)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mmusica = await dbContexto.Mmusica.FirstOrDefaultAsync(s => s.Id == pMmusica.Id);
                mmusica.Nombre = pMmusica.Nombre;
                mmusica.Autor = pMmusica.Autor;
                mmusica.Icono = pMmusica.Icono;
                mmusica.Url = pMmusica.Url;
                dbContexto.Update(mmusica);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Mmusica pMmusica)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mmusica = await dbContexto.Mmusica.FirstOrDefaultAsync(s => s.Id == pMmusica.Id);
                dbContexto.Mmusica.Remove(mmusica);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<List<Mmusica>> ObtenerTodosAsync()
        {
            var mmusicas = new List<Mmusica>();
            using (var dbContexto = new DBContexto())
            {
                mmusicas = await dbContexto.Mmusica.ToListAsync();
            }
            return mmusicas;
        }

        public static async Task<Mmusica> ObtenerPorIdAsync(Mmusica pMmusica)
        {
            var mmusica = new Mmusica();
            using (var dbContexto = new DBContexto())
            {
                mmusica = await dbContexto.Mmusica.FirstOrDefaultAsync(s => s.Id == pMmusica.Id);
            }
            return mmusica;
        }

        internal static IQueryable<Mmusica> QuerySelect(IQueryable<Mmusica> pQuery, Mmusica pMmusica)
        {
            if (pMmusica.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMmusica.Id);
            if (!string.IsNullOrWhiteSpace(pMmusica.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pMmusica.Nombre));
            if (!string.IsNullOrWhiteSpace(pMmusica.Autor))
                pQuery = pQuery.Where(s => s.Autor.Contains(pMmusica.Autor));
            if (!string.IsNullOrWhiteSpace(pMmusica.Icono))
                pQuery = pQuery.Where(s => s.Icono.Contains(pMmusica.Icono));
            if (!string.IsNullOrWhiteSpace(pMmusica.Url))
                pQuery = pQuery.Where(s => s.Url.Contains(pMmusica.Url));


            return pQuery;
        }
        public static async Task<List<Mmusica>> BuscarAsync(Mmusica pMmusica)
        {
            var mmusicas = new List<Mmusica>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Mmusica.AsQueryable();
                select = QuerySelect(select, pMmusica);
                mmusicas = await select.ToListAsync();
            }
            return mmusicas;
        }
    }
}
