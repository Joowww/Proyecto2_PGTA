using AstDecoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simulation
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Agregar elementos al ComboBox
            comboBox1.Items.Add("All data");
            comboBox1.Items.Add("Removing pure blanks");
            comboBox1.Items.Add("Removing fixed transponders");
            comboBox1.Items.Add("Combination of these");

            Zen.Barcode.CodeQrBarcodeDraw QR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox2.Image = QR.Draw("HOLA", 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mapa mapa = new Mapa();
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            //mapa.Show();
        }
    }
}