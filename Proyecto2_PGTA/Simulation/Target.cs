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
    public partial class Target : Form
    {
        private Mapa mapa;
        public Target(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            mapa.Enabled = true;
            this.Hide();
        }
    }
}
