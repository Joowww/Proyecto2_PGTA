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

                // Llama al método en el formulario Mapa y obtiene el resultado
                var (filteredMessages, missingTargets) = mapa.Option8(mapa.AllMessages, TA1, TA2);

                if (missingTargets.Count != 0)
                {
                    if (missingTargets.Count == 1)
                    {
                        if (missingTargets[0] == TA1)
                        {
                            MessageBox.Show($"The target address '{TA1}' is not found in the Asterix. Please enter another address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Clear();
                        }
                        else if (missingTargets[0] == TA2)
                        {
                            MessageBox.Show($"The target address '{TA2}' is not found in the Asterix. Please enter another address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Clear();
                        }

                    }
                    else if (missingTargets.Count == 2)
                    {

                        MessageBox.Show("Neither of the two target addresses entered is found in the Asterix. Please enter two different addresses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    // No cerrar el formulario, permite al usuario corregir la entrada
                    return;
                }

                mapa.CalculateDistanceForAircrafts(filteredMessages, TA1 , TA2);
                // Llama al método en el formulario Mapa
                mapa.SetTargetAddresses(filteredMessages);

                mapa.Enabled = true;
                this.Hide(); 



            }
            catch (Exception ex)
            {
                // Handles any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "4A08EB";
            textBox2.Text = "346088";
        }
    }
}
