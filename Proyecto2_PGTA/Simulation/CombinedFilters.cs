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

namespace Simulation
{
    public partial class CombinedFilters : Form
    {
        private Principal principal;
        private List<List<object>> data;
        private List<List<object>> filteredData;
        private bool isDarkMode;
        public bool cancel { get; set; }

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recPtb1;
        private Rectangle recCb1;
        public CombinedFilters(Principal principal_, List<List<object>> originalData)
        {
            InitializeComponent();
            this.principal = principal_;
            this.data = originalData;

            checkedListBox1.Items.Add("Removing pure blanks");
            checkedListBox1.Items.Add("Removing fixed transponders");
            checkedListBox1.Items.Add("Geographic filter");
            checkedListBox1.Items.Add("Removing flights above 6000 ft");
            checkedListBox1.Items.Add("Removing on ground flights");

            this.Resize += CombinedFilters_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(acceptBtn.Location, acceptBtn.Size);
            recBut2 = new Rectangle(cancelBtn.Location, cancelBtn.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recCb1 = new Rectangle(checkedListBox1.Location, checkedListBox1.Size);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CombinedFilters_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(acceptBtn, recBut1);
                resize_Control(cancelBtn, recBut2);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(checkedListBox1, recCb1);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(acceptBtn, recBut1);
                restore_ControlSize(cancelBtn, recBut2);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(checkedListBox1, recCb1);
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
        /// Returns the filtered data list.
        /// </summary>
        /// <returns></returns>
        public List<List<object>> GetFilteredData()
        {
            return filteredData;
        }
        /// <summary>
        /// Applies selected filters to the data if at least two filters are chosen, then disables the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            cancel = false;

            var selectedFilters = checkedListBox1.CheckedItems.Cast<string>().ToList();

            if (selectedFilters.Count >= 2)
            {

                filteredData = new List<List<object>>(data);

                foreach (var filter in selectedFilters)
                {
                    filteredData = ApplyFilter(filter, filteredData);
                }

                this.Close();
                principal.Enabled = false;

            }
            else
            {
                MessageBox.Show("Please select at least 2 filters.");
            }

        }

        /// <summary>
        /// Applies specific filters based on the filter name passed as a parameter.
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<List<object>> ApplyFilter(string filterName, List<List<object>> data)
        {
            switch (filterName)
            {
                case "Removing pure blanks":
                    return principal.Option2(data);

                case "Removing fixed transponders":
                    return principal.Option3(data);

                case "Geographic filter":
                    return principal.Option4(data);

                case "Removing flights above 6000 ft":
                    return principal.Option5(data);

                case "Removing on ground flights":
                    return principal.Option6(data);

                default:
                    return data; 
            }
        }

        /// <summary>
        /// Loads the theme setting and applies dark or light mode based on the stored preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CombinedFilters_Load(object sender, EventArgs e)
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
            filteredData = null;
            this.Close();
        }
    }
}
