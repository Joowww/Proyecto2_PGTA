using AstDecoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simulation
{

    public partial class Principal : Form
    {
        bool sidebarExpand;
        bool SettingsCollapse;
        bool HelpCollapse;
        private bool isDarkMode;

        public Principal()
        {
            InitializeComponent();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Agregar elementos al ComboBox
            comboBox1.Items.Add("All data");
            comboBox1.Items.Add("Removing pure blanks");
            comboBox1.Items.Add("Removing fixed transponders");
            comboBox1.Items.Add("Combination of these");
            comboBox1.SelectedIndex = 0; // Seleccionar la primera opción por defecto

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

        private void SimulateBtn_Click(object sender, EventArgs e)
        {
            List<List<object>> filtredMessages = new List<List<object>>();
            List<List<object>> allMessages = new List<List<object>>();

            try
            {
                string rutaCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv");

                // Verifica si el archivo existe
                if (!File.Exists(rutaCSV))
                {
                    MessageBox.Show("The CSV file was not found.");
                    return; // Sale del método si no encuentra el archivo
                }

                StreamReader file = new StreamReader(rutaCSV);
                string line;
                file.ReadLine(); //Lee la primera linea para descartarla (encabezado)

                while ((line = file.ReadLine()) != null)
                {
                    // Separa la línea utilizando el separador de tabulación y limpia las comillas
                    string[] row = line.Split('\t').Select(e => e.Trim('\"')).ToArray();

                    int UTC_time_s = Convert.ToInt32(row[4]);
                    double LAT = Convert.ToDouble(row[5]);
                    double LON = Convert.ToDouble(row[6]);
                    double H = Convert.ToDouble(row[7]);
                    string TYP = Convert.ToString(row[8]);
                    string MODE_3A = Convert.ToString(row[23]);
                    string TA = Convert.ToString(row[35]);

                    // Validar que TA no sea null o una cadena vacía antes de agregar a allMessages
                    if (TA != "N/A")
                    {

                        List<object> message = new List<object>();
                        message.Add(UTC_time_s);
                        message.Add(LAT);
                        message.Add(LON);
                        message.Add(H);
                        message.Add(TYP);
                        message.Add(MODE_3A);
                        message.Add(TA);
                        allMessages.Add(message);
                    }

                }

                string selection = comboBox1.SelectedItem.ToString();

                // Ejecutar la función según la opción seleccionada
                if (selection == "All data")
                {
                    filtredMessages = Option1(allMessages);
                }
                else if (selection == "Removing pure blanks")
                {
                    filtredMessages = Option2(allMessages);
                }
                else if (selection == "Removing fixed transponders")
                {
                    filtredMessages = Option3(allMessages);
                }
                else if (selection == "Combination of these")
                {
                    filtredMessages = Option4(allMessages);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading the file: " + ex.Message);
            }

            Mapa mapa = new Mapa(filtredMessages, allMessages, this);
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            mapa.Show();
        }

        // Funciones correspondientes a cada opción seleccionada
        public List<List<object>> Option1(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing All data function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "All data"
            // Retorno la lista tal cual, no se filtra
            List<List<object>> filtredMessages = allMessages;
            return filtredMessages;
        }

        public List<List<object>> Option2(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing pure blanks function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Removing pure blanks"

            // Lista filtrada que contendrá solo los mensajes que queremos mantener
            List<List<object>> filtredMessages = new List<List<object>>();

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {
                object TYP = message[4]; // Accedemos a TYP (índice 4)

                // Si TYP es "Mode S Roll-Call" o "Mode S Roll-Call + PSR", lo mantenemos
                if (TYP.ToString() == "Mode S Roll-Call" || TYP.ToString() == "Mode S Roll-Call + PSR")
                {
                    filtredMessages.Add(message); // Lo añadimos a la lista filtrada
                }
            }

            return filtredMessages; // Devolvemos la lista filtrada
        }

        public List<List<object>> Option3(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing fixed transponders function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Removing fixed transponders"

            // Lista filtrada que contendrá solo los mensajes que queremos mantener
            List<List<object>> filtredMessages = new List<List<object>>();

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {
                object MODE_3A = message[5];

                if (MODE_3A.ToString() != "7777")
                {
                    filtredMessages.Add(message); // Lo añadimos a la lista filtrada
                }
            }
            return filtredMessages;
        }

        public List<List<object>> Option4(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Combination of these function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Combination of these"
            // HACER FUNCION DE FILTRADO CORRESPONDIENTE
            // Lista filtrada que contendrá solo los mensajes que queremos mantener
            List<List<object>> filtredMessages = new List<List<object>>();

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {
                object MODE_3A = message[5];

                if (MODE_3A.ToString() == "7777")
                {
                    filtredMessages.Add(message); // Lo añadimos a la lista filtrada
                }
            }
            return filtredMessages;
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Welcome Welc = new Welcome();
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            Welc.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpTimer.Start();
        }

        private void buttonTutorial_Click(object sender, EventArgs e)
        {
            Tutorial2 Tut = new Tutorial2();
            // Abrir el Mapa
            Tut.Show();
        }

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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cambia el estado del modo oscuro
            isDarkMode = !isDarkMode;
            ApplyTheme(); // Aplica el nuevo tema

            // Guarda el estado del tema
            Properties.Settings1.Default.IsDarkMode = isDarkMode;
            Properties.Settings1.Default.Save();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            //SET the Minimum and maximum size of sidebar Panel
            if (sidebarExpand)
            {
                // If sidebar is expand, minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            // Set timer interval to lowest to make it smoother
            SidebarTimer.Start();
        }
    }
}