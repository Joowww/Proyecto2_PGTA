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
    public partial class ImportAst : Form
    {
        Loading2 loading;
        private Welcome welcome;
        public string FilePathAST { get; set; }
        private bool isDarkMode;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recLbl1;
        private Rectangle recPtb1;
        private Rectangle recGb1;
        private Rectangle recRb1;
        private Rectangle recRb2;
        private Rectangle recRb3;
        public ImportAst(Welcome welcome_)
        {
            InitializeComponent();
            this.welcome = welcome_;
            this.Load += ImportAst_Load;
            this.Resize += ImportAst_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(browseBtn.Location, browseBtn.Size);
            recBut2 = new Rectangle(button1.Location, button1.Size);
            recBut3 = new Rectangle(button2.Location, button2.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recGb1 = new Rectangle(groupBox1.Location, groupBox1.Size);
            recRb1 = new Rectangle(radioButton1.Location, radioButton1.Size);
            recRb2 = new Rectangle(radioButton2.Location, radioButton2.Size);
            recRb3 = new Rectangle(radioButton3.Location, radioButton3.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportAst_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(browseBtn, recBut1);
                resize_Control(button1, recBut2);
                resize_Control(button2, recBut3);
                resize_Control(label1, recLbl1);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(groupBox1, recGb1);
                resize_Control(radioButton1, recRb1);
                resize_Control(radioButton2, recRb2);
                resize_Control(radioButton3, recRb3);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(browseBtn, recBut1);
                restore_ControlSize(button1, recBut2);
                restore_ControlSize(button2, recBut3);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(groupBox1, recGb1);
                restore_ControlSize(radioButton1, recRb1);
                restore_ControlSize(radioButton2, recRb2);
                restore_ControlSize(radioButton3, recRb3);
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
        /// ImportAst_Load sets radioButton1 as checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportAst_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        /// <summary>
        /// browseBtn_Click sets radioButton3 checked, opens a file dialog to select a file, sets FilePathAST and updates label1 with the selected file name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseBtn_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePathAST = openFileDialog.FileName;
                    label1.Text = Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                label1.Text = "";  
            }
        }

        /// <summary>
        /// Validates the file selection, shows a loading form, waits for 5 seconds, then opens the main form and closes the current one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void acceptBtn_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked && !string.IsNullOrEmpty(FilePathAST))
            {
                if (Path.GetExtension(FilePathAST).ToLower() != ".ast")
                {
                    MessageBox.Show("Please select a file with the .ast extension.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }
            else if (radioButton1.Checked)
            {
                FilePathAST = "230502-est-080001_BCN_60MN_08_09.ast";
            }
            else if (radioButton2.Checked)
            {
                FilePathAST = "230502-est-080001_BCN.ast";
            }
            else if (radioButton3.Checked && !string.IsNullOrEmpty(FilePathAST))
            {
                // Custom file already selected
            }
            else
            {
                MessageBox.Show("Please select a file option.", "File Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Show();
            Task oTask = new Task(SL);
            oTask.Start();
            await oTask;
            Principal principal = new Principal(FilePathAST);
            principal.Show();
            this.Close(); 
            welcome.Hide();
            Hide1();

        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportAst_Load_1(object sender, EventArgs e)
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
        /// Pauses for 5 seconds.
        /// </summary>
        public void SL()
        {
            Thread.Sleep(5000);
        }
        public void Show()
        {
            loading = new Loading2();
            loading.Show();
        }
        public void Hide1()
        {
            if (loading != null)
            {
                loading.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

