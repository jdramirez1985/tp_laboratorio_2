using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region "Campos"
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region "Constructores"
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region "Propiedades"
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Cierra todos los hilos en ejecución en Correo.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }
        /// <summary>
        /// Agrega un Paquete a la lista solo si no se encuentra, luego crea un hilo para ejecutar el ciclo de vida.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            try
            {
                foreach (Paquete item in c.paquetes)
                {
                    if (item == p)
                        throw new TrackingIdRepetidoException("el paquete ya existe");
                }
                c.paquetes.Add(p);
                Thread t1 = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(t1);
                t1.Start();
            }
            catch(TrackingIdRepetidoException e)
            {
                throw new TrackingIdRepetidoException("Error al agregar paquete",e);
            }
            
            return c;
        }
        /// <summary>
        /// Muestra todos los Paquetes en la lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder s = new StringBuilder();
            foreach (Paquete paquete in (List<Paquete>)((Correo)elementos).paquetes)
            {
                s.AppendLine(string.Format( "{0} ({1})",paquete.ToString(),paquete.Estado.ToString() ));
            }
            return s.ToString();
        }
        #endregion
    }
}
