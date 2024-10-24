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
    public partial class CloseApp : Form
    {
        private bool isDarkMode;
        private Mapa mapa_;
        public CloseApp(Mapa mapa)
        {
            InitializeComponent();
            this.mapa_ = mapa;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            mapa_.Enabled = true;
            this.Hide();
        }

        private void CloseApp_Load(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema según el estado guardado
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
    }
}
