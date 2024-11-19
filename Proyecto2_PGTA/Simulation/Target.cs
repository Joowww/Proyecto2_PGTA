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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Simulation
{
    public partial class Target : Form
    {

        private Mapa mapa;
        private bool isDarkMode;
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recTxt1;
        private Rectangle recTxt2;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recPtb1;

        private bool isCancelButtonClicked = false;
        public Target(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
            this.Resize += Target_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(acceptBtn.Location, acceptBtn.Size);
            recBut2 = new Rectangle(cancelBtn.Location, cancelBtn.Size);
            recBut3 = new Rectangle(autofillBtn.Location, autofillBtn.Size);
            recTxt1 = new Rectangle(textBox1.Location, textBox1.Size);
            recTxt2 = new Rectangle(textBox2.Location, textBox2.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label3.Location, label3.Size);
            recLbl3 = new Rectangle(label5.Location, label5.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }
        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Target_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(acceptBtn, recBut1);
                resize_Control(cancelBtn, recBut2);
                resize_Control(autofillBtn, recBut3);
                resize_Control(textBox1, recTxt1);
                resize_Control(textBox2, recTxt2);
                resize_Control(label3, recLbl2);
                resize_Control(label1, recLbl1);
                resize_Control(label5, recLbl3);
                resize_Control(pictureBox7, recPtb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(acceptBtn, recBut1);
                restore_ControlSize(cancelBtn, recBut2);
                restore_ControlSize(autofillBtn, recBut3);
                restore_ControlSize(textBox1, recTxt1);
                restore_ControlSize(textBox2, recTxt2);
                restore_ControlSize(label3, recLbl2);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label5, recLbl3);
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
        /// Validates target identification inputs, clears overlays, and attempts to filter messages. If targets are missing, shows an error. If valid, calculates distances for the selected targets and hides the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void acceptBtn_Click(object sender, EventArgs e)
        {
            mapa.extra = true;

            mapa.markersOverlay.Markers.Clear();

            mapa.routeOverlay.Routes.Clear();

            mapa.mapControl.Refresh();

            try
            {
                string TI1 = textBox1.Text;
                string TI2 = textBox2.Text;

                if (string.IsNullOrEmpty(TI1) || string.IsNullOrEmpty(TI2))
                {
                    MessageBox.Show("Please enter a target identification in both fields.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var (filteredMessages, missingTargets) = mapa.Option8(mapa.AllMessages, TI1, TI2);

                if (missingTargets.Count != 0)
                {
                    if (missingTargets.Count == 1)
                    {
                        if (missingTargets[0] == TI1)
                        {
                            MessageBox.Show($"The target identification '{TI1}' is not found in the Asterix. Please enter another identification.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Clear();
                        }
                        else if (missingTargets[0] == TI2)
                        {
                            MessageBox.Show($"The target identification '{TI2}' is not found in the Asterix. Please enter another identification.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Clear();
                        }

                    }
                    else if (missingTargets.Count == 2)
                    {

                        MessageBox.Show("Neither of the two target identifications entered is found in the Asterix. Please enter two different identifications.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    return;
                }

                mapa.CalculateDistanceForAircrafts(filteredMessages, TI1, TI2);
                mapa.SetTargetAddresses(filteredMessages);

                mapa.Enabled = true;
                this.Hide();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autofillBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "VOE23TA";
            textBox2.Text = "AEE710";
        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Target_Load(object sender, EventArgs e)
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

        private void Target_FormClosing(object sender, FormClosingEventArgs e)
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
