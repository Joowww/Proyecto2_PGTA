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
    public partial class VideoTutorial : Form
    {
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recPtb1;
        private Rectangle recPtb2;
        private bool isCancelButtonClicked = false;
        public VideoTutorial()
        {
            InitializeComponent();
            this.Resize += VideoTutorial_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(buttonClose.Location, buttonClose.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recPtb1 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            recPtb2 = new Rectangle(pictureBox7.Location, pictureBox7.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoTutorial_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(buttonClose, recBut1);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(pictureBox2, recPtb1);
                resize_Control(pictureBox7, recPtb2);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(buttonClose, recBut1);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
                restore_ControlSize(pictureBox2, recPtb1);
                restore_ControlSize(pictureBox7, recPtb2);
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

            if (control is PictureBox)
            {
                (control as PictureBox).SizeMode = PictureBoxSizeMode.Normal;
            }

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

            if (control is PictureBox)
            {
                (control as PictureBox).SizeMode = PictureBoxSizeMode.StretchImage;
            }
            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Generates and displays a QR code, then applies the theme (dark or light).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoTutorial_Load(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw QR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox2.Image = QR.Draw("https://youtu.be/3tG5lqbTUQI", 10);

            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            ApplyTheme();

            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }
        }

        /// <summary>
        /// Changes the form’s background based on the selected theme.
        /// </summary>
        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Opens the YouTube link, or shows an error if it fails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label3_Click(object sender, EventArgs e)
        {
            string url = "https://youtu.be/3tG5lqbTUQI";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el enlace: " + ex.Message);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            isCancelButtonClicked = true;
            this.Hide();
        }

        private void VideoTutorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isCancelButtonClicked)
            {
                e.Cancel = true;
                MessageBox.Show("No puedes cerrar el formulario de esta manera.");
            }
            isCancelButtonClicked = false;

        }
    }
}
