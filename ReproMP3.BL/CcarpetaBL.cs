using ReproMP3.DAL;
using ReproMP3.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproMP3.BL
{
    internal class CcarpetaBL
    {
        public async Task<int> CrearAsync(Ccarpeta pCcarpeta)
        {
            return await CcarpetaDAL.CrearAsync(pCcarpeta);
        }

        public async Task<int> ModificarAsync(Ccarpeta pCcarpeta)
        {
            return await CcarpetaDAL.ModificarAsync(pCcarpeta);
        }

        public async Task<int> EliminarAsync(Ccarpeta pCcarpeta)
        {
            return await CcarpetaDAL.EliminarAsync(pCcarpeta);
        }

        public async Task<List<Ccarpeta>> ObtenerTodosAsync()
        {
            return await CcarpetaDAL.ObtenerTodosAsync();
        }

        public async Task<Ccarpeta> ObtenerPorIdAsync(Ccarpeta pCcarpeta)
        {
            return await CcarpetaDAL.ObtenerPorIdAsync(pCcarpeta);
        }

        public async Task<List<Ccarpeta>> BuscarAsync(Ccarpeta pCcarpeta)
        {

            return await CcarpetaDAL.BuscarAsync(pCcarpeta);
        }
    }
}
