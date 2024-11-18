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
    public partial class Tutorial : Form
    {
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recLbl5;
        private Rectangle recLbl6;
        private Rectangle recLbl7;
        private Rectangle recLbl8;
        private Rectangle recLbl9;
        private Rectangle recLbl10;
        private Rectangle recLbl11;
        private Rectangle recLbl12;
        private Rectangle recLbl13;
        private Rectangle recLbl14;
        private Rectangle recLbl15;
        private Rectangle recPtb1;

        private bool isCancelButtonClicked = false;

        public Tutorial()
        {
            InitializeComponent();
            this.Resize += Tutorial_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(buttonClose.Location, buttonClose.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recLbl5 = new Rectangle(label5.Location, label5.Size);
            recLbl6 = new Rectangle(label6.Location, label6.Size);
            recLbl7 = new Rectangle(label7.Location, label7.Size);
            recLbl8 = new Rectangle(label8.Location, label8.Size);
            recLbl9 = new Rectangle(label9.Location, label9.Size);
            recLbl10 = new Rectangle(label10.Location, label10.Size);
            recLbl11 = new Rectangle(label11.Location, label11.Size);
            recLbl12 = new Rectangle(label12.Location, label12.Size);
            recLbl13 = new Rectangle(label13.Location, label13.Size);
            recLbl14 = new Rectangle(label14.Location, label14.Size);
            recLbl15 = new Rectangle(label15.Location, label15.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tutorial_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(buttonClose, recBut1);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(label3, recLbl3);
                resize_Control(label4, recLbl4);
                resize_Control(label5, recLbl5);
                resize_Control(label6, recLbl6);
                resize_Control(label7, recLbl7);
                resize_Control(label8, recLbl8);
                resize_Control(label9, recLbl9);
                resize_Control(label10, recLbl10);
                resize_Control(label11, recLbl11);
                resize_Control(label12, recLbl12);
                resize_Control(label13, recLbl13);
                resize_Control(label14, recLbl14);
                resize_Control(label15, recLbl15);
                resize_Control(pictureBox7, recPtb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(buttonClose, recBut1);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(label3, recLbl3);
                restore_ControlSize(label4, recLbl4);
                restore_ControlSize(label5, recLbl5);
                restore_ControlSize(label6, recLbl6);
                restore_ControlSize(label7, recLbl7);
                restore_ControlSize(label8, recLbl8);
                restore_ControlSize(label9, recLbl9);
                restore_ControlSize(label10, recLbl10);
                restore_ControlSize(label11, recLbl11);
                restore_ControlSize(label12, recLbl12);
                restore_ControlSize(label13, recLbl13);
                restore_ControlSize(label14, recLbl14);
                restore_ControlSize(label15, recLbl15);
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            isCancelButtonClicked = true;
            this.Hide();
        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tutorial_Load(object sender, EventArgs e)
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

        private void Tutorial_FormClosing(object sender, FormClosingEventArgs e)
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
