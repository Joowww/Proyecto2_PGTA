using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using AstDecoder;

namespace Main
{

    public class Program
    {
        static void Main()
        {
            // Path of the AST file to be processed
            string filePathAST = "230502-est-080001_BCN_60MN_08_09.ast";

            // Path where the binary representation of the AST file will be saved
            string outputFilePath = "TextFile1.txt";

            // Create a DataTable to store FSPEC and Data Items
            DataTable messageTable = new DataTable();

            // Define the columns for the table
            messageTable.Columns.Add("MessageObject", typeof(CAT048));

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
                                            posiciones.Add(i2+1);    
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
                                if (DataItemRead == "7" || DataItemRead == "27" || DataItemRead == "28" )
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
                                    if (DataItem.Length == (8 + 8*posiciones2.Count)) 
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
                                        if (DataItem.Length == (3*8) ) 
                                        {
                                            //Now Data Item is complete
                                            endOfDF = true; 
                                        }
                                    }

                                // Case where Data Item has 4 bytes
                                if (DataItemRead == "4" || DataItemRead == "12" || DataItemRead == "13" || DataItemRead == "15" || DataItemRead == "18" )
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
                                    if (DataItemRead == "9" )
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
                                        if (DataItem.Length == (8 + 8*8*REP)) 
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
                                        foreach (PropertyInfo property in properties)
                                        {
                                            // Use DBNull for null values
                                            newRow[property.Name] = property.GetValue(Variable048) ?? DBNull.Value; 
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

            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during file processing
                Console.WriteLine("Error al leer el archivo AST: " + ex.Message);
            }

            
        }
  
}
}