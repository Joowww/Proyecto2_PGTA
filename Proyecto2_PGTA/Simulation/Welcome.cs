using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace Simulation
{
    public partial class Welcome : Form
    {
        bool sidebarExpand;
        bool AbouUsCollapse;
        bool SettingsCollapse;
        bool HelpCollapse;
        private bool isDarkMode;

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

        private void Welcome_Load(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema al cargar el formulario
            ApplyTheme();

            // Si el modo oscuro está activo, aplicarlo
            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }
        }

        private void ApplyTheme()
        {
            // Aplica el tema al formulario actual
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void buttonSettings_Click_1(object sender, EventArgs e)
        {
            SettingsTimer.Start();
        }

        private void buttonAboutUs_Click_1(object sender, EventArgs e)
        {
            AboutUsTimer.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ya estas en la pantalla Home.", "Instrucciones de uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelp_Click_1(object sender, EventArgs e)
        {
            HelpTimer.Start();
        }

        private void buttonPPolicy_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Group 9 PGTA 2024" +
                "\n\t 2024 AsterixDecoder.org");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Cambia el estado del modo oscuro
            isDarkMode = !isDarkMode;
            ApplyTheme(); // Aplica el nuevo tema

            // Guarda el estado del tema
            Properties.Settings1.Default.IsDarkMode = isDarkMode;
            Properties.Settings1.Default.Save();
        }

        private void buttonGroup_Click_1(object sender, EventArgs e)
        {
            Group9 Group = new Group9();
            // Abrir el Mapa
            Group.Show();
        }

        private void buttonContactUs_Click_1(object sender, EventArgs e)
        {
            Contact Contact = new Contact();
            // Abrir el Mapa
            Contact.Show();
        }

        private void buttonTutorial_Click_1(object sender, EventArgs e)
        {
            Tutorial Tut = new Tutorial();
            // Abrir el Mapa
            Tut.Show();
        }

        private void buttonQRVideoT_Click_1(object sender, EventArgs e)
        {
            VideoTutorial VideoTut = new VideoTutorial();
            // Abrir el Mapa
            VideoTut.Show();
        }

        private void menuButton_Click_1(object sender, EventArgs e)
        {
            // Set timer interval to lowest to make it smoother
            SidebarTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Privacy PPrivacy = new Privacy();
            // Abrir el Mapa
            PPrivacy.Show();
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
