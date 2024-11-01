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
    public partial class CombinedFilters : Form
    {
        private Principal principal;
        public CombinedFilters(Principal principal_)
        {
            InitializeComponent();
            this.principal = principal_;

            // Agregar opciones al CheckedListBox
            checkedListBox1.Items.Add("All data");
            checkedListBox1.Items.Add("Removing pure blanks");
            checkedListBox1.Items.Add("Removing fixed transponders");
            checkedListBox1.Items.Add("Geographic filter");
            checkedListBox1.Items.Add("Removing flights above 6000 ft");
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            principal.Enabled = false;

        }
    }
}
