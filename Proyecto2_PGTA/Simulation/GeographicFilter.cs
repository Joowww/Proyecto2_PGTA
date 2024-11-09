using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class GeographicFilter : Form
    {
        private Principal principal;
        public double MinLatitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLongitude { get; set; }
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recTxtb1;
        private Rectangle recTxtb2;
        private Rectangle recTxtb3;
        private Rectangle recTxtb4;
        private Rectangle recPtb1;

        public GeographicFilter(Principal principal_)
        {
            InitializeComponent();
            this.principal = principal_;
            this.Resize += GeographicFilter_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(autofillBtn.Location, autofillBtn.Size);
            recBut2 = new Rectangle(applyBtn.Location, applyBtn.Size);
            recBut3 = new Rectangle(cancelBtn.Location, cancelBtn.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recTxtb1 = new Rectangle(textBox1.Location, textBox1.Size);
            recTxtb2 = new Rectangle(textBox2.Location, textBox2.Size);
            recTxtb3 = new Rectangle(textBox3.Location, textBox3.Size);
            recTxtb4 = new Rectangle(textBox4.Location, textBox4.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
        }

        private void GeographicFilter_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(autofillBtn, recBut1);
                resize_Control(applyBtn, recBut2);
                resize_Control(cancelBtn, recBut3);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(label4, recLbl4);
                resize_Control(textBox1, recTxtb1);
                resize_Control(textBox2, recTxtb2);
                resize_Control(textBox3, recTxtb3);
                resize_Control(textBox4, recTxtb4);
                resize_Control(pictureBox7, recPtb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(autofillBtn, recBut1);
                restore_ControlSize(applyBtn, recBut2);
                restore_ControlSize(cancelBtn, recBut3);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
                restore_ControlSize(label4, recLbl4);
                restore_ControlSize(textBox1, recTxtb1);
                restore_ControlSize(textBox2, recTxtb2);
                restore_ControlSize(textBox3, recTxtb3);
                restore_ControlSize(textBox4, recTxtb4);
                restore_ControlSize(pictureBox7, recPtb1);
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

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("All fields must be filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MinLatitude = double.Parse(textBox1.Text);
                MaxLatitude = double.Parse(textBox2.Text);
                MinLongitude = double.Parse(textBox3.Text);
                MaxLongitude = double.Parse(textBox4.Text);

                // Validate that minimum values are less than maximum values
                if (MinLatitude > MaxLatitude)
                {
                    throw new ArgumentException("Minimum latitude cannot be greater than maximum latitude.");
                }

                if (MinLongitude > MaxLongitude)
                {
                    throw new ArgumentException("Minimum longitude cannot be greater than maximum longitude.");
                }

                if (MinLatitude < -90 || MinLatitude > 90 || MaxLatitude < -90 || MaxLatitude > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be between -90 and 90 degrees.");
                }

                if (MinLongitude < -180 || MinLongitude > 180 || MaxLongitude < -180 || MaxLongitude > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180 and 180 degrees.");
                }

                this.Close();
                principal.Enabled = false;

            }
            catch (FormatException)
            {
                // Handles the case when input is not a valid number
                MessageBox.Show("Please enter valid numeric values for latitude and longitude.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handles any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            // Asignar valores predeterminados
            MinLatitude = 40.9;
            MaxLatitude = 41.7;
            MinLongitude = 1.5;
            MaxLongitude = 2.6;

            // Mostrar los valores en los textboxes
            textBox1.Text = MinLatitude.ToString();
            textBox2.Text = MaxLatitude.ToString();
            textBox3.Text = MinLongitude.ToString();
            textBox4.Text = MaxLongitude.ToString();
        }

        private void GeographicFilter_Load(object sender, EventArgs e)
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
