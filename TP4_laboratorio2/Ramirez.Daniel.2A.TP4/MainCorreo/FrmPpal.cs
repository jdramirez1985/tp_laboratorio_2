using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region "Campos"
        private Correo correo;
        #endregion

        #region "Constructor"
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Se agrega un Paquete al correo y comienza el ciclo de vida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text); 
                try
                {
                    this.correo += paquete;
                    paquete.InformaEstado += this.paq_InformaEstado;
                }
                catch (TrackingIdRepetidoException exc)
                {
                    string mensaje = exc.InnerException.Message;
                    mensaje += exc.Message;
                    MessageBox.Show(mensaje);
                }
                
                this.ActualizarEstados();
        }
        /// <summary>
        /// Cierra todos los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            correo.FinEntregas();
        }
        /// <summary>
        /// Actualiza el estado del Paquete.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }
        /// <summary>
        /// Actualiza en informa estado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Muesta la información del Paquete en el rtb y lo guarda en texto en el escritorio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }
            if( !(elemento.MostrarDatos(elemento).Guardar("salida.txt")) )
            {
                MessageBox.Show("Error al guardar en texto");
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        #endregion

    }
}
