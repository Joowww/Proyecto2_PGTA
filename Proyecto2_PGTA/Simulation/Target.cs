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
        private Dictionary<Control, Rectangle> controlRectangles = new Dictionary<Control, Rectangle>();
        private bool isCancelButtonClicked = false;

        public Target(Mapa mapa_)
        {
            InitializeComponent();
            this.mapa = mapa_;
            this.Resize += Target_Resiz;
            formOriginalSize = this.Size;
            InitializeControlRectangles();
            AdjustPictureBox7Position();
        }

        /// <summary>
        /// Initializes the rectangles for all controls to be resized.
        /// </summary>
        private void InitializeControlRectangles()
        {
            controlRectangles.Add(acceptBtn, new Rectangle(acceptBtn.Location, acceptBtn.Size));
            controlRectangles.Add(cancelBtn, new Rectangle(cancelBtn.Location, cancelBtn.Size));
            controlRectangles.Add(autofillBtn, new Rectangle(autofillBtn.Location, autofillBtn.Size));
            controlRectangles.Add(textBox1, new Rectangle(textBox1.Location, textBox1.Size));
            controlRectangles.Add(textBox2, new Rectangle(textBox2.Location, textBox2.Size));
            controlRectangles.Add(label1, new Rectangle(label1.Location, label1.Size));
            controlRectangles.Add(label3, new Rectangle(label3.Location, label3.Size));
            controlRectangles.Add(label5, new Rectangle(label5.Location, label5.Size));
            controlRectangles.Add(pictureBox7, new Rectangle(pictureBox7.Location, pictureBox7.Size));
        }

        /// <summary>
        /// Adjusts the position of pictureBox7 when the window is resized.
        /// </summary>
        private void AdjustPictureBox7Position()
        {
            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Dynamically adjusts the size and position of controls based on the window state.
        /// </summary>
        private void Target_Resiz(object sender, EventArgs e)
        {
            bool isMaximized = this.WindowState == FormWindowState.Maximized;

            foreach (var control in controlRectangles)
            {
                AdjustControlSize(control.Key, control.Value, isMaximized);
            }
        }

        /// <summary>
        /// Adjusts the size and position of a control based on the form's state.
        /// </summary>
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
        /// Restores the original size and position of a control.
        /// </summary>
        private void RestoreControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            AdjustPictureBox7Position(); 
        }

        /// <summary>
        /// Dynamically resizes the size and position of a control based on the current size of the form.
        /// </summary>
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

                if (missingTargets.Any())
                {
                    HandleMissingTargets(missingTargets, TI1, TI2);
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

        /// <summary>
        /// Handles the logic for displaying error messages when one or both target identifications are missing, clearing the corresponding textboxes as needed.
        /// </summary>
        /// <param name="missingTargets"></param>
        /// <param name="TI1"></param>
        /// <param name="TI2"></param>
        private void HandleMissingTargets(List<string> missingTargets, string TI1, string TI2)
        {
            if (missingTargets.Count == 1)
            {
                string missingTarget = missingTargets[0];
                string targetMessage = $"The target identification '{missingTarget}' is not found in the Asterix. Please enter another identification.";

                if (missingTarget == TI1)
                {
                    MessageBox.Show(targetMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show(targetMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Clear();
                }
            }
            else if (missingTargets.Count == 2)
            {
                MessageBox.Show("Neither of the two target identifications entered is found in the Asterix. Please enter two different identifications.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
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
