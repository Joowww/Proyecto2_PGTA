using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simulation
{
    public partial class Privacy : Form
    {
        private bool isDarkMode;
        private Size formOriginalSize;
        private Dictionary<Control, Rectangle> controlRectangles = new Dictionary<Control, Rectangle>();
        private bool isCancelButtonClicked = false;
        public Privacy()
        {
            InitializeComponent();
            this.Resize += Privacy_Resiz;
            formOriginalSize = this.Size;
            controlRectangles.Add(button1, new Rectangle(button1.Location, button1.Size));
            controlRectangles.Add(label1, new Rectangle(label1.Location, label1.Size));
            controlRectangles.Add(label2, new Rectangle(label2.Location, label2.Size));
            controlRectangles.Add(label3, new Rectangle(label3.Location, label3.Size));
            controlRectangles.Add(label4, new Rectangle(label4.Location, label4.Size));
            controlRectangles.Add(label5, new Rectangle(label5.Location, label5.Size));
            controlRectangles.Add(pictureBox1, new Rectangle(pictureBox1.Location, pictureBox1.Size));
            controlRectangles.Add(pictureBox7, new Rectangle(pictureBox7.Location, pictureBox7.Size));

            AdjustPictureBoxPosition();
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Privacy_Resiz(object sender, EventArgs e)
        {
            bool isResize = this.WindowState == FormWindowState.Maximized;

            foreach (var control in controlRectangles)
            {
                ResizeOrRestoreControl(control.Key, control.Value, isResize);
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
        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Privacy_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            isCancelButtonClicked = true;
            this.Hide();
        }

        private void Privacy_FormClosing(object sender, FormClosingEventArgs e)
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
