using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region "Campos"
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region "Constructores"
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region "Propiedades"
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Dos Paquetes son iguales si comparten el mísmo TrackingId.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
                return true;
            return false;
        }
        /// <summary>
        /// Dos Paquetes son diferentes si su TrackingId es diferente.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Retorna string con toda la información del Paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}",((Paquete)elemento).trackingID,((Paquete)elemento).direccionEntrega);
        }
        /// <summary>
        /// Publica toda la información del Paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        /// <summary>
        /// Una vez ingresado el paquete cada cuatro segundos cambia de estado y luego se guarda en DB.
        /// </summary>
        public void MockCicloDeVida()
        {
            int j = Enum.GetValues(typeof(EEstado)).Length;
            for (int i = 0; i < j ;i++)
            {
                this.estado = (EEstado)i;
                this.InformaEstado.Invoke(this,new EventArgs());
                if(this.estado != EEstado.Entregado)
                Thread.Sleep(4000);
            }
                PaqueteDAO.Insetar(this);
        }
        #endregion

        #region "Tipos Anidados"
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion
    }
}
