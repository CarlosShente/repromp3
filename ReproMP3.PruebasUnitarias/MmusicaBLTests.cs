using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReproMP3.BL;
using ReproMP3.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ReproMP3.BL.Tests
{
    [TestClass()]
    public class MmusicaBLTests
    {

        private static Mmusica mmusicaInicial = new Mmusica { Id = 8 };//Mmusica existente en la DB
        private MmusicaBL mmusicaBL = new MmusicaBL();
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var mmusica = new Mmusica();
            mmusica.Nombre = "La Nota";
            mmusica.Autor = "Manuel";
            mmusica.Icono = "imagen";
            mmusica.Url = "fffffffffff";
            int result = await mmusicaBL.CrearAsync(mmusica);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task  T2ModificarAsyncTest()
        {
            var mmusica  = new Mmusica();
            mmusica.Id = mmusicaInicial.Id;
            mmusica.Nombre = "La Curiosidad";
            mmusica.Autor = "Mike Towers ";
            mmusica.Icono = "imagen 2";
            mmusica.Url = "bbbbbbbbbbbbb";
            int result = await mmusicaBL.ModificarAsync(mmusica);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerTodosAsyncTest()
        {
            var result = await mmusicaBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var mmusica = new Mmusica();
            mmusica.Id = mmusicaInicial.Id;
            var resultMmusica = await mmusicaBL.ObtenerPorIdAsync(mmusica);
            Assert.AreEqual(mmusica.Id, resultMmusica.Id);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var mmusica = new Mmusica ();
            mmusica.Nombre = "La Curiosidad";
            mmusica.Autor = "Mike Towers ";
            mmusica.Icono = "imagen 2";
            mmusica.Url = "bbbbbbbbbbbbb";
            var resultMmusicas = await mmusicaBL.BuscarAsync(mmusica);
            Assert.AreNotEqual(0, resultMmusicas.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var mmusica = new Mmusica();
            mmusica.Id = mmusicaInicial.Id;
            int result = await mmusicaBL.EliminarAsync(mmusica);
            Assert.AreNotEqual(0, result);
        }
    }
}