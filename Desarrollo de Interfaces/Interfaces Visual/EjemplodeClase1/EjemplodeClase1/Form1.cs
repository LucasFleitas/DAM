using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemplodeClase1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cbEjemplo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var nuevaCita = new Cita
            {
                Nombre = txtNombre.Text,
                Fecha = datePicker.Value,
                Hora = datePicker.Value.ToShortTimeString()
            };
            citas.Add(nuevaCita);
            MessageBox.Show("Cita reservada.");
            ActualizarListaCitas();
        }
    }
}
