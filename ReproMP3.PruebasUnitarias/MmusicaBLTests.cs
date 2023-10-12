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
        public void EliminarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerTodosAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarAsyncTest()
        {
            Assert.Fail();
        }
    }
}