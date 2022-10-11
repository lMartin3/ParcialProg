using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialMartinLuraschiEj2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void MostrarErrorCliente()
        {
            MessageBox.Show("Usted debe ingresar el nombre del cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarErrorValor(int filaIndex, string campo)
        {
            MessageBox.Show(string.Format("El campo \"{0}\" en la columna {1} contiene un valor no numérico", campo, filaIndex + 1), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnPresupuestar_Click(object sender, EventArgs e)
        {
            if (tbNombreCliente.Text == "")
            {
                MostrarErrorCliente();
                return;
            }

            string resultado = "Presupuesto para el cliente " + tbNombreCliente.Text + "\r\n"; //TODO nombre cliente
            int precioTotal = 0;
            for (int i = 0; i < presupuesto.Rows.Count; i++)
            {
                if (presupuesto.Rows[i].Cells[0].Value == null) continue;
                string producto = presupuesto.Rows[i].Cells[0].Value.ToString();
                int cantidad = 0;
                bool parsedFirst = int.TryParse(presupuesto.Rows[i].Cells[1].Value.ToString(), out cantidad);
                if (!parsedFirst)
                {
                    MostrarErrorValor(i, "cantidad");
                }
                int precioUnitario = 0;
                bool parsedSecond = int.TryParse(presupuesto.Rows[i].Cells[2].Value.ToString(), out precioUnitario);
                if (!parsedSecond)
                {
                    MostrarErrorValor(i, "precio unitario");
                }
                int precioPruducto = precioUnitario * cantidad;
                precioTotal += precioPruducto;
                resultado += String.Format("{0}x {1} a ${2} p/u (subtotal ${3})\r\n", cantidad, producto, precioUnitario, precioPruducto);
            }
            resultado += string.Format("\r\n\r\nTOTAL DEL PRESUPUESTO: ${0}", precioTotal);
            tbResultado.Text = resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbNombreCliente.Text = "";
            tbResultado.Text = "";
            while(presupuesto.Rows.Count>=2)
            {
                presupuesto.Rows.RemoveAt(0);
            }

        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ((Button)sender).FindForm().Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
