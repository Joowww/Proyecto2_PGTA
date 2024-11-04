using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simulation
{
    public partial class Target : Form
    {

        private Mapa mapa;
        public Target(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
        }
        public void acceptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TA1 = textBox1.Text;
                string TA2 = textBox2.Text;

                // Validate that minimum values are less than maximum values
                if ((TA1.Length != 6) || (TA2.Length != 6))
                {
                    throw new ArgumentException("The target address must contain 6 characters.");
                }

                // Llama al método en el formulario Mapa
                mapa.SetTargetAddresses(TA1, TA2);

                this.Hide(); // Cierra el formulario y dispara el evento FormClosed
                mapa.Enabled = true;

            }
            catch (Exception ex)
            {
                // Handles any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
