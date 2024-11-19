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
        private Rectangle recBut1, recLbl1, recLbl2, recLbl3, recPtb1, recPtb2;
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

            AdjustPictureBoxPosition();
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
                ResizeOrRestoreControl(buttonClose, recBut1, true);
                ResizeOrRestoreControl(label1, recLbl1, true);
                ResizeOrRestoreControl(label2, recLbl2, true);
                ResizeOrRestoreControl(label3, recLbl3, true);
                ResizeOrRestoreControl(pictureBox2, recPtb1, true);
                ResizeOrRestoreControl(pictureBox7, recPtb2, true);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                ResizeOrRestoreControl(buttonClose, recBut1, false);
                ResizeOrRestoreControl(label1, recLbl1, false);
                ResizeOrRestoreControl(label2, recLbl2, false);
                ResizeOrRestoreControl(label3, recLbl3, false);
                ResizeOrRestoreControl(pictureBox2, recPtb1, false);
                ResizeOrRestoreControl(pictureBox7, recPtb2, false);
            }
            AdjustPictureBoxPosition();
        }

        /// <summary>
        /// Dynamically resizes, repositions, or restores the original position, size, and font of a control based on the current size of the form relative to its original size.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        /// <param name="isResize"></param>
        private void ResizeOrRestoreControl(Control control, Rectangle originalRect, bool isResize)
        {
            float xRatio = (float)this.Width / formOriginalSize.Width;
            float yRatio = (float)this.Height / formOriginalSize.Height;

            if (isResize)
            {
                control.Location = new Point((int)(originalRect.X * xRatio), (int)(originalRect.Y * yRatio));
                control.Size = new Size((int)(originalRect.Width * xRatio), (int)(originalRect.Height * yRatio));

                float fontSizeRatio = Math.Min(xRatio, yRatio);
                control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

                if (control is PictureBox pictureBox)
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                control.Location = originalRect.Location;
                control.Size = originalRect.Size;
                control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

                if (control is PictureBox pictureBox)
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                }
            }
        }

        /// <summary>
        /// Adjusts the position of a PictureBox to stay in the bottom-right corner of the form.
        /// </summary>
        private void AdjustPictureBoxPosition()
        {
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

            pictureBox2.Image = Zen.Barcode.BarcodeDrawFactory.CodeQr
                        .Draw("https://youtu.be/3tG5lqbTUQI", 10);

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
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("The link could not be opened.: " + ex.Message);
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
                MessageBox.Show("You cannot close the form this way.");
            }
            isCancelButtonClicked = false;

        }
    }
}
