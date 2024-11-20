using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Simulation
{
    public partial class Welcome : Form
    {
        bool sidebarExpand;
        bool AbouUsCollapse;
        bool SettingsCollapse;
        bool HelpCollapse;
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        private Rectangle recBut6;
        private Rectangle recBut7;
        private Rectangle recBut8;
        private Rectangle recBut10;
        private Rectangle recBut11;
        private Rectangle recBut12;
        private Rectangle recBut13;
        private Rectangle recLbl1;
        private Rectangle recPtb1;
        private Rectangle recPtb2;
        private Rectangle recPtb3;
        private Rectangle recPtb4;
        private Rectangle recPtb5;
        private Rectangle recPtb6;
        private Rectangle recPtb7;
        private Rectangle recPtb8;
        private Rectangle recPtb9;
        private Rectangle recPtb10;
        private Rectangle recPtb11;
        private Rectangle recPtb12;
        private Rectangle recPtb14;
        private Rectangle recPtb15;
        private Rectangle recPtb16;
        private Rectangle recPtb17;
        private Rectangle recPanel1;
        private Rectangle recPanel2;
        private Rectangle recPanel3;
        private Rectangle recPanel4;
        private Rectangle recPanel5;
        private Rectangle recPanel6;
        private Rectangle recPanel7;
        private Rectangle recPanel8;
        private Rectangle recPanel9;
        private Rectangle recPanel10;
        private Rectangle recPanel11;
        private Rectangle recPanel12;
        private Rectangle recPanel13;
        private Rectangle recPanel16;
        private Rectangle recPanel17;
        private Rectangle recPanel18;
        private Rectangle recPanel19;
        private Rectangle recPanel20;
        private Rectangle recPanel21;
        private Rectangle recPanel22;
        private Rectangle recPanel23;
        private Rectangle recCont1;
        private Rectangle recCont2;
        private Rectangle recCont3;
        private Rectangle recSb1;
        public Welcome()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.Resize += Welcome_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(button1.Location, button1.Size);
            recBut2 = new Rectangle(menuButton.Location, menuButton.Size);
            recBut3 = new Rectangle(button2.Location, button2.Size);
            recBut4 = new Rectangle(buttonAboutUs.Location, buttonAboutUs.Size);
            recBut5 = new Rectangle(buttonGroup.Location, buttonGroup.Size);
            recBut6 = new Rectangle(buttonContactUs.Location, buttonContactUs.Size);
            recBut7 = new Rectangle(buttonSettings.Location, buttonSettings.Size);
            recBut8 = new Rectangle(button3.Location, button3.Size);
            recBut10 = new Rectangle(buttonHelp.Location, buttonHelp.Size);
            recBut11 = new Rectangle(buttonTutorial.Location, buttonTutorial.Size);
            recBut12 = new Rectangle(buttonQRVideoT.Location, buttonQRVideoT.Size);
            recBut13 = new Rectangle(button4.Location, button4.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recPtb1 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            recPtb2 = new Rectangle(pictureBox3.Location, pictureBox3.Size);
            recPtb3 = new Rectangle(pictureBox4.Location, pictureBox4.Size);
            recPtb4 = new Rectangle(pictureBox5.Location, pictureBox5.Size);
            recPtb5 = new Rectangle(pictureBox6.Location, pictureBox6.Size);
            recPtb6 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recPtb7 = new Rectangle(pictureBox8.Location, pictureBox8.Size);
            recPtb8 = new Rectangle(pictureBox10.Location, pictureBox10.Size);
            recPtb9 = new Rectangle(pictureBox9.Location, pictureBox9.Size);
            recPtb10 = new Rectangle(pictureBox15.Location, pictureBox15.Size);
            recPtb11 = new Rectangle(pictureBox18.Location, pictureBox18.Size);
            recPtb12 = new Rectangle(pictureBox19.Location, pictureBox19.Size);
            recPtb14 = new Rectangle(pictureBox11.Location, pictureBox11.Size);
            recPtb15 = new Rectangle(pictureBox13.Location, pictureBox13.Size);
            recPtb16 = new Rectangle(pictureBox16.Location, pictureBox16.Size);
            recPtb17 = new Rectangle(pictureBox12.Location, pictureBox12.Size);
            recPanel1 = new Rectangle(panel1.Location, panel1.Size);
            recPanel2 = new Rectangle(panel15.Location, panel15.Size);
            recPanel3 = new Rectangle(panel2.Location, panel2.Size);
            recPanel4 = new Rectangle(panel17.Location, panel17.Size);
            recPanel5 = new Rectangle(panel3.Location, panel3.Size);
            recPanel6 = new Rectangle(panel18.Location, panel18.Size);
            recPanel7 = new Rectangle(panel7.Location, panel7.Size);
            recPanel8 = new Rectangle(panel19.Location, panel19.Size);
            recPanel9 = new Rectangle(panel8.Location, panel8.Size);
            recPanel10 = new Rectangle(panel16.Location, panel16.Size);
            recPanel11 = new Rectangle(panel4.Location, panel4.Size);
            recPanel12 = new Rectangle(panel21.Location, panel21.Size);
            recPanel13 = new Rectangle(panel10.Location, panel10.Size);
            recPanel16 = new Rectangle(panel5.Location, panel5.Size);
            recPanel17 = new Rectangle(panel14.Location, panel14.Size);
            recPanel18 = new Rectangle(panel23.Location, panel23.Size);
            recPanel19 = new Rectangle(panel12.Location, panel12.Size);
            recPanel20 = new Rectangle(panel24.Location, panel24.Size);
            recPanel21 = new Rectangle(panel13.Location, panel13.Size);
            recPanel22 = new Rectangle(panel9.Location, panel9.Size);
            recPanel23 = new Rectangle(panel6.Location, panel6.Size);
            recCont1 = new Rectangle(AboutUsContainer.Location, AboutUsContainer.Size);
            recCont2 = new Rectangle(SettingsContainer.Location, SettingsContainer.Size);
            recCont3 = new Rectangle(HelpContainer.Location, HelpContainer.Size);
            int minWidthSb = recPanel17.Right - sidebar.Left;
            int maxWidthSb = recPanel16.Right - sidebar.Left;

            sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Welcome_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(button1, recBut1);
                resize_Control(menuButton, recBut2);
                resize_Control(button2, recBut3);
                resize_Control(buttonAboutUs, recBut4);
                resize_Control(buttonGroup, recBut5);
                resize_Control(buttonContactUs, recBut6);
                resize_Control(buttonSettings, recBut7);
                resize_Control(button3, recBut8);
                resize_Control(buttonHelp, recBut10);
                resize_Control(buttonTutorial, recBut11);
                resize_Control(buttonQRVideoT, recBut12);
                resize_Control(button4, recBut13);
                resize_Control(label1, recLbl1);
                resize_Control(pictureBox2, recPtb1);
                resize_Control(pictureBox3, recPtb2);
                resize_Control(pictureBox4, recPtb3);
                resize_Control(pictureBox5, recPtb4);
                resize_Control(pictureBox6, recPtb5);
                resize_Control(pictureBox7, recPtb6);
                resize_Control(pictureBox8, recPtb7);
                resize_Control(pictureBox10, recPtb8);
                resize_Control(pictureBox9, recPtb9);
                resize_Control(pictureBox15, recPtb10);
                resize_Control(pictureBox18, recPtb11);
                resize_Control(pictureBox19, recPtb12);
                resize_Control(pictureBox11, recPtb14);
                resize_Control(pictureBox13, recPtb15);
                resize_Control(pictureBox16, recPtb16);
                resize_Control(pictureBox12, recPtb17);
                resize_Control(panel1, recPanel1);
                resize_Control(panel15, recPanel2);
                resize_Control(panel2, recPanel3);
                resize_Control(panel17, recPanel4);
                resize_Control(panel3, recPanel5);
                resize_Control(panel18, recPanel6);
                resize_Control(panel7, recPanel7);
                resize_Control(panel19, recPanel8);
                resize_Control(panel8, recPanel9);
                resize_Control(panel16, recPanel10);
                resize_Control(panel4, recPanel11);
                resize_Control(panel21, recPanel12);
                resize_Control(panel10, recPanel13);
                resize_Control(panel5, recPanel16);
                resize_Control(panel14, recPanel17);
                resize_Control(panel23, recPanel18);
                resize_Control(panel12, recPanel19);
                resize_Control(panel24, recPanel20);
                resize_Control(panel13, recPanel21);
                resize_Control(panel9, recPanel22);
                resize_Control(panel6, recPanel23);
                resize_Control(AboutUsContainer, recCont1);
                resize_Control(SettingsContainer, recCont2);
                resize_Control(HelpContainer, recCont3);
                resize_Control(sidebar, recSb1);
                AdjustAboutUsContainer1Size();
                AdjustAboutUsContainer2Size();
                AdjustAboutUsContainer3Size();

            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(button1, recBut1);
                restore_ControlSize(menuButton, recBut2);
                restore_ControlSize(button2, recBut3);
                restore_ControlSize(buttonAboutUs, recBut4);
                restore_ControlSize(buttonGroup, recBut5);
                restore_ControlSize(buttonContactUs, recBut6);
                restore_ControlSize(buttonSettings, recBut7);
                restore_ControlSize(button3, recBut8);
                restore_ControlSize(buttonHelp, recBut10);
                restore_ControlSize(buttonTutorial, recBut11);
                restore_ControlSize(buttonQRVideoT, recBut12);
                restore_ControlSize(button4, recBut13);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(pictureBox2, recPtb1);
                restore_ControlSize(pictureBox3, recPtb2);
                restore_ControlSize(pictureBox4, recPtb3);
                restore_ControlSize(pictureBox5, recPtb4);
                restore_ControlSize(pictureBox6, recPtb5);
                restore_ControlSize(pictureBox7, recPtb6);
                restore_ControlSize(pictureBox8, recPtb7);
                restore_ControlSize(pictureBox10, recPtb8);
                restore_ControlSize(pictureBox9, recPtb9);
                restore_ControlSize(pictureBox15, recPtb10);
                restore_ControlSize(pictureBox18, recPtb11);
                restore_ControlSize(pictureBox19, recPtb12);
                restore_ControlSize(pictureBox11, recPtb14);
                restore_ControlSize(pictureBox13, recPtb15);
                restore_ControlSize(pictureBox16, recPtb16);
                restore_ControlSize(pictureBox12, recPtb17);
                restore_ControlSize(panel1, recPanel1);
                restore_ControlSize(panel15, recPanel2);
                restore_ControlSize(panel2, recPanel3);
                restore_ControlSize(panel17, recPanel4);
                restore_ControlSize(panel3, recPanel5);
                restore_ControlSize(panel18, recPanel6);
                restore_ControlSize(panel7, recPanel7);
                restore_ControlSize(panel19, recPanel8);
                restore_ControlSize(panel8, recPanel9);
                restore_ControlSize(panel16, recPanel10);
                restore_ControlSize(panel4, recPanel11);
                restore_ControlSize(panel21, recPanel12);
                restore_ControlSize(panel10, recPanel13);
                restore_ControlSize(panel5, recPanel16);
                restore_ControlSize(panel14, recPanel17);
                restore_ControlSize(panel23, recPanel18);
                restore_ControlSize(panel12, recPanel19);
                restore_ControlSize(panel24, recPanel20);
                restore_ControlSize(panel13, recPanel21);
                restore_ControlSize(panel9, recPanel22);
                restore_ControlSize(panel6, recPanel23);
                restore_ControlSize(AboutUsContainer, recCont1);
                restore_ControlSize(SettingsContainer, recCont2);
                restore_ControlSize(HelpContainer, recCont3);
                restore_ControlSize(sidebar, recSb1);
                AdjustAboutUsContainer1Size();
                AdjustAboutUsContainer2Size();
                AdjustAboutUsContainer3Size();
            }
        }

        /// <summary>
        /// Adjusts the sidebar size based on the control's position and updates the position of pictureBox7.
        /// </summary>
        /// <param name="control"></param>
        private void AdjustSidebarSize(Control control)
        {
            int rightPosition = control.Left + control.Width;

            if (control == panel14)
            {
                int minWidthSb = rightPosition - sidebar.Left;
                sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            }

            if (control == panel5)
            {
                int maxWidthSb = rightPosition - sidebar.Left;
                sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);
            }

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

            sidebarExpand = true;
        }

        /// <summary>
        ///  Restores the original position, size, and font of a control, and adjusts the minimum and maximum limits of the sidebar.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;
            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            AdjustSidebarSize(control);
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

            AdjustSidebarSize(control);
        }

        private void AdjustContainerSize(Control container, Panel topPanel, Panel bottomPanel, Panel widthPanel)
        {
            int minHeight = topPanel.Bottom - topPanel.Top;
            int maxHeight = bottomPanel.Bottom - topPanel.Top;

            int minWidth = panel17.Right - sidebar.Left;
            int maxWidth = widthPanel.Right - sidebar.Left;

            container.MinimumSize = new Size(minWidth, minHeight);
            container.MaximumSize = new Size(maxWidth, maxHeight);

            sidebarExpand = true;
        }

        private void AdjustAboutUsContainer1Size()
        {
            AdjustContainerSize(AboutUsContainer, panel3, panel8, panel3);
        }

        private void AdjustAboutUsContainer2Size()
        {
            AdjustContainerSize(SettingsContainer, panel4, panel10, panel3);
        }

        private void AdjustAboutUsContainer3Size()
        {
            AdjustContainerSize(HelpContainer, panel5, panel13, panel3);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ImportAst importAst = new ImportAst(this);
            importAst.ShowDialog();

        }

        /// <summary>
        /// Handles the animation of the sidebar’s expansion and contraction, ensuring that the limits are not exceeded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebar.Width = sidebar.MinimumSize.Width;
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebar.Width = sidebar.MaximumSize.Width;
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Expands or contracts the "About Us" container with animation, based on defined limits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUsTimer_Tick(object sender, EventArgs e)
        {
            if (AbouUsCollapse)
            {
                AboutUsContainer.Height += 10;
                if (AboutUsContainer.Height == AboutUsContainer.MaximumSize.Height)
                {
                    AbouUsCollapse = false;
                    AboutUsTimer.Stop();
                }
            }
            else
            {
                AboutUsContainer.Height -= 10;
                if (AboutUsContainer.Height == AboutUsContainer.MinimumSize.Height)
                {
                    AbouUsCollapse = true;
                    AboutUsTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Expands or contracts the "Settings" container with animation, based on defined limits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsTimer_Tick(object sender, EventArgs e)
        {
            if (SettingsCollapse)
            {
                SettingsContainer.Height += 10;
                if (SettingsContainer.Height == SettingsContainer.MaximumSize.Height)
                {
                    SettingsCollapse = false;
                    SettingsTimer.Stop();
                }
            }
            else
            {
                SettingsContainer.Height -= 10;
                if (SettingsContainer.Height == SettingsContainer.MinimumSize.Height)
                {
                    SettingsCollapse = true;
                    SettingsTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Expands or contracts the "Help" container with animation, based on defined limits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpTimer_Tick(object sender, EventArgs e)
        {
            if (HelpCollapse)
            {
                HelpContainer.Height += 10;
                if (HelpContainer.Height == HelpContainer.MaximumSize.Height)
                {
                    HelpCollapse = false;
                    HelpTimer.Stop();
                }
            }
            else
            {
                HelpContainer.Height -= 10;
                if (HelpContainer.Height == HelpContainer.MinimumSize.Height)
                {
                    HelpCollapse = true;
                    HelpTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Loads and applies the theme state (dark or light) when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Welcome_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Starts the animation for the "Settings" container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click_1(object sender, EventArgs e)
        {
            SettingsTimer.Start();
        }

        /// <summary>
        /// Starts the animation for the "About Us" container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAboutUs_Click_1(object sender, EventArgs e)
        {
            AboutUsTimer.Start();
        }

        /// <summary>
        /// Displays a message indicating that the user is already on the main screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("You are now on the Home screen.", "Instrucciones de uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Starts the animation for the "Help" container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click_1(object sender, EventArgs e)
        {
            HelpTimer.Start();
        }

        /// <summary>
        /// Toggles between light and dark mode, saving the theme state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();

            Properties.Settings1.Default.IsDarkMode = isDarkMode;
            Properties.Settings1.Default.Save();
        }

        private void buttonGroup_Click_1(object sender, EventArgs e)
        {
            Group9 Group = new Group9();
            Group.Show();
        }

        private void buttonContactUs_Click_1(object sender, EventArgs e)
        {
            Contact Contact = new Contact();
            Contact.Show();
        }

        private void buttonTutorial_Click_1(object sender, EventArgs e)
        {
            Tutorial Tut = new Tutorial();
            Tut.Show();
        }

        private void buttonQRVideoT_Click_1(object sender, EventArgs e)
        {
            VideoTutorial VideoTut = new VideoTutorial();
            VideoTut.Show();
        }

        private void menuButton_Click_1(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Privacy PPrivacy = new Privacy();
            PPrivacy.Show();
        }

        /// <summary>
        /// Close the entire app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to close the application?",
            "Confirm Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
