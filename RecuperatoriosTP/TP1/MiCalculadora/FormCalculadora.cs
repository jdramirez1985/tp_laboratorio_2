using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperar.Text)).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperar.SelectedItem = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Entidades.Numero n = new Entidades.Numero();
            if (this.lblResultado.Text != "") 
                this.lblResultado.Text = n.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Entidades.Numero n = new Entidades.Numero();
            if(this.lblResultado.Text != "")
                this.lblResultado.Text = n.BinarioDecimal(this.lblResultado.Text);
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Entidades.Numero n1 = new Entidades.Numero(numero1);
            Entidades.Numero n2 = new Entidades.Numero(numero2);
            return Entidades.Calculadora.Operar(n1,n2,operador);
        }
    }
}
