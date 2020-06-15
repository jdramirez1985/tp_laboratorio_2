using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{/// <summary>
/// Implementa interface IArchivo con un tipo genérico para recibir cualquier tipo.
/// </summary>
/// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T> 
    {
        /// <summary>
        /// Serializa en XML cualquier tipo pedido.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter xtw = new XmlTextWriter(archivo, Encoding.UTF8)) 
                {
                    XmlSerializer sx = new XmlSerializer(typeof(T)); 

                    sx.Serialize(xtw, datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Deserializa en XML cualquier tipo pedido.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader xtr = new XmlTextReader(archivo))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    datos = (T)xs.Deserialize(xtr); 
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
