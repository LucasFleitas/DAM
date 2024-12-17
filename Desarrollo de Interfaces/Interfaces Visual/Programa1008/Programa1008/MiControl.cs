using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa1008
{
    internal class MiControl : Button
    {
        private bool gigante = true; // Por defecto, es verdadero.

        [Description("Indica si el botón crecerá al pasar el mouse sobre él."), Category("Comportamiento"), DefaultValue(true)]
        public bool Gigante
        {
            get => gigante;
            set => gigante = value;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (gigante) // Si la propiedad es verdadera.
            {
                this.Size = new Size(150, 150); // Cambia el tamaño del botón.
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (gigante) // Si la propiedad es verdadera.
            {
                this.Size = new Size(100, 50); // Restaura el tamaño predeterminado.
            }
        }

    }
}
