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
        private Rectangle recBut6;
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
        private Rectangle recPtb6;
        private Rectangle recPtb7;
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
            recBut6 = new Rectangle(button9.Location, button9.Size);
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
            recPtb6 = new Rectangle(pictureBox3.Location, pictureBox3.Size);
            recPtb7 = new Rectangle(pictureBox5.Location, pictureBox5.Size);
            recPanel1 = new Rectangle(panel5.Location, panel5.Size);
            recPanel2 = new Rectangle(panel17.Location, panel17.Size);
            recPanel3 = new Rectangle(panel12.Location, panel12.Size);
            recPanel4 = new Rectangle(panel18.Location, panel18.Size);
            recPanel5 = new Rectangle(panel4.Location, panel4.Size);
            recPanel6 = new Rectangle(panel13.Location, panel13.Size);
            recPanel7 = new Rectangle(panel14.Location, panel14.Size);
            recPanel8 = new Rectangle(panel15.Location, panel15.Size);
            recPanel9 = new Rectangle(panel11.Location, panel11.Size);
            recPanel10 = new Rectangle(panel1.Location, panel1.Size);
            recPanel11 = new Rectangle(panel2.Location, panel2.Size);
            recPanel12 = new Rectangle(panel9.Location, panel9.Size);
            recPanel13 = new Rectangle(panel10.Location, panel10.Size);
            recCont1 = new Rectangle(HelpContainer.Location, HelpContainer.Size);
            recCont2 = new Rectangle(SettingsContainer.Location, SettingsContainer.Size);
            //recSb1 = new Rectangle(sidebar.Location, sidebar.Size);
            int minWidthSb = recPanel2.Right - sidebar.Left;
            int maxWidthSb = recPanel1.Right - sidebar.Left;

            sidebar.MinimumSize = new Size(minWidthSb, sidebar.Height);
            sidebar.MaximumSize = new Size(maxWidthSb, sidebar.Height);

            pictureBox7.Left = this.ClientSize.Width - pictureBox7.Width - 15;
            pictureBox7.Top = this.ClientSize.Height - pictureBox7.Height - 15;

            StartSimulation();
        }

        private void Principal_Resiz(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                resize_Control(SimulateBtn, recBut1);
                resize_Control(buttonHelp, recBut2);
                resize_Control(buttonTutorial, recBut3);
                resize_Control(buttonSettings, recBut4);
                resize_Control(button3, recBut5);
                resize_Control(button9, recBut6);
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
                resize_Control(pictureBox3, recPtb6);
                resize_Control(pictureBox5, recPtb7);
                resize_Control(panel5, recPanel1);
                resize_Control(panel17, recPanel2);
                resize_Control(panel12, recPanel3);
                resize_Control(panel18, recPanel4);
                resize_Control(panel4, recPanel5);
                resize_Control(panel13, recPanel6);
                resize_Control(panel14, recPanel7);
                resize_Control(panel15, recPanel8);
                resize_Control(panel11, recPanel9);
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
                restore_ControlSize(button9, recBut6);
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
                restore_ControlSize(pictureBox3, recPtb6);
                restore_ControlSize(pictureBox5, recPtb7);
                restore_ControlSize(panel5, recPanel1);
                restore_ControlSize(panel17, recPanel2);
                restore_ControlSize(panel12, recPanel3);
                restore_ControlSize(panel18, recPanel4);
                restore_ControlSize(panel4, recPanel5);
                restore_ControlSize(panel13, recPanel6);
                restore_ControlSize(panel14, recPanel7);
                restore_ControlSize(panel15, recPanel8);
                restore_ControlSize(panel11, recPanel9);
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

        private void restore_ControlSize(Control control, Rectangle originalRect)
        {
            control.Location = originalRect.Location;
            control.Size = originalRect.Size;

            // Restauramos el tamaño de la fuente original
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

            // Ajustar tamaño de la fuente
            float fontSizeRatio = Math.Min(xRatio, yRatio); // Escala basada en la menor proporción
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

        private void AdjustAboutUsContainer2Size()
        {
            SettingsContainer.Location = new Point(SettingsContainer.Location.X, panel4.Top);

            int minHeightCont2 = panel4.Bottom - panel4.Top;
            int maxHeightCont2 = panel11.Bottom - panel4.Top;

            int minWidthCont1 = panel17.Right - sidebar.Left;
            int maxWidthCont1 = panel5.Right - sidebar.Left;


            SettingsContainer.MinimumSize = new Size(minWidthCont1, minHeightCont2);
            SettingsContainer.MaximumSize = new Size(maxWidthCont1, maxHeightCont2);

            sidebarExpand = true;

        }
        private void StartSimulation()
        {

            // Path where the binary representation of the AST file will be saved
            string outputFilePath = "TextFile1.txt";

            // Create a DataTable to store FSPEC and Data Items
            DataTable messageTable = new DataTable();

            // Define the columns for the table
            messageTable.Columns.Add("Message Object", typeof(CAT048));

            // Get all properties of the CAT048 class
            PropertyInfo[] properties = typeof(CAT048).GetProperties();

            // Add columns to the table for each property in CAT048
            foreach (PropertyInfo property in properties)
            {
                messageTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }


            try
            {
                // Open the AST file for reading
                using (FileStream filestream = new FileStream(filePathAST, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader decoder = new BinaryReader(filestream))
                    {


                        // Read the entire AST file into a byte array
                        byte[] fileBytes = File.ReadAllBytes(filePathAST);

                        // Read the first byte which indicates the Category (CAT)
                        byte CAT = fileBytes[0];

                        // Save the entire AST file as a binary string (for verification purposes)
                        byte[] fileBytes2 = decoder.ReadBytes((int)filestream.Length);
                        using (StreamWriter writer = new StreamWriter(outputFilePath, false))

                            // Loop through each byte and convert it to binary format
                            for (int i = 0; i < fileBytes2.Length; i++)
                            {
                                // Convert byte to 8-bit binary
                                string binaryString = Convert.ToString(fileBytes2[i], 2).PadLeft(8, '0');

                                // Write binary values to output file
                                writer.Write(binaryString + " ");
                            }

                        // Initialize variables for FSPEC and Data Item reading
                        bool endOfFSPEC = false;
                        string FSPEC = "";

                        bool endOfDF = false;
                        string DataItem = "";

                        int DataFieldFSPEC = 0;
                        // Counter for Data Items
                        int contadorDI = 0;
                        // Repetition indicator
                        int REP = 0;
                        int DataItemRead2 = 0;

                        // To store current Data Items
                        List<string> currentDataItems = new List<string>();
                        // Store positions of '1' in FSPEC
                        List<int> posiciones = new List<int>();
                        // Store secondary positions in some Data Items
                        List<int> posiciones2 = new List<int>();
                        // Instance of CAT048
                        CAT048 Variable048 = new CAT048();

                        // Start reading file bytes from the second byte (first byte is the category)
                        for (int i = 1; i < fileBytes.Length; i++)
                        {
                            byte currentByte = fileBytes[i];

                            // Special handling of the first two bytes after CAT
                            if (i == 1)
                            {
                                byte c2 = fileBytes[i + 1];

                                int combined = (currentByte << 8) | c2;
                                // Convert to string bits
                                string binaryString = Convert.ToString(combined, 2).PadLeft(16, '0');
                            }

                            // FSPEC reading starts at the third byte
                            if (i >= 3 && endOfFSPEC == false)
                            {
                                // Convert to string bits
                                string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                // Concatenate binaryString to FSPEC
                                FSPEC += binaryString.Substring(0, 7);
                                // Obtain FX
                                char FX = binaryString[binaryString.Length - 1];

                                // If FX is 0, FSPEC reading is complete
                                if (FX == '0')
                                {
                                    // Shifts to true if FX is 0 to contiue reading
                                    endOfFSPEC = true;

                                    for (int i2 = 0; i2 < FSPEC.Length; i2++)
                                    {
                                        if (FSPEC[i2] == '1')
                                        {
                                            //Get positions with a 1, Data Field present
                                            posiciones.Add(i2 + 1);
                                        }
                                    }
                                    // Continue to the next byte
                                    continue;
                                }
                            }

                            // Once FSPEC is read, start reading Data Items until the last one
                            if (i >= 3 && endOfFSPEC == true)
                            {
                                //Get what Data Item ID is being processed
                                string DataItemRead = Convert.ToString(posiciones[contadorDI]);

                                //Case where Data Item has 2 bytes
                                if (DataItemRead == "1" || DataItemRead == "5" || DataItemRead == "6" || DataItemRead == "11" || DataItemRead == "17" || DataItemRead == "19" || DataItemRead == "21" || DataItemRead == "24" || DataItemRead == "26")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    if (DataItem.Length == 16)
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                //Case for variable length Data Item (1+)
                                if (DataItemRead == "3" || DataItemRead == "14" || DataItemRead == "16" || DataItemRead == "20")
                                {
                                    //Convert to string bits
                                    string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    //Obtain FX
                                    char FX = binaryString[binaryString.Length - 1];
                                    if (FX == '0')
                                        // Shifts to true if FX is 0 to contiue reading
                                        endOfDF = true;
                                    // Concatenate binaryString 
                                    DataItem += binaryString;
                                }

                                //Case for variable length Data Item (1+ 1+)
                                if (DataItemRead == "7" || DataItemRead == "27" || DataItemRead == "28")
                                {
                                    //Convert to string bits
                                    string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    //Obtain FX
                                    char FX = binaryString[binaryString.Length - 1];
                                    // Concatenate binaryString 
                                    DataItem += binaryString;
                                    if (DataItem.Length == 8)
                                    {
                                        for (int i2 = 0; i2 < DataItem.Length; i2++)
                                        {
                                            if (DataItem[i2] == '1')
                                            {
                                                //Get positions with a 1, Data Field present
                                                posiciones2.Add(i2);
                                            }
                                        }
                                    }
                                    // If length matches expected size, Data Field is complete
                                    if (DataItem.Length == (8 + 8 * posiciones2.Count))
                                    {
                                        endOfDF = true;
                                    }
                                }

                                // Case where Data Item has 3 bytes
                                if (DataItemRead == "2" || DataItemRead == "8")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    //3*8 bits
                                    if (DataItem.Length == (3 * 8))
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                // Case where Data Item has 4 bytes
                                if (DataItemRead == "4" || DataItemRead == "12" || DataItemRead == "13" || DataItemRead == "15" || DataItemRead == "18")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    //4*8 bits
                                    if (DataItem.Length == (4 * 8))
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                // Case where Data Item has 6 bytes
                                if (DataItemRead == "9")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    //6*8 bits
                                    if (DataItem.Length == (6 * 8))
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                // Case where Data Item has 7 bytes
                                if (DataItemRead == "22")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    //7*8 bits
                                    if (DataItem.Length == (7 * 8))
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                //Repetitive Data Item
                                if (DataItemRead == "10")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    if (DataItem.Length == 8)
                                    {
                                        REP = currentByte;
                                    }
                                    // 1 + 8*n bytes
                                    if (DataItem.Length == (8 + 8 * 8 * REP))
                                    {
                                        //Now Data Item is complete
                                        endOfDF = true;
                                    }
                                }

                                //One byte
                                if (DataItemRead == "23")
                                {
                                    //Convert to string bits
                                    string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                                    // Concatenate binaryString
                                    DataItem += octet;
                                    endOfDF = true;

                                }


                                //Once Data Item is all read, call function 
                                if (endOfDF == true)
                                {
                                    DataItemRead2 = Convert.ToInt32(DataItemRead);
                                    // Iniciate a class from the other namespace
                                    Function function = new Function();
                                    function.assignDF(DataItem, DataItemRead2, Variable048);

                                    //Set end of DF to false
                                    endOfDF = false;
                                    //Set Data Item to empty again
                                    DataItem = "";
                                    //Increase number of Data Item read
                                    contadorDI += 1;

                                    if (contadorDI == (posiciones.Count))
                                    {
                                        // When the entire message has been read (FSPEC and Data Items)
                                        //string concatenatedDataItems = string.Join(", ", currentDataItems);
                                        // Add a new row to the table with the FSPEC and Data Items

                                        Function h = new Function();
                                        h.H(Variable048);

                                        // Create a new row
                                        DataRow newRow = messageTable.NewRow();

                                        // Assign values of variable048 
                                        // Assign values of variable048 
                                        foreach (PropertyInfo property in properties)
                                        {
                                            // Get value
                                            var value_property = property.GetValue(Variable048);

                                            //If empty, assign "N/A"
                                            if (value_property == null || string.IsNullOrEmpty(value_property.ToString()))
                                            {
                                                newRow[property.Name] = "N/A";
                                            }
                                            else
                                            {
                                                if (property.Name == "MODE_3A")
                                                {
                                                    // Make sure Mode 3A is treated as a string and preserve leading zeros
                                                    newRow[property.Name] = value_property.ToString().PadLeft(4, '0');
                                                }
                                                if (property.Name == "TA")
                                                    newRow[property.Name] = value_property.ToString();

                                                // Check if it is a numeric property
                                                else if (double.TryParse(value_property.ToString(), out double numericValue))
                                                {
                                                    // Round to 3 decimals 
                                                    newRow[property.Name] = Math.Round(numericValue, 10);
                                                }
                                                else
                                                {
                                                    newRow[property.Name] = value_property.ToString();
                                                }
                                            }
                                        }

                                        // Add a row to the table
                                        messageTable.Rows.Add(newRow);
                                        //Initalize a new message with new FSPEC and new Data Items
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
                // Print the message table to the console
                Console.WriteLine("Tabla de mensajes:");
                foreach (DataRow row in messageTable.Rows)
                {
                    Console.WriteLine(row);

                }


                // Path where you want to save the CSV file
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ASTERIX.csv"); // Save as output.csv in the bin folder

                // Call the method to export the table to CSV
                ExportDataTableToCSV(messageTable, filePath);

            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during file processing
                Console.WriteLine("Error at reading the AST file: " + ex.Message);
            }

            // Method to export a DataTable to a CSV file
            static void ExportDataTableToCSV(DataTable table, string filePath)
            {
                // Use StreamWriter to create the file at the specified path
                using (StreamWriter SW = new StreamWriter(filePath))
                {
                    // Write the column names in the first line
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        SW.Write(table.Columns[i].ColumnName);  // Write the current column name
                        if (i < table.Columns.Count - 1)
                            SW.Write("\t");  // Add a comma between columns
                    }
                    SW.WriteLine();  // Write a newline after the header row

                    // Write the data for each row
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            string cellValue = row[i].ToString().Replace("\"", "\"\"");  // searches for instances of a single quote ("), and replaces them with two quotes ("")
                            SW.Write($"\"{cellValue}\"");  // Enclose the cell value in quotes
                            if (i < table.Columns.Count - 1)
                                SW.Write("\t");  // Add a comma between columns
                        }
                        SW.WriteLine();  // Write a newline after each row
                    }
                }
            }

        }


        private void Form_Load(object sender, EventArgs e)
        {

            // Agregar elementos al ComboBox
            comboBox1.Items.Add("All data");
            comboBox1.Items.Add("Removing pure blanks");
            comboBox1.Items.Add("Removing fixed transponders");
            comboBox1.Items.Add("Geographic filter");
            comboBox1.Items.Add("Removing flights above 6000 ft");
            comboBox1.Items.Add("Removing on ground flights");
            comboBox1.Items.Add("Combination of these");
            comboBox1.SelectedIndex = 0; // Seleccionar la primera opción por defecto
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private async void SimulateBtn_Click(object sender, EventArgs e)
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
                    string Altitude_Corrected = Convert.ToString(row[77]);
                    string TYP = Convert.ToString(row[8]);
                    string MODE_3A = Convert.ToString(row[23]);
                    string TA = Convert.ToString(row[35]);
                    string STAT = Convert.ToString(row[70]);
                    string TI = Convert.ToString(row[36]).Trim();

                    // Validar que TA no sea null o una cadena vacía antes de agregar a allMessages
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
                else if (selection == "Geographic filter")
                {
                    filtredMessages = Option4(allMessages);

                    // Check if Option4 was canceled and returned null
                    if (filtredMessages == null)
                    {
                        return; // Exit the method without creating the map
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

                    // Check if Option4 was canceled and returned null
                    if (filtredMessages == null)
                    {
                        return; // Exit the method without creating the map
                    }
                }
                SelectedIndexOption = comboBox1.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading the file: " + ex.Message);
            }

            // If filtredMessages is not null, proceed with opening the map
            if (filtredMessages != null)
            {
                Mapa mapa = new Mapa(filtredMessages, allMessages, SelectedIndexOption, this);
                // Hide the main form
                this.Hide();
                // Show the Map form
                mapa.Show();
            }
        }

        // Funciones correspondientes a cada opción seleccionada
        public List<List<object>> Option1(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing All data function.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //For "All data"
            //Retorno la lista tal cual, no se filtra
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
            List<List<object>> filtredMessages = new List<List<object>>();

            // Validate if allMessages is null
            if (allMessages == null)
            {
                throw new ArgumentNullException(nameof(allMessages), "The list of all messages cannot be null.");
            }

            bool hasValidMessages = false; // To track if valid messages are found

            // Loop until we get valid results or until the user cancels
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

                // Validate the geographic filter values
                if (minLatitude < -90 || maxLatitude > 90 || minLongitude < -180 || maxLongitude > 180)
                {
                    throw new ArgumentOutOfRangeException("Geographic filter values are out of valid range.");
                }

                // Reset the filtered messages before starting the filtering process
                filtredMessages.Clear();

                // Loop through all the messages
                foreach (var message in allMessages)
                {
                    // Attempt to convert latitude and longitude to doubles
                    double latitude = Convert.ToDouble(message[1]);
                    double longitude = Convert.ToDouble(message[2]);

                    // Validate latitude and longitude are within the valid range
                    if (latitude < -90 || latitude > 90)
                    {
                        throw new ArgumentOutOfRangeException("Latitude value is out of valid range.");
                    }

                    if (longitude < -180 || longitude > 180)
                    {
                        throw new ArgumentOutOfRangeException("Longitude value is out of valid range.");
                    }

                    // Check if the latitude and longitude are within the specified geographic range
                    if (latitude >= minLatitude && latitude <= maxLatitude &&
                        longitude >= minLongitude && longitude <= maxLongitude)
                    {
                        filtredMessages.Add(message); // Add the message if it passes the filter
                    }
                }

                // If no messages were filtered, show a message and allow the user to input new values
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
                    // If there are valid filtered messages, set the flag to true to stop the loop
                    hasValidMessages = true;
                }
            }

            return filtredMessages;
        }

        public List<List<object>> Option5(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing Removing flights above 6000 ft.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {
                string H = Convert.ToString(message[3]);
                // Verificamos si H es numérico antes de convertirlo
                if (double.TryParse(H, out double h))
                {
                    h *= 3.280839895; // Convertimos metros a pies
                    if (h <= 6000)
                    {
                        filtredMessages.Add(message);
                    }
                }
                // Si H es "N/A" o no es un número, simplemente no se añade el mensaje a filtredMessages
            }
            return filtredMessages;
        }

        public List<List<object>> Option6(List<List<object>> allMessages)
        {
            MessageBox.Show("Executing: Removing on-ground flights.", "Simulate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<List<object>> filtredMessages = new List<List<object>>();

            // Recorremos todos los mensajes
            foreach (var message in allMessages)
            {
                string STAT = Convert.ToString(message[7]);
                string H_s = Convert.ToString(message[3]);

                // Intentamos convertir H_s a un double, si falla, asignamos H a 0 para evitar errores
                double H = 0;
                bool isNumeric = double.TryParse(H_s, out H);

                if (STAT == "No alert, no SPI, aircraft airborne" || STAT == "Alert, no SPI, aircraft airborne")
                {
                    filtredMessages.Add(message);
                }
                else if (STAT == "Alert, SPI, aircraft airborne or on ground" || STAT == "No alert, SPI, aircraft airborne or on ground" || STAT == "Not assigned" || STAT == "Unknown")
                {
                    // Solo añadimos si es numérico y H es mayor que 0
                    if (isNumeric && H > 0)
                    {
                        filtredMessages.Add(message);
                    }
                }
            }

            return filtredMessages;
        }


        public List<List<object>> Option7(List<List<object>> allMessages)
        {

            List<List<object>> filtredMessages = new List<List<object>>();

            // Abrir el formulario CombinedFilters como modal
            using (var combinedFilters = new CombinedFilters(this, allMessages))
            {
                this.Enabled = false;
                combinedFilters.ShowDialog();
                filtredMessages = combinedFilters.GetFilteredData();

            }
            this.Enabled = true;
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
            Tutorial Tut = new Tutorial();
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