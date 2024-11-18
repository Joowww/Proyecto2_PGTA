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
            //Bitmap bitmap = new Bitmap("Flying airplane.gif");
            //miLoad.Image = bitmap;
            //miLoad.Location = new Point(this.Width / 2 - miLoad.Width / 2,
            //this.Height / 2 - miLoad.Height / 2);
            try
            {
                Image gifImage = Properties.Resources.Flying_airplane;
                miLoad.Image = gifImage;
                miLoad.SizeMode = PictureBoxSizeMode.AutoSize;

                // Centrar el PictureBox
                miLoad.Location = new Point(
                    (this.ClientSize.Width - miLoad.Width) / 2,
                    (this.ClientSize.Height - miLoad.Height) / 2
                );
            }
            catch (Exception ex)
            {
                // Manejar errores al cargar el GIF
                MessageBox.Show($"Error al cargar el GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
