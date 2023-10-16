using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReproMP3.BL;
using ReproMP3.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproMP3.BL.Tests
{
    [TestClass()]
    public class CcarpetaBLTests
    {
        private static Ccarpeta ccarpetaInicial = new Ccarpeta { Id = 5 };//Ccarpeta existente en la DB
        private CcarpetaBL ccarpetaBL = new CcarpetaBL();
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var ccarpeta = new Ccarpeta();
            ccarpeta.Nombre = "La Nota";
            ccarpeta.Genero = "Reggeton";
            ccarpeta.Icono = "imagen";
            int result = await ccarpetaBL.CrearAsync(ccarpeta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var ccarpeta = new Ccarpeta();
            ccarpeta.Id = ccarpetaInicial.Id;
            ccarpeta.Nombre = "Chachacha";
            ccarpeta.Genero = "Clasico";
            ccarpeta.Icono = "imagen";
            int result = await ccarpetaBL.ModificarAsync(ccarpeta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerTodosAsyncTest()
        {
            var result = await ccarpetaBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var ccarpeta = new Ccarpeta();
            ccarpeta.Id = ccarpetaInicial.Id;
            var resultCarpeta = await ccarpetaBL.ObtenerPorIdAsync(ccarpeta);
            Assert.AreEqual(ccarpeta.Id, resultCarpeta.Id);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var ccarpeta = new Ccarpeta();
            ccarpeta.Nombre = "Chachacha";
            ccarpeta.Genero = "Clasico";
            ccarpeta.Icono = "imagen";
            var resultCarpetas= await ccarpetaBL.BuscarAsync(ccarpeta);
            Assert.AreNotEqual(0, resultCarpetas.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()//Eliminar carpeta
        {
            var ccarpeta = new Ccarpeta();
            ccarpeta.Id = ccarpetaInicial.Id;
            int result = await ccarpetaBL.EliminarAsync(ccarpeta);
            Assert.AreNotEqual(0, result);
        }
    }
}