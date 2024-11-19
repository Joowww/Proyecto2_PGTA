using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class ExtraFunctionality : Form
    {
        private Mapa mapa;
        private bool isDarkMode;
        private Size formOriginalSize;
        private Dictionary<Control, Rectangle> controlRectangles = new Dictionary<Control, Rectangle>();
        private bool isCancelButtonClicked = false;
        public ExtraFunctionality(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
            this.Resize += ExtraFunctionality_Resiz;
            formOriginalSize = this.Size;
            InitializeControlRectangles();
            AdjustPictureBox7Position();
        }
        private void InitializeControlRectangles()
        {
            controlRectangles.Add(targetBtn, new Rectangle(targetBtn.Location, targetBtn.Size));
            controlRectangles.Add(cancelBtn, new Rectangle(cancelBtn.Location, cancelBtn.Size));
            controlRectangles.Add(label1, new Rectangle(label1.Location, label1.Size));
            controlRectangles.Add(label2, new Rectangle(label2.Location, label2.Size));
            controlRectangles.Add(label3, new Rectangle(label3.Location, label3.Size));
            controlRectangles.Add(pictureBox7, new Rectangle(pictureBox7.Location, pictureBox7.Size));
        }
        private void AdjustPictureBox7Position()
        {
            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        private void ExtraFunctionality_Resiz(object sender, EventArgs e)
        {
            bool isMaximized = this.WindowState == FormWindowState.Maximized;

            foreach (var control in controlRectangles)
            {
                AdjustControlSize(control.Key, control.Value, isMaximized);
            }
        }
        private void AdjustControlSize(Control control, Rectangle originalRect, bool isMaximized)
        {
            if (isMaximized)
            {
                ResizeControl(control, originalRect);
            }
            else
            {
                RestoreControlSize(control, originalRect);
            }
        }

        /// <summary>
        /// Restores the original position, size, and font of a control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void RestoreControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            AdjustPictureBox7Position(); // Re-adjust pictureBox7 after restoring sizes
        }
        /// <summary>
        /// Dynamically resizes and repositions a control based on the current size of the form relative to its original size.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void ResizeControl(Control control, Rectangle originalRect)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(originalRect.X * xRatio);
            int newY = (int)(originalRect.Y * yRatio);
            int newWidth = (int)(originalRect.Width * xRatio);
            int newHeight = (int)(originalRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);

            float fontSizeRatio = Math.Min(xRatio, yRatio);
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);

            AdjustPictureBox7Position(); 
        }
        public void targetBtn_Click(object sender, EventArgs e)
        {

            Target target = new Target(mapa);
            mapa.Enabled = false;
            target.Show();
            this.Hide();
        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtraFunctionality_Load(object sender, EventArgs e)
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
            isCancelButtonClicked = true;
            mapa.Enabled = true;
            this.Close();
        }

        private void ExtraFunctionality_FormClosing(object sender, FormClosingEventArgs e)
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
