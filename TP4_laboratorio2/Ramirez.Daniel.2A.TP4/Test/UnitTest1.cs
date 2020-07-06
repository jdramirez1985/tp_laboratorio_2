using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testeo de instanciación Correo.
        /// </summary>
        [TestMethod]
        public void TestInstancia()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        /// <summary>
        /// Testeo de Paquetes iguales.
        /// </summary>
        [TestMethod]
        public void TestPaqueteDuplicado()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Corrientes", "930");
            Paquete p2 = new Paquete("Corrientes", "930");

            correo += p1;
            try
            {
                correo += p2;
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }
        
    }
}
