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
        private List<List<object>> data;
        private List<List<object>> filteredData;
        private bool isDarkMode;
        public CombinedFilters(Principal principal_, List<List<object>> originalData)
        {
            InitializeComponent();
            this.principal = principal_;
            this.data = originalData;

            // Agregar opciones al CheckedListBox
            checkedListBox1.Items.Add("Removing pure blanks");
            checkedListBox1.Items.Add("Removing fixed transponders");
            checkedListBox1.Items.Add("Geographic filter");
            checkedListBox1.Items.Add("Removing flights above 6000 ft");
            checkedListBox1.Items.Add("Removing on ground flights");
        }

        public List<List<object>> GetFilteredData()
        {
            return filteredData;
        }
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            // Obtener los filtros seleccionados
            var selectedFilters = checkedListBox1.CheckedItems.Cast<string>().ToList();

            // Verificar si hay al menos 2 filtros seleccionados
            if (selectedFilters.Count >= 2)
            {

                // Copia de los datos originales para aplicar los filtros
                filteredData = new List<List<object>>(data);

                // Aplicar los filtros en el orden seleccionado
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

        // Método para aplicar el filtro basado en el nombre del filtro seleccionado
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
                    return data; // Devolver los datos sin cambios si el filtro no coincide
            }
        }

        private void CombinedFilters_Load(object sender, EventArgs e)
        {
            // Cargar el estado del tema guardado
            isDarkMode = Properties.Settings1.Default.IsDarkMode;

            // Aplicar el tema según el estado guardado
            ApplyTheme();

            // Si el modo oscuro está activo, aplicarlo
            if (isDarkMode)
            {
                Theme.SetDarkMode(this);
            }
            else
            {
                Theme.SetLightMode(this);
            }
        }

        private void ApplyTheme()
        {
            // Aplica el tema al formulario actual
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

        }
    }
}
