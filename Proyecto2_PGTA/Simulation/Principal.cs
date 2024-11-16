using AstDecoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Simulation
{

    public partial class Principal : Form
    {
        bool sidebarExpand;
        bool SettingsCollapse;
        bool HelpCollapse;
        private bool isDarkMode;
        private string filePathAST;
        public int SelectedIndexOption { get; set; } = 0;

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        private Rectangle recBut7;
        private Rectangle recBut8;
        private Rectangle recCb1;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recPtb1;
        private Rectangle recPtb2;
        private Rectangle recPtb3;
        private Rectangle recPtb4;
        private Rectangle recPtb5;
        private Rectangle recPtb7;
        private Rectangle recPanel1;
        private Rectangle recPanel2;
        private Rectangle recPanel3;
        private Rectangle recPanel4;
        private Rectangle recPanel5;
        private Rectangle recPanel6;
        private Rectangle recPanel7;
        private Rectangle recPanel10;
        private Rectangle recPanel11;
        private Rectangle recPanel12;
        private Rectangle recPanel13;
        private Rectangle recCont1;
        private Rectangle recCont2;
        private Rectangle recSb1;
        public Principal(string filePath)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.filePathAST = filePath;

            this.Resize += Principal_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(SimulateBtn.Location, SimulateBtn.Size);
            recBut2 = new Rectangle(buttonHelp.Location, buttonHelp.Size);
            recBut3 = new Rectangle(buttonTutorial.Location, buttonTutorial.Size);
            recBut4 = new Rectangle(buttonSettings.Location, buttonSettings.Size);
            recBut5 = new Rectangle(button3.Location, button3.Size);
            recBut7 = new Rectangle(menuButton.Location, menuButton.Size);
            recBut8 = new Rectangle(HomeBtn.Location, HomeBtn.Size);
            recCb1 = new Rectangle(comboBox1.Location, comboBox1.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recPtb1 = new Rectangle(pictureBox7.Location, pictureBox7.Size);
            recPtb2 = new Rectangle(pictureBox4.Location, pictureBox4.Size);
            recPtb3 = new Rectangle(pictureBox9.Location, pictureBox9.Size);
            recPtb4 = new Rectangle(pictureBox6.Location, pictureBox6.Size);
            recPtb5 = new Rectangle(pictureBox8.Location, pictureBox8.Size);
            recPtb7 = new Rectangle(pictureBox5.Location, pictureBox5.Size);
            recPanel1 = new Rectangle(panel5.Location, panel5.Size);
            recPanel2 = new Rectangle(panel17.Location, panel17.Size);
            recPanel3 = new Rectangle(panel12.Location, panel12.Size);
            recPanel4 = new Rectangle(panel18.Location, panel18.Size);
            recPanel5 = new Rectangle(panel4.Location, panel4.Size);
            recPanel6 = new Rectangle(panel13.Location, panel13.Size);
            recPanel7 = new Rectangle(panel14.Location, panel14.Size);
            recPanel10 = new Rectangle(panel1.Location, panel1.Size);
            recPanel11 = new Rectangle(panel2.Location, panel2.Size);
            recPanel12 = new Rectangle(panel9.Location, panel9.Size);
            recPanel13 = new Rectangle(panel10.Location, panel10.Size);
            recCont1 = new Rectangle(HelpContainer.Location, HelpContainer.Size);
            recCont2 = new Rectangle(SettingsContainer.Location, SettingsContainer.Size);
            int minWidthSb = recPanel2.Right - sidebar.Left;
            int maxWidthSb = recPanel1.Right - sidebar.Left;

            sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

            StartSimulation();
        }

        /// <summary>
        /// Adjusts dynamically the size and position of the form's controls based on whether it is maximized or in its normal size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Principal_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(SimulateBtn, recBut1);
                resize_Control(buttonHelp, recBut2);
                resize_Control(buttonTutorial, recBut3);
                resize_Control(buttonSettings, recBut4);
                resize_Control(button3, recBut5);
                resize_Control(menuButton, recBut7);
                resize_Control(HomeBtn, recBut8);
                resize_Control(comboBox1, recCb1);
                resize_Control(label1, recLbl1);
                resize_Control(label2, recLbl2);
                resize_Control(pictureBox7, recPtb1);
                resize_Control(pictureBox4, recPtb2);
                resize_Control(pictureBox9, recPtb3);
                resize_Control(pictureBox6, recPtb4);
                resize_Control(pictureBox8, recPtb5);
                resize_Control(pictureBox5, recPtb7);
                resize_Control(panel5, recPanel1);
                resize_Control(panel17, recPanel2);
                resize_Control(panel12, recPanel3);
                resize_Control(panel18, recPanel4);
                resize_Control(panel4, recPanel5);
                resize_Control(panel13, recPanel6);
                resize_Control(panel14, recPanel7);
                resize_Control(panel1, recPanel10);
                resize_Control(panel2, recPanel11);
                resize_Control(panel9, recPanel12);
                resize_Control(panel10, recPanel13);
                resize_Control(HelpContainer, recCont1);
                resize_Control(SettingsContainer, recCont2);
                resize_Control(sidebar, recSb1);
                AdjustAboutUsContainer1Size();
                AdjustAboutUsContainer2Size();

            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                restore_ControlSize(SimulateBtn, recBut1);
                restore_ControlSize(buttonHelp, recBut2);
                restore_ControlSize(buttonTutorial, recBut3);
                restore_ControlSize(buttonSettings, recBut4);
                restore_ControlSize(button3, recBut5);
                restore_ControlSize(menuButton, recBut7);
                restore_ControlSize(HomeBtn, recBut8);
                restore_ControlSize(comboBox1, recCb1);
                restore_ControlSize(label1, recLbl1);
                restore_ControlSize(label2, recLbl2);
                restore_ControlSize(pictureBox7, recPtb1);
                restore_ControlSize(pictureBox4, recPtb2);
                restore_ControlSize(pictureBox9, recPtb3);
                restore_ControlSize(pictureBox6, recPtb4);
                restore_ControlSize(pictureBox8, recPtb5);
                restore_ControlSize(pictureBox5, recPtb7);
                restore_ControlSize(panel5, recPanel1);
                restore_ControlSize(panel17, recPanel2);
                restore_ControlSize(panel12, recPanel3);
                restore_ControlSize(panel18, recPanel4);
                restore_ControlSize(panel4, recPanel5);
                restore_ControlSize(panel13, recPanel6);
                restore_ControlSize(panel14, recPanel7);
                restore_ControlSize(panel1, recPanel10);
                restore_ControlSize(panel2, recPanel11);
                restore_ControlSize(panel9, recPanel12);
                restore_ControlSize(panel10, recPanel13);
                restore_ControlSize(HelpContainer, recCont1);
                restore_ControlSize(SettingsContainer, recCont2);
                restore_ControlSize(sidebar, recSb1);
                AdjustAboutUsContainer1Size();
                AdjustAboutUsContainer2Size();
            }
        }

        /// <summary>
        /// Restores the original position, size, and font of a control, and adjusts the minimum and maximum limits of the sidebar.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="originalRect"></param>
        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            control.Font = new Font(control.Font.FontFamily, 10, control.Font.Style);

            int rightPosition = control.Left + control.Width;

            if (control == panel13)
            {
                int minWidthSb = rightPosition - sidebar.Left;
                sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            }

            if (control == panel4)
            {
                int maxWidthSb = rightPosition - sidebar.Left;
                sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);
            }

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

            sidebarExpand = true;

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

            int rightPosition = control.Left + control.Width;

            if (control == panel13)
            {
                int minWidthSb = rightPosition - sidebar.Left;
                sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            }

            if (control == panel4)
            {
                int maxWidthSb = rightPosition - sidebar.Left;
                sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);
            }

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

            sidebarExpand = true;
        }

        /// <summary>
        /// Adjusts the minimum and maximum size limits of the "Help" container based on related panels.
        /// </summary>
        private void AdjustAboutUsContainer1Size()
        {
            int minHeightCont1 = panel5.Bottom - panel5.Top;
            int maxHeightCont1 = panel12.Bottom - panel5.Top;

            int minWidthCont1 = panel17.Right - sidebar.Left;
            int maxWidthCont1 = panel5.Right - sidebar.Left;


            HelpContainer.MinimumSize = new Size(minWidthCont1, minHeightCont1);
            HelpContainer.MaximumSize = new Size(maxWidthCont1, maxHeightCont1);

            sidebarExpand = true;
        }

        /// <summary>
        ///  Adjusts the minimum and maximum size limits of the "Settings" container based on related panels.
        /// </summary>
        private void AdjustAboutUsContainer2Size()
        {
            SettingsContainer.Location = new Point(SettingsContainer.Location.X, panel4.Top);

            int minHeightCont2 = panel4.Bottom - panel4.Top;
            int maxHeightCont2 = panel10.Bottom - panel4.Top;

            int minWidthCont1 = panel17.Right - sidebar.Left;
            int maxWidthCont1 = panel5.Right - sidebar.Left;


            SettingsContainer.MinimumSize = new Size(minWidthCont1, minHeightCont2);
            SettingsContainer.MaximumSize = new Size(maxWidthCont1, maxHeightCont2);

            sidebarExpand = true;

        }
        /// <summary>
        /// El método StartSimulation lee un archivo binario AST, decodifica los mensajes CAT048, los almacena en una tabla y los exporta a un archivo CSV.
        /// </summary>
        private void StartSimulation()
        {
            string outputFilePath = "TextFile1.txt";

            DataTable messageTable = new DataTable();

            messageTable.Columns.Add("Message Object", typeof(CAT048));

            PropertyInfo[] properties = typeof(CAT048).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                messageTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            try
            {
                using (FileStream filestream = new FileStream(filePathAST, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader decoder = new BinaryReader(filestream))
                    {
                        byte[] fileBytes = File.ReadAllBytes(filePathAST);

                        byte CAT = fileBytes[0];

                        byte[] fileBytes2 = decoder.ReadBytes((int)filestream.Length);
                        using (StreamWriter writer = new StreamWriter(outputFilePath, false))

                            for (int i = 0; i < fileBytes2.Length; i++)
                            {
                                string binaryString = Convert.ToString(fileBytes2[i], 2).PadLeft(8, '0');

                                writer.Write(binaryString + " ");
                            }

                        bool endOfFSPEC = false;
                        string FSPEC = "";

                        bool endOfDF = false;
                        string DataItem = "";

                        int DataFieldFSPEC = 0;
                        int contadorDI = 0;
                        int REP = 0;
                        int DataItemRead2 = 0;

                        List<string> currentDataItems = new List<string>();
                        List<int> posiciones = new List<int>();
                        List<int> posiciones2 = new List<int>();

                        CAT048 Variable048 = new CAT048();

                        for (int i = 1; i < fileBytes.Length; i++)
                        {
                            byte currentByte = fileBytes[i];

                            if (i == 1)
                            {
                                byte c2 = fileBytes[i + 1];

                                int combined = (currentByte << 8) | c2;
                                string binaryString = Convert.ToString(combined, 2).PadLeft(16, '0');
                            }

                            if (i >= 3 && endOfFSPEC == false)
                            {
                                string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                FSPEC += binaryString.Substring(0, 7);
                                char FX = binaryString[binaryString.Length - 1];

                                if (FX == '0')
                                {
                                    endOfFSPEC = true;

                                    for (int i2 = 0; i2 < FSPEC.Length; i2++)
                                    {
                                        if (FSPEC[i2] == '1')
                                        {
                                            posiciones.Add(i2 + 1);
                                        }
                                    }
                                    continue;
                                }
                            }

                            if (i >= 3 && endOfFSPEC == true)
                            {
                                string DataItemRead = Convert.ToString(posiciones[contadorDI]);

                                if (DataItemRead == "1" || DataItemRead == "5" || DataItemRead == "6" || DataItemRead == "11" || DataItemRead == "17" || DataItemRead == "19" || DataItemRead == "21" || DataItemRead == "24" || DataItemRead == "26")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == 16)
                                    {
                                        endOfDF = true;
                                    }
                                }
                                if (DataItemRead == "3" || DataItemRead == "14" || DataItemRead == "16" || DataItemRead == "20")
                                {
                                    string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    char FX = binaryString[binaryString.Length - 1];
                                    if (FX == '0')
                                        endOfDF = true; 
                                    DataItem += binaryString;
                                }

                                if (DataItemRead == "7" || DataItemRead == "27" || DataItemRead == "28")
                                {
                                    string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    char FX = binaryString[binaryString.Length - 1];
                                    DataItem += binaryString;
                                    if (DataItem.Length == 8)
                                    {
                                        for (int i2 = 0; i2 < DataItem.Length; i2++)
                                        {
                                            if (DataItem[i2] == '1')
                                            {
                                                posiciones2.Add(i2);
                                            }
                                        }
                                    }
                                    if (DataItem.Length == (8 + 8 * posiciones2.Count))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "2" || DataItemRead == "8")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == (3 * 8))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "4" || DataItemRead == "12" || DataItemRead == "13" || DataItemRead == "15" || DataItemRead == "18")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == (4 * 8))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "9")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == (6 * 8))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "22")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == (7 * 8))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "10")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    if (DataItem.Length == 8)
                                    {
                                        REP = currentByte;
                                    }
                                    if (DataItem.Length == (8 + 8 * 8 * REP))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                if (DataItemRead == "23")
                                {
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    DataItem += octet;
                                    endOfDF = true;

                                }

                                if (endOfDF == true)
                                {
                                    DataItemRead2 = Convert.ToInt32(DataItemRead);
                                    Function function = new Function();
                                    function.assignDF(DataItem, DataItemRead2, Variable048);
                                    endOfDF = false;
                                    DataItem = "";
                                    contadorDI += 1;

                                    if (contadorDI == (posiciones.Count))
                                    {
                                        Function h = new Function();
                                        h.H(Variable048);

                                        DataRow newRow = messageTable.NewRow();

                                        foreach (PropertyInfo property in properties)
                                        {
                                            var value_property = property.GetValue(Variable048);

                                            if (value_property == null || string.IsNullOrEmpty(value_property.ToString()))
                                            {
                                                newRow[property.Name] = "N/A";
                                            }
                                            else
                                            {
                                                if (property.Name == "MODE_3A")
                                                {
                                                    newRow[property.Name] = value_property.ToString().PadLeft(4, '0');
                                                }
                                                if (property.Name == "TA")
                                                    newRow[property.Name] = value_property.ToString();

                                                else if (double.TryParse(value_property.ToString(), out double numericValue))
                                                {
                                                    newRow[property.Name] = Math.Round(numericValue, 10);
                                                }
                                                else
                                                {
                                                    newRow[property.Name] = value_property.ToString();
                                                }
                                            }
                                        }
                                        messageTable.Rows.Add(newRow);
                                        endOfFSPEC = false;
                                        FSPEC = "";
                                        DataItem = "";
                                        contadorDI = 0;
                                        endOfDF = false;
                                        REP = 0;
                                        i = i + 3;
                                        posiciones.Clear();
                                        posiciones2.Clear();
                                        Variable048 = new CAT048();


                                    }

                                }

                            }
                        }
                    }
                }
                Console.WriteLine("Tabla de mensajes:");
                foreach (DataRow row in messageTable.Rows)
                {
                    Console.WriteLine(row);

                }

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv"); // Save as output.csv in the bin folder

                ExportDataTableToCSV(messageTable, filePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at reading the AST file: " + ex.Message);
            }

            static void ExportDataTableToCSV(DataTable table, string filePath)
            {
                using (StreamWriter SW = new StreamWriter(filePath))
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        SW.Write(table.Columns[i].ColumnName);  
                        if (i < table.Columns.Count - 1)
                            SW.Write("\t");  
                    }
                    SW.WriteLine();  

                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            string cellValue = row[i].ToString().Replace("\"", "\"\"");  
                            SW.Write($"\"{cellValue}\"");  
                            if (i < table.Columns.Count - 1)
                                SW.Write("\t");  
                        }
                        SW.WriteLine();  
                    }
                }
            }

        }


        /// <summary>
        /// Initializes the combo box with filtering options and sets the theme (dark or light) based on the saved preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("All data");
            comboBox1.Items.Add("Removing pure blanks");
            comboBox1.Items.Add("Removing fixed transponders");
            comboBox1.Items.Add("Geographic filter");
            comboBox1.Items.Add("Removing flights above 6000 ft");
            comboBox1.Items.Add("Removing on ground flights");
            comboBox1.Items.Add("Combination of these");
            comboBox1.SelectedIndex = 0; 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

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
        /// Reads data from a CSV file, processes it into a list of messages, applies the selected filter option, and displays the filtered data on a new map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SimulateBtn_Click(object sender, EventArgs e)
        {
            List<List<object>> filtredMessages = new List<List<object>>();
            List<List<object>> allMessages = new List<List<object>>();

            try
            {
                string rutaCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv");

                if (!File.Exists(rutaCSV))
                {
                    MessageBox.Show("The CSV file was not found.");
                    return; 
                }

                StreamReader file = new StreamReader(rutaCSV);
                string line;
                file.ReadLine();

                while ((line = file.ReadLine()) != null)
                {
                    string[] row = line.Split('\t').Select(e => e.Trim('\"')).ToArray();

                    int UTC_time_s = Convert.ToInt32(row[4]);
                    double LAT = Convert.ToDouble(row[5]);
                    double LON = Convert.ToDouble(row[6]);
                    string Altitude_Corrected = Convert.ToString(row[77]);
                    string TYP = Convert.ToString(row[8]);
                    string MODE_3A = Convert.ToString(row[23]);
                    string TA = Convert.ToString(row[35]);
                    string STAT = Convert.ToString(row[70]);
                    string TI = Convert.ToString(row[36]).Trim();
                    string UTC_time = Convert.ToString(row[3]);

                    if (TA != "N/A")
                    {

                        List<object> message = new List<object>();
                        message.Add(UTC_time_s);
                        message.Add(LAT);
                        message.Add(LON);
                        message.Add(Altitude_Corrected);
                        message.Add(TYP);
                        message.Add(MODE_3A);
                        message.Add(TA);
                        message.Add(STAT);
                        message.Add(TI);
                        message.Add(UTC_time);
                        allMessages.Add(message);
                    }

                }

                string selection = comboBox1.SelectedItem.ToString();

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
                else if (selection == "Geographic filter")
                {
                    filtredMessages = Option4(allMessages);

                    if (filtredMessages == null)
                    {
                        return; 
                    }
                }
                else if (selection == "Removing flights above 6000 ft")
                {
                    filtredMessages = Option5(allMessages);
                }
                else if (selection == "Removing on ground flights")
                {
                    filtredMessages = Option6(allMessages);
                }
                else if (selection == "Combination of these")
                {
                    filtredMessages = Option7(allMessages);

                    if (filtredMessages == null)
                    {
                        return; 
                    }
                }
                SelectedIndexOption = comboBox1.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading the file: " + ex.Message);
            }

            if (filtredMessages != null)
            {
                Mapa mapa = new Mapa(filtredMessages, allMessages, SelectedIndexOption, this);
                this.Hide();
                mapa.Show();
            }
        }

        /// <summary>
        /// Returns all messages without any filtering.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option1(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing All data function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<List<object>> filtredMessages = allMessages;
            return filtredMessages;
        }

        /// <summary>
        /// Filters out messages that are not "Mode S Roll-Call" or "Mode S Roll-Call + PSR" based on the 5th column (TYP).
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option2(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing pure blanks function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            foreach (var message in allMessages)
            {
                object TYP = message[4]; 

                if (TYP.ToString() == "Mode S Roll-Call" || TYP.ToString() == "Mode S Roll-Call + PSR")
                {
                    filtredMessages.Add(message); 
                }
            }

            return filtredMessages; 
        }

        /// <summary>
        /// Filters out messages with a specific value (7777) in the 6th column and returns the remaining messages.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option3(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing fixed transponders function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            foreach (var message in allMessages)
            {
                object MODE_3A = message[5];

                if (MODE_3A.ToString() != "7777")
                {
                    filtredMessages.Add(message); 
                }
            }
            return filtredMessages;
        }

        /// <summary>
        /// Filters messages based on a geographic range (latitude and longitude) specified by the user, with error handling for invalid ranges. Shows a dialog to collect filter values.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<List<object>> Option4(List<List<object>> allMessages)
        {
            List<List<object>> filtredMessages = new List<List<object>>();

            if (allMessages == null)
            {
                throw new ArgumentNullException(nameof(allMessages), "The list of all messages cannot be null.");
            }

            bool hasValidMessages = false; 

            while (!hasValidMessages)
            {
                GeographicFilter geographicFilter = new GeographicFilter(this);
                this.Enabled = true;
                geographicFilter.ShowDialog();

                double minLatitude = geographicFilter.MinLatitude;
                double maxLatitude = geographicFilter.MaxLatitude;
                double minLongitude = geographicFilter.MinLongitude;
                double maxLongitude = geographicFilter.MaxLongitude;
                bool Cancel = geographicFilter.cancel;

                if (minLatitude < -90 || maxLatitude > 90 || minLongitude < -180 || maxLongitude > 180)
                {
                    throw new ArgumentOutOfRangeException("Geographic filter values are out of valid range.");
                }

                filtredMessages.Clear();

                foreach (var message in allMessages)
                {
                    double latitude = Convert.ToDouble(message[1]);
                    double longitude = Convert.ToDouble(message[2]);

                    if (latitude < -90 || latitude > 90)
                    {
                        throw new ArgumentOutOfRangeException("Latitude value is out of valid range.");
                    }

                    if (longitude < -180 || longitude > 180)
                    {
                        throw new ArgumentOutOfRangeException("Longitude value is out of valid range.");
                    }

                    if (latitude >= minLatitude && latitude <= maxLatitude &&
                        longitude >= minLongitude && longitude <= maxLongitude)
                    {
                        filtredMessages.Add(message); 
                    }
                }
                if (filtredMessages.Count == 0 & Cancel == false)
                {
                    MessageBox.Show("No messages matched the specified geographic filter. Please adjust the latitude and longitude values.",
                                    "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (filtredMessages.Count == 0 & Cancel == true)
                {
                    return null;
                }
                if (filtredMessages.Count > 0)
                {
                    hasValidMessages = true;
                }
            }

            return filtredMessages;
        }

        /// <summary>
        /// Filters out messages with aircraft flying above 6000 feet by converting the altitude from meters to feet.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option5(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing flights above 6000 ft.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            foreach (var message in allMessages)
            {
                string H = Convert.ToString(message[3]);
                if (double.TryParse(H, out double h))
                {
                    h *= 3.280839895; 
                    if (h <= 6000)
                    {
                        filtredMessages.Add(message);
                    }
                }
            }
            return filtredMessages;
        }

        /// <summary>
        /// Filters out messages for flights on the ground, keeping only airborne flights based on specific status and altitude conditions.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option6(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing: Removing on-ground flights.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            foreach (var message in allMessages)
            {
                string STAT = Convert.ToString(message[7]);
                string H_s = Convert.ToString(message[3]);

                double H = 0;
                bool isNumeric = double.TryParse(H_s, out H);

                if (STAT == "No alert, no SPI, aircraft airborne" || STAT == "Alert, no SPI, aircraft airborne")
                {
                    filtredMessages.Add(message);
                }
                else if (STAT == "Alert, SPI, aircraft airborne or on ground" || STAT == "No alert, SPI, aircraft airborne or on ground" || STAT == "Not assigned" || STAT == "Unknown")
                {
                    if (isNumeric && H > 0)
                    {
                        filtredMessages.Add(message);
                    }
                }
            }

            return filtredMessages;
        }


        /// <summary>
        /// Applies multiple combined filters to the messages by showing a dialog, then returns the filtered data.
        /// </summary>
        /// <param name="allMessages"></param>
        /// <returns></returns>
        public List<List<object>> Option7(List<List<object>> allMessages)
        {

            List<List<object>> filtredMessages = new List<List<object>>();

            using (var combinedFilters = new CombinedFilters(this, allMessages))
            {
                this.Enabled = false;
                combinedFilters.ShowDialog();
                filtredMessages = combinedFilters.GetFilteredData();

            }
            this.Enabled = true;
            return filtredMessages;
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Welcome Welc = new Welcome();
            this.Hide();
            Welc.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpTimer.Start();
        }

        private void buttonTutorial_Click(object sender, EventArgs e)
        {
            Tutorial Tut = new Tutorial();
            Tut.Show();
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
        /// Starts the animation for the "Settings" container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsTimer.Start();
        }

        /// <summary>
        /// Toggles between light and dark mode, saving the theme state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme(); 

            Properties.Settings1.Default.IsDarkMode = isDarkMode;
            Properties.Settings1.Default.Save();
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
            SidebarTimer.Start();
        }
    }
}