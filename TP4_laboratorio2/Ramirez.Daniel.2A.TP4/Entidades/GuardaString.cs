using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda en archivo de texto en el Escritorio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, archivo);
            try
            {
                {
                    using (StreamWriter SW = new StreamWriter(path, true))
                    {
                        SW.WriteLine(texto);
                    }
                    
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
