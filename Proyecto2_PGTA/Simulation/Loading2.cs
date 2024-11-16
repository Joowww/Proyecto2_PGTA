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
            miLoad.Load("Flying airplane.gif");
            miLoad.Location = new Point(this.Width / 2 - miLoad.Width / 2,
                this.Height / 2 - miLoad.Height / 2);
        }
    }
}
