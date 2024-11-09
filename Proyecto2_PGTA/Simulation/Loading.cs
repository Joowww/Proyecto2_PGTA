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
    public partial class Loading : Form
    {
        Loading2 loading;
        private bool isDarkMode;
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
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

        private async void button1_Click(object sender, EventArgs e)
        {
            Show();
            Task oTask = new Task(SL);
            oTask.Start();
            await oTask;
            Hide();
        }
        public void SL()
        {
            Thread.Sleep(3000);
        }
        public void Show()
        {
            loading=new Loading2();
            loading.Show();
        }
        public void Hide()
        {
            if (loading != null)
            {
                loading.Close();
            }
        }
    }
}
