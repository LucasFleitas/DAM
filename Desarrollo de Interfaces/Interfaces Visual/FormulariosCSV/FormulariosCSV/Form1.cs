using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulariosCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Datos a guardar
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            int telefono = int.Parse(txtTelefono.Text);
            int edad = int.Parse(txtEdad.Text);

            // Validar que no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || telefono == null || edad == null)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ruta del archivo CSV
            string rutaArchivo = "C:/Users/DAM/Desktop/datos.csv";

            try
            {
                // Verificar si el archivo existe para escribir el encabezado solo la primera vez
                bool archivoExiste = File.Exists(rutaArchivo);

                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    // Escribir encabezado si es la primera vez
                    if (!archivoExiste)
                    {
                        writer.WriteLine("Nombre,Correo,Teléfono,Edad");
                    }

                    // Escribir datos
                    writer.WriteLine($"{nombre},{correo},{telefono},{edad}");
                }

                // Confirmación
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos del formulario
                txtNombre.Clear();
                txtCorreo.Clear();
                txtTelefono.Clear();
                txtEdad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación
            Application.Exit();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
  
}
