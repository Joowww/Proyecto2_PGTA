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
    public partial class Mapa : Form
    {
        public Mapa()
        {
            InitializeComponent();
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Option 1");
            comboBox1.Items.Add("Option 2");
            comboBox1.Items.Add("Option 3");

            comboBox2.Items.Add("Option 1");
            comboBox2.Items.Add("Option 2");
            comboBox2.Items.Add("Option 3");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
