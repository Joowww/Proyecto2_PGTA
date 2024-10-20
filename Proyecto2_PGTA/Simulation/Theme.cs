using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    internal class Theme
    {
        public static void SetDarkMode(Control control)
        {
            control.BackColor = Color.FromArgb(45, 45, 48);
            control.ForeColor = Color.White;

            // Cambiar el color del sidebar si es el correcto
            if (control.Name == "sidebar") // Verificar si el control es el sidebar
            {
                control.BackColor = Color.Silver; // Color específico para el sidebar en modo oscuro
            }

            foreach (Control c in control.Controls)
            {
                SetDarkMode(c);
            }
        }

        public static void SetLightMode(Control control)
        {
            control.BackColor = Color.White;
            control.ForeColor = Color.Black;

            // Cambiar el color del sidebar si es el correcto
            if (control.Name == "sidebar") // Verificar si el control es el sidebar
            {
                control.BackColor = Color.FromArgb(35, 40, 45); // Color específico para el sidebar en modo claro
            }

            foreach (Control c in control.Controls)
            {
                SetLightMode(c);
            }
        }
    }
}
