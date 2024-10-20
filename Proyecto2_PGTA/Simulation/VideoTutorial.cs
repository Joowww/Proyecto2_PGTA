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
    public partial class VideoTutorial : Form
    {
        private bool isDarkMode;
        public VideoTutorial()
        {
            InitializeComponent();
        }

        private void VideoTutorial_Load(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw QR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox2.Image = QR.Draw("https://www.youtube.com/", 10);

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

        private void label3_Click(object sender, EventArgs e)
        {
            string url = "https://www.tu-enlace.com";

            try
            {
                // Usar ProcessStartInfo para manejar el protocolo correctamente
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el enlace: " + ex.Message);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Welcome Welc = new Welcome();
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            Welc.Show();
        }
    }
}
