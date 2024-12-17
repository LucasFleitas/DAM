using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FormulariosCSV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            string rutaArchivo = "C:/Users/DAM/Desktop/datos.csv";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("El archivo de datos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable tabla = new DataTable();
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (lineas.Length > 0)
                {
                    // Crear un diccionario para rastrear nombres duplicados
                    Dictionary<string, int> contadorEncabezados = new Dictionary<string, int>();

                    // Añadir columnas a la tabla desde la primera línea
                    string[] encabezados = lineas[0].Split(',');
                    foreach (string encabezado in encabezados)
                    {
                        string nombreColumna = encabezado;

                        // Si ya existe el encabezado, añadir sufijo numérico
                        if (contadorEncabezados.ContainsKey(encabezado))
                        {
                            contadorEncabezados[encabezado]++;
                            nombreColumna = $"{encabezado}_{contadorEncabezados[encabezado]}";
                        }
                        else
                        {
                            contadorEncabezados[encabezado] = 1;
                        }

                        tabla.Columns.Add(nombreColumna);
                    }

                    // Añadir filas a la tabla desde las líneas restantes
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        string[] datos = lineas[i].Split(',');

                        // Asegurarse de que la cantidad de datos coincida con las columnas
                        while (datos.Length < tabla.Columns.Count)
                        {
                            Array.Resize(ref datos, tabla.Columns.Count);
                        }

                        tabla.Rows.Add(datos);
                    }
                }

                dataGridView1.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
