using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReproMP3.EN;
using ReproMP3.DAL;

namespace ReproMP3.BL
{
    public class MmusicaBL
    {
        public async Task<int> CrearAsync(Mmusica pMmusica)
        {
            return await MmusicaDAL.CrearAsync(pMmusica);
        }

        public async Task<int> ModificarAsync(Mmusica pMmusica)
        {
            return await MmusicaDAL.ModificarAsync(pMmusica);
        }

        public async Task<int> EliminarAsync(Mmusica pMmusica)
        {
            return await MmusicaDAL.EliminarAsync(pMmusica);
        }

        public async Task<List<Mmusica>> ObtenerTodosAsync()
        {
            return await MmusicaDAL.ObtenerTodosAsync();
        }

        public async Task<Mmusica> ObtenerPorIdAsync(Mmusica pMmusica)
        {
            return await MmusicaDAL.ObtenerPorIdAsync(pMmusica);
        }

        public async Task<List<Mmusica>> BuscarAsync(Mmusica pMmusica)
        {

            return await MmusicaDAL.BuscarAsync(pMmusica);
        }
    }
}
