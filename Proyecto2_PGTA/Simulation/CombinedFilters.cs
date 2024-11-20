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
        private Dictionary<string, Rectangle> controlRectangles = new Dictionary<string, Rectangle>();
        private bool isCancelButtonClicked = false;

        public CombinedFilters(Principal principal_, List<List<object>> originalData)
        {
            InitializeComponent();
            this.principal = principal_;
            this.data = originalData;

            string[] filterOptions = {
            "Removing pure blanks",
            "Removing fixed transponders",
            "Geographic filter",
            "Removing flights above 6000 ft",
            "Removing on ground flights"
            };
            checkedListBox1.Items.AddRange(filterOptions);
            this.Resize += CombinedFilters_Resiz;
            formOriginalSize = this.Size;
            InitializeControlRectangles();
            AdjustPictureBoxPosition();
        }

        private void InitializeControlRectangles()
        {
            controlRectangles.Add("acceptBtn", new Rectangle(acceptBtn.Location, acceptBtn.Size));
            controlRectangles.Add("cancelBtn", new Rectangle(cancelBtn.Location, cancelBtn.Size));
            controlRectangles.Add("pictureBox7", new Rectangle(pictureBox7.Location, pictureBox7.Size));
            controlRectangles.Add("checkedListBox1", new Rectangle(checkedListBox1.Location, checkedListBox1.Size));
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
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CombinedFilters_Resiz(object sender, EventArgs e)
        {
            bool isMaximized = this.WindowState == FormWindowState.Maximized;

            foreach (var control in controlRectangles)
            {
                if (isMaximized)
                {
                    resize_Control(GetControlByName(control.Key), control.Value);
                }
                else
                {
                    restore_ControlSize(GetControlByName(control.Key), control.Value);
                }
            }
        }

        private Control GetControlByName(string controlName)
        {
            switch (controlName)
            {
                case "acceptBtn":
                    return acceptBtn;
                case "cancelBtn":
                    return cancelBtn;
                case "pictureBox7":
                    return pictureBox7;
                case "checkedListBox1":
                    return checkedListBox1;
                default:
                    return null;
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

            AdjustPictureBoxPosition(); 
        }

        /// <summary>
        /// Dynamically resizes and repositions a control based on the current size of the form relative to its original size.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void resize_Control(Control control, Rectangle originalRect)
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

            AdjustPictureBoxPosition(); 
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
            isCancelButtonClicked = true;

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
                isCancelButtonClicked = true;

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
            filteredData = null;
            this.Close();
        }

        private void CombinedFilters_FormClosing(object sender, FormClosingEventArgs e)
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
