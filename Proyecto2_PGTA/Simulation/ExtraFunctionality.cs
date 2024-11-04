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

        private Mapa mapa;
        public ExtraFunctionality(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
        }


        public void targetBtn_Click(object sender, EventArgs e)
        {
            Target target = new Target(mapa);
            target.Show();
            this.Hide();
        }
    }
}
