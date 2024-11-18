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
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recPtb1;

        private bool isCancelButtonClicked = false;

        public ExtraFunctionality(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
            this.Resize += ExtraFunctionality_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(targetBtn.Location, targetBtn.Size);
            recBut2 = new Rectangle(cancelBtn.Location, cancelBtn.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtraFunctionality_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(targetBtn, recBut1);
                resize_Control(cancelBtn, recBut2);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(pictureBox7, recPtb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(targetBtn, recBut1);
                restore_ControlSize(cancelBtn, recBut2);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
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
                MessageBox.Show("No puedes cerrar el formulario de esta manera.");
            }
            isCancelButtonClicked = false;
        }
    }
}
