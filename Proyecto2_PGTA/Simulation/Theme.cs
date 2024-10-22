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
            //control.BackColor = Color.FromArgb(45, 45, 48);
            //control.ForeColor = Color.White;

            // Cambiar el color del sidebar si es el correcto
            //if (control.Name == "sidebar") // Verificar si el control es el sidebar
            //{
            // control.BackColor = Color.Silver; // Color específico para el sidebar en modo oscuro
            //}

            //foreach (Control c in control.Controls)
            //{

            //SetDarkMode(c);
            //}

            // Si el control es el FlowLayoutPanel llamado "sidebar", no cambiamos su color ni el de sus hijos
            if (control is FlowLayoutPanel && control.Name == "sidebar")
            {
                control.BackColor = Color.Silver; // Color fijo para el sidebar en modo oscuro
                return; // No cambiar los colores de los controles dentro del sidebar
            }

            // Si el control es hijo del "sidebar", no se cambia el color
            if (control.Parent is FlowLayoutPanel && control.Parent.Name == "sidebar")
            {
                return; // No aplicar cambios de color a los controles dentro del sidebar
            }

            // Aplicar el modo oscuro al resto de controles
            control.BackColor = Color.FromArgb(45, 45, 48); // Fondo oscuro
            control.ForeColor = Color.White; // Texto blanco

            // Aplicar el modo oscuro a los controles hijos
            foreach (Control c in control.Controls)
            {
                SetDarkMode(c);
            }
        }

        public static void SetLightMode(Control control)
        {
            //control.BackColor = Color.White;
            //control.ForeColor = Color.Black;

            // Cambiar el color del sidebar si es el correcto
            //if (control.Name == "sidebar") // Verificar si el control es el sidebar
            //{
            //control.BackColor = Color.FromArgb(35, 40, 45); // Color específico para el sidebar en modo claro
            //}

            //foreach (Control c in control.Controls)
            //{
            //SetLightMode(c);
            //}

            // Si el control es el FlowLayoutPanel llamado "sidebar", no cambiamos su color ni el de sus hijos
            if (control is FlowLayoutPanel && control.Name == "sidebar")
            {
                control.BackColor = Color.Silver; // Color específico para Light Mode
                return; // No cambiar los colores de los controles dentro del sidebar
            }

            // Si el control es hijo del "sidebar", no se cambia el color
            if (control.Parent is FlowLayoutPanel && control.Parent.Name == "sidebar")
            {
                return; // No aplicar cambios de color a los controles dentro del sidebar
            }

            // Aplicar el modo claro al resto de controles
            control.BackColor = Color.White; // Fondo claro
            control.ForeColor = Color.FromArgb(45, 45, 48); // Texto negro

            // Aplicar el modo claro a los controles hijos
            foreach (Control c in control.Controls)
            {
                SetLightMode(c);
            }
        }
    }
}
