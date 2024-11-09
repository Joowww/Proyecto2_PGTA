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
        Loading2 loading;
        private Welcome welcome;
        public string FilePathAST { get; set; }
        private bool isDarkMode;
        public ImportAst(Welcome welcome_)
        {
            InitializeComponent();
            this.welcome = welcome_;
            // Set radioButton1 as selected by default
            this.Load += ImportAst_Load;
        }

        private void ImportAst_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
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
                    FilePathAST = openFileDialog.FileName;
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

        private async void acceptBtn_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked && !string.IsNullOrEmpty(FilePathAST))
            {
                // Check if the file has the .ast extension
                if (Path.GetExtension(FilePathAST).ToLower() != ".ast")
                {
                    MessageBox.Show("Please select a file with the .ast extension.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop the process if it is not an .ast file
                }
            }
            else if (radioButton1.Checked)
            {
                FilePathAST = "230502-est-080001_BCN_60MN_08_09.ast";
            }
            else if (radioButton2.Checked)
            {
                FilePathAST = "230502-est-080001_BCN.ast";
            }
            else if (radioButton3.Checked && !string.IsNullOrEmpty(FilePathAST))
            {
                // Custom file already selected
            }
            else
            {
                MessageBox.Show("Please select a file option.", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Show();
            Task oTask = new Task(SL);
            oTask.Start();
            await oTask;
            Hide();

            Principal principal = new Principal(FilePathAST);
            principal.Show();
            this.Close(); // Cerrar ImportAst después de seleccionar
            welcome.Hide();
            
        }

        private void ImportAst_Load_1(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema según el estado guardado
            ApplyTheme();

            // Si el modo oscuro está activo, aplicarlo
            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }
        }

        private void ApplyTheme()
        {
            // Aplica el tema al formulario actual
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        public void SL()
        {
            Thread.Sleep(5000);
        }
        public void Show()
        {
            loading = new Loading2();
            loading.Show();
        }
        public void Hide()
        {
            if (loading != null)
            {
                loading.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

