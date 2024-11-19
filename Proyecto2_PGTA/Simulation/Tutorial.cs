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
        private Control[] controls;
        private Rectangle[] originalRectangles;

        private bool isCancelButtonClicked = false;

        public Tutorial()
        {
            InitializeComponent();
            this.Resize += Tutorial_Resiz;
            formOriginalSize = this.Size;

            controls = new Control[] {
            buttonClose, label1, label2, label3, label4, label5, label6, label7, label8,
            label9, label10, label11, label12, label13, label14, label15, pictureBox7
            };

            originalRectangles = new Rectangle[controls.Length];
            for (int i = 0; i < controls.Length; i++)
            {
                originalRectangles[i] = new Rectangle(controls[i].Location, controls[i].Size);
            }

            AdjustPictureBoxPosition();
        }
        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tutorial_Resiz(object sender, EventArgs e)
        {
            bool isMaximized = this.WindowState == FormWindowState.Maximized;

            for (int i = 0; i < controls.Length; i++)
            {
                ResizeOrRestoreControl(controls[i], originalRectangles[i], isMaximized);
            }
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

                if (control is System.Windows.Forms.Label label)
                {
                    float fontSizeRatio = Math.Min(xRatio, yRatio);
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * fontSizeRatio, control.Font.Style);
                }

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

            (isDarkMode ? (Action<Control>)Theme.SetDarkMode : Theme.SetLightMode)(this);
        }
        /// <summary>
        /// Changes the form’s background based on the selected theme.
        /// </summary>
        private void ApplyTheme()
        {
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : Color.White;
        }

        private void Tutorial_FormClosing(object sender, FormClosingEventArgs e)
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
