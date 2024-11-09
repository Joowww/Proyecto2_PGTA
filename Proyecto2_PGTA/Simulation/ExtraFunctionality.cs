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
    public partial class ExtraFunctionality : Form
    {
        private bool isDarkMode;

        private Mapa mapa;
        public ExtraFunctionality(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
        }


        public void targetBtn_Click(object sender, EventArgs e)
        {

            Target target = new Target(mapa);
            mapa.Enabled = false;
            target.Show();
            this.Hide();
        }

        private void ExtraFunctionality_Load(object sender, EventArgs e)
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
