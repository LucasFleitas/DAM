using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ClimaApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            long sunrise = 1672547200; // Ejemplo de hora de amanecer en segundos Unix (puedes calcularla o obtenerla de una API)
            long sunset = 1672582800; // Ejemplo de hora de atardecer en segundos Unix (puedes calcularla o obtenerla de una API)

            ChangeBackground(sunrise, sunset);
        }

        private void ChangeBackground(long sunrise, long sunset)
        {
            // Obtener la hora actual en formato UTC (tiempo Unix)
            long currentTime = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            // Determinar si es de día o de noche comparando con las horas de amanecer y atardecer
            if (currentTime >= sunrise && currentTime <= sunset)
            {
                // Es de día, usar la imagen de fondo de día (PNG)
                this.Background = new ImageBrush(new BitmapImage(new Uri("C:/Users/DAM/source/repos/ClimaApp/ClimaApp/imagenes/day_background.png")));
            }
            else
            {
                // Es de noche, usar la imagen de fondo de noche (PNG)
                this.Background = new ImageBrush(new BitmapImage(new Uri("C:/Users/DAM/source/repos/ClimaApp/ClimaApp/imagenes/night_background.png")));
            }
        }
    }
}
