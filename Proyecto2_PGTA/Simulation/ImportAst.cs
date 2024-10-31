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
    public partial class ImportAst : Form
    {
        private Welcome welcome;
        public ImportAst(Welcome welcome_)
        {
            InitializeComponent();
            this.welcome = welcome_;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            // Selecciona automáticamente el RadioButton "Custom File"
            radioButton3.Checked = true;

            // Crear y mostrar el OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar el nombre del archivo en la Label
                    label1.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        // Limpiar el nombre del archivo si se eligen las otras opciones
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                label1.Text = "";  // Limpiar el Label cuando se cambia la selección
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia de ImportAst antes de mostrarla
            Principal principal = new Principal();
            this.Hide();
            welcome.Hide();
            principal.Show();
        }
    }
}
