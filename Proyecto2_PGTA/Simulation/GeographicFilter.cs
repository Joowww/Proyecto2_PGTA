using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class GeographicFilter : Form
    {
        private Principal principal;
        public double MinLatitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLongitude { get; set; }
        private bool isDarkMode;

        public GeographicFilter(Principal principal_)
        {
            InitializeComponent();
            this.principal = principal_;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MinLatitude = double.Parse(textBox1.Text);
                MaxLatitude = double.Parse(textBox2.Text);
                MinLongitude = double.Parse(textBox3.Text);
                MaxLongitude = double.Parse(textBox4.Text);

                // Validate that minimum values are less than maximum values
                if (MinLatitude > MaxLatitude)
                {
                    throw new ArgumentException("Minimum latitude cannot be greater than maximum latitude.");
                }

                if (MinLongitude > MaxLongitude)
                {
                    throw new ArgumentException("Minimum longitude cannot be greater than maximum longitude.");
                }

                this.Close();
                principal.Enabled = false;

            }
            catch (FormatException)
            {
                // Handles the case when input is not a valid number
                MessageBox.Show("Please enter valid numeric values for latitude and longitude.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handles any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            // Asignar valores predeterminados
            MinLatitude = 40.9;
            MaxLatitude = 41.7;
            MinLongitude = 1.5;
            MaxLongitude = 2.6;

            // Mostrar los valores en los textboxes
            textBox1.Text = MinLatitude.ToString();
            textBox2.Text = MaxLatitude.ToString();
            textBox3.Text = MinLongitude.ToString();
            textBox4.Text = MaxLongitude.ToString();
        }

        private void GeographicFilter_Load(object sender, EventArgs e)
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
