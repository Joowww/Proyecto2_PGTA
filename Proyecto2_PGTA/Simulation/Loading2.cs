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
    public partial class Loading2 : Form
    {
        public Loading2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// It loads and centers a GIF called "Flying airplane.gif" on the form when it loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loading2_Load(object sender, EventArgs e)
        {
            try
            {
                Image gifImage = Properties.Resources.Flying_airplane;
                miLoad.Image = gifImage;
                miLoad.SizeMode = PictureBoxSizeMode.AutoSize;
                miLoad.Location = new Point(
                    (this.ClientSize.Width - miLoad.Width) / 2,
                    (this.ClientSize.Height - miLoad.Height) / 2
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
