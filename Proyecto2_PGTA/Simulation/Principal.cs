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

            Zen.Barcode.CodeQrBarcodeDraw QR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox2.Image = QR.Draw("HOLA", 10);
        }

        private void SimulateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv"); 

                // Verifica si el archivo existe
                if (!File.Exists(rutaCSV))
                {
                    MessageBox.Show("The CSV file was not found.");
                    return; // Sale del método si no encuentra el archivo
                }

                List<List<object>> allMessages = new List<List<object>>();


                StreamReader file = new StreamReader(rutaCSV);
                string line;
                file.ReadLine(); //Lee la primera linea para descartarla (encabezado)

                while ((line = file.ReadLine()) != null)
                {
                    // Separa la línea utilizando el separador de tabulación y limpia las comillas
                    string[] row = line.Split('\t').Select(e => e.Trim('\"')).ToArray();

                    double LAT = Convert.ToDouble(row[5]);
                    double LON = Convert.ToDouble(row[6]);

                    List<object> message = new List<object>();
                    message.Add(LAT);
                    message.Add(LON);
                    allMessages.Add(message);
                }

                string selection = comboBox1.SelectedItem.ToString();

                List<List<object>> filtredData = new List<List<object>>();

                // Ejecutar la función según la opción seleccionada
                if (selection == "All data")
                {
                    filtredData = Option1(allMessages);
                }
                else if (selection == "Removing pure blanks")
                {
                    filtredData = Option2(allMessages);
                }
                else if (selection == "Removing fixed transponders")
                {
                    filtredData = Option3(allMessages);
                }
                else if (selection == "Combination of these")
                {
                    filtredData = Option4(allMessages);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading the file: " + ex.Message);
            }

            Mapa mapa = new Mapa();
            // Oculta el Principal
            this.Hide();
            // Abrir el Mapa
            mapa.Show();
        }

        // Funciones correspondientes a cada opción seleccionada
        private List<List<object>> Option1 (List<List<object>> allMessages)
        {
            MessageBox.Show("Executing All data function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "All data"
            // Retorno la lista tal cual, no se filtra
            return allMessages;
        }

        private List<List<object>> Option2(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing pure blanks function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Removing pure blanks"
            // HACER FUNCION DE FILTRADO CORRESPONDIENTE
            return allMessages; //Se cambiara por el return de la nueva lista
        }

        private List<List<object>> Option3(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing fixed transponders function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Removing fixed transponders"
            // HACER FUNCION DE FILTRADO CORRESPONDIENTE
            return allMessages; //Se cambiara por el return de la nueva lista
        }

        private List<List<object>> Option4(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Combination of these function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // For "Combination of these"
            // HACER FUNCION DE FILTRADO CORRESPONDIENTE
            return allMessages; //Se cambiara por el return de la nueva lista
        }

    }
}