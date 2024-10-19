using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Welcome : Form
    {
        bool sidebarExpand;
        bool AbouUsCollapse;
        bool SettingsCollapse;
        bool HelpCollapse;
        public Welcome()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            principal.Show();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            //SET the Minimum and maximum size of sidebar Panel
            if (sidebarExpand)
            {
                // If sidebar is expand, minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            // Set timer interval to lowest to make it smoother
            SidebarTimer.Start();
        }

        private void AboutUsTimer_Tick(object sender, EventArgs e)
        {
            if (AbouUsCollapse)
            {
                AboutUsContainer.Height += 10;
                if (AboutUsContainer.Height == AboutUsContainer.MaximumSize.Height)
                {
                    AbouUsCollapse = false;
                    AboutUsTimer.Stop();
                }
            }
            else
            {
                AboutUsContainer.Height -= 10;
                if (AboutUsContainer.Height == AboutUsContainer.MinimumSize.Height)
                {
                    AbouUsCollapse = true;
                    AboutUsTimer.Stop();
                }
            }
        }

        private void buttonAboutUs_Click(object sender, EventArgs e)
        {
            AboutUsTimer.Start();
        }

        private void SettingsTimer_Tick(object sender, EventArgs e)
        {
            if (SettingsCollapse)
            {
                SettingsContainer.Height += 10;
                if (SettingsContainer.Height == SettingsContainer.MaximumSize.Height)
                {
                    SettingsCollapse = false;
                    SettingsTimer.Stop();
                }
            }
            else
            {
                SettingsContainer.Height -= 10;
                if (SettingsContainer.Height == SettingsContainer.MinimumSize.Height)
                {
                    SettingsCollapse = true;
                    SettingsTimer.Stop();
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsTimer.Start();
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group 9 PGTA 2024" +
                "\n\tAlejandro Curiel Molina" +
                "\n\tMarina Martin Ferrer" +
                "\n\tJose Carlos Martínez Conde" +
                "\n\tJoel Moreno de Toro" +
                "\n\tÈrica Parra Moya" +
                "\n\tPaula Valle Bové" +
                "\n\tMireia Viladot Saló");
        }

        private void buttonContactUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group 9 PGTA 2024" +
                "\n\talejandro.curiel.molina@estudiantat.upc.edu" +
                "\n\tmarina.martin.ferrer@estudiantat.upc.edu" +
                "\n\tjose.carlos.martinez.conde@estudiantat.upc.edu" +
                "\n\tjoel.moreno.de.toro@estudiantat.upc.edu " +
                "\n\terica.parra@estudiantat.upc.edu" +
                "\n\tpaula.valle@estudiantat.upc.edu" +
                "\n\tmireia.viladot@estudiantat.upc.edu");
        }

        private void buttonPPolicy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group 9 PGTA 2024" +
                "\n\tAle" +
                "\n\tmarina.martin.ferrer@estudiantat.upc.edu");
        }

        private void HelpTimer_Tick(object sender, EventArgs e)
        {
            if (HelpCollapse)
            {
                HelpContainer.Height += 10;
                if (HelpContainer.Height == HelpContainer.MaximumSize.Height)
                {
                    HelpCollapse = false;
                    HelpTimer.Stop();
                }
            }
            else
            {
                HelpContainer.Height -= 10;
                if (HelpContainer.Height == HelpContainer.MinimumSize.Height)
                {
                    HelpCollapse = true;
                    HelpTimer.Stop();
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpTimer.Start();
        }

        private void buttonQRVideoT_Click(object sender, EventArgs e)
        {
            //Posar QR
        }

        private void buttonTutorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Explicación breve sobre los pasos a seguir para un uso correcto de la aplicación: \n \nPrimero, se deben introducir los datos " +
                "de los vuelos a simular.  \n \nSegundo, añadimos en parámetros de simulación los datos restantes. \n \nTercero le damos a simular. " +
                "Aparecerá el formulario simulación.", "Instrucciones de uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
