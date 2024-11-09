using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recLbl1;
        private Rectangle recPtb1;
        private Rectangle recGb1;
        private Rectangle recRb1;
        private Rectangle recRb2;
        private Rectangle recRb3;
        public ImportAst(Welcome welcome_)
        {
            InitializeComponent();
            this.welcome = welcome_;
            // Set radioButton1 as selected by default
            this.Load += ImportAst_Load;
            this.Resize += ImportAst_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(browseBtn.Location, browseBtn.Size);
            recBut2 = new Rectangle(button1.Location, button1.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recGb1 = new Rectangle(groupBox1.Location, groupBox1.Size);
            recRb1 = new Rectangle(radioButton1.Location, radioButton1.Size);
            recRb2 = new Rectangle(radioButton2.Location, radioButton2.Size);
            recRb3 = new Rectangle(radioButton3.Location, radioButton3.Size);
        }

        private void ImportAst_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(browseBtn, recBut1);
                resize_Control(button1, recBut2);
                resize_Control(label1, recLbl1);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(groupBox1, recGb1);
                resize_Control(radioButton1, recRb1);
                resize_Control(radioButton2, recRb2);
                resize_Control(radioButton3, recRb3);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(browseBtn, recBut1);
                restore_ControlSize(button1, recBut2);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(groupBox1, recGb1);
                restore_ControlSize(radioButton1, recRb1);
                restore_ControlSize(radioButton2, recRb2);
                restore_ControlSize(radioButton3, recRb3);
            }
        }

        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            // Restauramos el tamaño de la fuente original
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

        }
        private void resize_Control(Control control, Rectangle rect)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(rect.X * xRatio);
            int newY = (int)(rect.Y * yRatio);

            int newWidth = (int)(rect.Width * xRatio);
            int newHeight = (int)(rect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);

            // Ajustar tamaño de la fuente
            float fontSizeRatio = Math.Min(xRatio, yRatio); // Escala basada en la menor proporción
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);
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
            Principal principal = new Principal(FilePathAST);
            principal.Show();
            this.Close(); // Cerrar ImportAst después de seleccionar
            welcome.Hide();
            Hide();

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

