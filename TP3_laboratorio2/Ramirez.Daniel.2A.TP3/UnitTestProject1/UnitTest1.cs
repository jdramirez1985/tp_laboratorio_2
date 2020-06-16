using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlumnoPrueba() // Prueba si se instancia un Alumno
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(a1);
            

        }
        [TestMethod]
        
        public void NacionalidadInvalida() // Prueba si se lanza dicha excepción
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni += a1;
            try
            {
               Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, EntidadesInstanciables.Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
               uni += a2;
            }
            catch (Exception e)
            {
               Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
               Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void AlumnoRepetido() // Prueba si se lanza dicha excepción
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni += a1;
            try
            {
               Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
               uni += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
               Console.WriteLine(e.Message);
            }
            try
            {
               Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
               uni += a3;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void ListaInstanciada() // Prueba si se instancia la lista de alumnos en Universidad
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
        }
        
        // Prueba que los caracteres recibidos se carguen en los campos solo si son letras
        [TestMethod]
        public void CaracteresValidos() 
        {
           Alumno a8 = new Alumno(8, "375668", "79S8", "22236456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);

            if (a8.Nombre != "")
                Assert.Fail("Cadena Inválida !!", a8.Nombre);
        }

        [TestMethod]
        public void ValidarNacionalidadDNI() // lanza la excepción si el método de validación de nacionalidad no pudo valiar el dni
        {
            try
            {
                Alumno alumnonacionalidadinvalida = new Alumno(2, "Juana", "Martinez", "12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            try
            {
                Alumno alumnodninvalido = new Alumno(2, "Juan", "Fernandez", "112234458",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
