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

        public bool cancel { get; set; }
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

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Restores the original position, size, and font of a control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

        }
        /// <summary>
        /// Dynamically resizes and repositions a control based on the current size of the form relative to its original size.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="rect"></param>
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

            float fontSizeRatio = Math.Min(xRatio, yRatio);
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Validates and applies latitude and longitude values from text boxes, checking for errors like empty fields, invalid formats, and out-of-range values. If valid, it updates the coordinates and closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyBtn_Click(object sender, EventArgs e)
        {
            cancel = false;
            try
            {

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
                MessageBox.Show("Please enter valid numeric values for latitude and longitude.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Sets default latitude and longitude values, then populates text boxes with these values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autofillBtn_Click(object sender, EventArgs e)
        {
            MinLatitude = 40.9;
            MaxLatitude = 41.7;
            MinLongitude = 1.5;
            MaxLongitude = 2.6;

            textBox1.Text = MinLatitude.ToString();
            textBox2.Text = MaxLatitude.ToString();
            textBox3.Text = MinLongitude.ToString();
            textBox4.Text = MaxLongitude.ToString();
        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeographicFilter_Load(object sender, EventArgs e)
        {
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            ApplyTheme();

            (isDarkMode ? (Action<Control>)Theme.SetDarkMode : Theme.SetLightMode)(this);
        }
        /// <summary>
        /// Changes the form’s background based on the selected theme.
        /// </summary>
        private void ApplyTheme()
        {
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : Color.White;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }
    }
}
