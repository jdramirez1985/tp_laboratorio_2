using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{/// <summary>
/// Implementa interface genérica IArchivo para recibir tipo string.
/// </summary>
    public class Texto : IArchivo<string>  
    {
        /// <summary>
        /// Guarda un string en archivo de Texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {

            try
            {
                using (StreamWriter SW = new StreamWriter(archivo, true))
                {
                    SW.WriteLine(datos); 
                }
                return true;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// Abre un archivo de Texto y devuelve los datos en una cadena de caracteres.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                if (File.Exists(archivo))
                {
                    using (StreamReader SR = new StreamReader(archivo))
                    {
                        datos = SR.ReadToEnd();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            datos = "";
            return false;
        }
    }
}
