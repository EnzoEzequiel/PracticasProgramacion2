using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Trabajo_Integrador
{
    public partial class FrmCalculadora : Form
    {
        private Numeracion resultadoNumerico;
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private bool esBinario;
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            comboBoxOperacion.Items.Add("+");
            comboBoxOperacion.Items.Add("-");
            comboBoxOperacion.Items.Add("*");
            comboBoxOperacion.Items.Add("/");
            comboBoxOperacion.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void setResultado(string resultado)
        {
            labelResultado.Text = resultado;
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtBoxPrimerOperador.Text, out double primerOperando) &&
                double.TryParse(txtBoxSegundoOperador.Text, out double segundoOperando) &&
                comboBoxOperacion.SelectedItem != null)
            {
                string operacion = comboBoxOperacion.SelectedItem.ToString();
                char oper = operacion[0];

                Numeracion primerNumeracion = new Numeracion(ESistema.Decimal, primerOperando);
                Numeracion segundoNumeracion = new Numeracion(ESistema.Decimal, segundoOperando);

                Operacion operador = new Operacion(primerNumeracion, segundoNumeracion);

                try
                {
                    Numeracion resultado = operador.Operar(oper);
                    if (esBinario)
                    {
                        setResultado(Numeracion.DecimalABinario(resultado.Valor));
                    }
                    else
                    {
                        setResultado(resultado.Valor.ToString());
                    }

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese valores válidos y seleccione una operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBoxPrimerOperador.Clear();
            txtBoxSegundoOperador.Clear();
            comboBoxOperacion.SelectedIndex = 0;
            resultadoNumerico = new Numeracion(ESistema.Decimal, 0.0);
            setResultado("0");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar la calculadora?", "Cerrar Calculadora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void labelRepresentarResultadoEn_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxPrimerOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxSegundoOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            esBinario=false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            esBinario=true;
        }
    }
}
