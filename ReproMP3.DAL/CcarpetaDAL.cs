using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReproMP3.EN;
using Microsoft.EntityFrameworkCore;

namespace ReproMP3.DAL
{
    public class CcarpetaDAL
    {
        public static async Task<int> CrearAsync(Ccarpeta pCcarpeta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pCcarpeta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Ccarpeta pCcarpeta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var ccarpeta = await dbContexto.Dcarpeta.FirstOrDefaultAsync(s => s.Id == pCcarpeta.Id);
                ccarpeta.Nombre = pCcarpeta.Nombre;
                ccarpeta.Genero = pCcarpeta.Genero;
                ccarpeta.Icono = pCcarpeta.Icono;
                dbContexto.Update(ccarpeta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Ccarpeta pCcarpeta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var ccarpeta = await dbContexto.Dcarpeta.FirstOrDefaultAsync(s => s.Id == pCcarpeta.Id);
                dbContexto.Dcarpeta.Remove(ccarpeta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<List<Ccarpeta>> ObtenerTodosAsync()
        {
            var ccarpetas = new List<Ccarpeta>();
            using (var dbContexto = new DBContexto())
            {
                ccarpetas = await dbContexto.Dcarpeta.ToListAsync();
            }
            return ccarpetas;
        }

        public static async Task<Ccarpeta> ObtenerPorIdAsync(Ccarpeta pCcarpeta)
        {
            var ccarpeta = new Ccarpeta();
            using (var dbContexto = new DBContexto())
            {
                ccarpeta = await dbContexto.Dcarpeta.FirstOrDefaultAsync(s => s.Id == pCcarpeta.Id);
            }
            return ccarpeta;
        }

        internal static IQueryable<Ccarpeta> QuerySelect(IQueryable<Ccarpeta> pQuery, Ccarpeta pCcarpeta)
        {
            if (pCcarpeta.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCcarpeta.Id);
            if (!string.IsNullOrWhiteSpace(pCcarpeta.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCcarpeta.Nombre));
            if (!string.IsNullOrWhiteSpace(pCcarpeta.Genero))
                pQuery = pQuery.Where(s => s.Genero.Contains(pCcarpeta.Genero));
            if (!string.IsNullOrWhiteSpace(pCcarpeta.Icono))
                pQuery = pQuery.Where(s => s.Icono.Contains(pCcarpeta.Icono));



            return pQuery;
        }
        public static async Task<List<Ccarpeta>> BuscarAsync(Ccarpeta pCcarpeta)
        {
            var ccarpetas = new List<Ccarpeta>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Dcarpeta.AsQueryable();
                select = QuerySelect(select, pCcarpeta);
                ccarpetas = await select.ToListAsync();
            }
            return ccarpetas;
        }
    }
}
