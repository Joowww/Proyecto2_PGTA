using System;
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

            string filePathAST = "230502-est-080001_BCN_60MN_08_09.ast";

            // Path where to save bits
            string outputFilePath = "TextFile1.txt";

            // Crear una tabla para almacenar FSPEC y los Data Items
            DataTable messageTable = new DataTable();

            // Definir las columnas de la tabla
            messageTable.Columns.Add("MessageObject", typeof(CAT048));

            // Obtener todas las propiedades de CAT048
            PropertyInfo[] properties = typeof(CAT048).GetProperties();

            // Añadir columnas a la tabla por cada propiedad
            foreach (PropertyInfo property in properties)
            {
                messageTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }


            try
            {
                // Open the file
                using (FileStream filestream = new FileStream(filePathAST, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader decoder = new BinaryReader(filestream))
                    {

                        
                        // Read the file like an array of bytes
                        byte[] fileBytes = File.ReadAllBytes(filePathAST);

                        // Read the first byte (CAT)
                        byte CAT = fileBytes[0];

                        // Save to a file all the bits in the AST file (to verify we're getting the correct characters)
                        byte[] fileBytes2 = decoder.ReadBytes((int)filestream.Length);
                        using (StreamWriter writer = new StreamWriter(outputFilePath, false))

                            for (int i = 0; i < fileBytes2.Length; i++)
                            {
                                // Convertir cada byte a una cadena binaria de 8 bits
                                string binaryString = Convert.ToString(fileBytes2[i], 2).PadLeft(8, '0');

                                // Escribir el valor binario (solo 0 y 1) en el archivo de salida
                                writer.Write(binaryString + " ");
                            }

                        //Initialize variables set to false or null
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
                                string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                FSPEC += binaryString; // Concatenate binaryString to FSPEC
                                char FX = binaryString[binaryString.Length - 1]; //Obtain FX

                                if (FX == '0')
                                {
                                    endOfFSPEC = true; // Shifts to true if FX is 0 to contiue reading

                                    int i3 = 1;
                                    for (int i2 = 0; i2 < FSPEC.Length; i2++)
                                    {

                                        if (i2 % 8 != 7)
                                        {
                                            if (FSPEC[i2] == '1')
                                            {
                                                posiciones.Add(i3);  //Get positions with a 1, Data Field present
                                                i3++;
                                            }
                                        }
                                    }
                                    continue;
                                    
                                }
                                
                            }

                            
                            if (i >= 3 && endOfFSPEC == true) //When FSPEC is read, read all Data Item until last one
                            {
                                
                                    string DataItemRead = Convert.ToString(posiciones[contadorDI]);   //Get what Data Item ID is being processed

                                    //Case where Data Item has 2 bytes
                                    if (DataItemRead == "1" || DataItemRead == "5" || DataItemRead == "6" || DataItemRead == "11" || DataItemRead == "17" || DataItemRead == "19" || DataItemRead == "21" || DataItemRead == "24" || DataItemRead == "26")
                                    {
                                        string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        DataItem += octet; // Concatenate binaryString
                                        if (DataItem.Length == 16)
                                        {
                                            endOfDF = true; //Now Data Item is complete
                                        }
                                    }

                                    //Case for variable length Data Item (1+)
                                    if (DataItemRead == "3" || DataItemRead == "14" || DataItemRead == "16" || DataItemRead == "20")
                                    {
                                        string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        char FX = binaryString[binaryString.Length - 1]; //Obtain FX
                                        if (FX == '0')
                                            endOfDF = true; // Shifts to true if FX is 0 to contiue reading
                                        DataItem += binaryString; // Concatenate binaryString 
                                    }

                                    //Case for variable length Data Item (1+ 1+)
                                    if (DataItemRead == "7" || DataItemRead == "27" || DataItemRead == "28" )
                                    {
                                        string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        char FX = binaryString[binaryString.Length - 1]; //Obtain FX
                                        DataItem += binaryString; // Concatenate binaryString 
                                        if (DataItem.Length == 8)
                                        {

                                            for (int i2 = 0; i2 < DataItem.Length; i2++)
                                            {
                                                if (DataItem[i2] == '1')
                                                {
                                                    posiciones2.Add(i2);  //Get positions with a 1, Data Field present
                                                }
                                            }
                                        }

                                        if (DataItem.Length == (8 + 8*posiciones2.Count)) 
                                        {
                                            endOfDF = true;   
                                        }
                                    }

                                    // Case where Data Item has 3 bytes
                                    if (DataItemRead == "2" || DataItemRead == "8")
                                        {
                                            string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                            DataItem += octet; // Concatenate binaryString
                                            if (DataItem.Length == (3*8) ) //3*8 bits
                                            {
                                                endOfDF = true; //Now Data Item is complete
                                            }
                                        }

                                    // Case where Data Item has 4 bytes
                                    if (DataItemRead == "4" || DataItemRead == "12" || DataItemRead == "13" || DataItemRead == "15" || DataItemRead == "18" )
                                    {
                                        string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        DataItem += octet; // Concatenate binaryString
                                        if (DataItem.Length == (4 * 8)) //4*8 bits
                                        {
                                            endOfDF = true; //Now Data Item is complete
                                        }
                                    }

                                    // Case where Data Item has 6 bytes
                                    if (DataItemRead == "9" )
                                    {
                                        string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        DataItem += octet; // Concatenate binaryString
                                        if (DataItem.Length == (6 * 8)) //6*8 bits
                                        {
                                            endOfDF = true; //Now Data Item is complete
                                        }
                                    }

                                    // Case where Data Item has 7 bytes
                                    if (DataItemRead == "22")
                                        {
                                            string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                            DataItem += octet; // Concatenate binaryString
                                            if (DataItem.Length == (7 * 8)) //7*8 bits
                                            {
                                                endOfDF = true; //Now Data Item is complete
                                            }
                                        }

                                    //Repetitive Data Item
                                    if (DataItemRead == "10")
                                    {
                                        string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        DataItem += octet; // Concatenate binaryString
                                        if (DataItem.Length == 8)
                                        {
                                            REP = currentByte;
                                        }
                                        if (DataItem.Length == (8 + 8*8*REP)) // 1 + 8*n bytes
                                        {
                                            endOfDF = true; //Now Data Item is complete
                                        }
                                    }

                                    //One byte
                                    if (DataItemRead == "23")
                                    {
                                        string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                        DataItem += octet;
                                        endOfDF = true;

                                    }


                                //Once Data Item is all read, call function 
                                if (endOfDF == true)
                                {
                                    DataItemRead2 = Convert.ToInt32(DataItemRead);
                                    Function function = new Function();  // Iniciate a class from the other namespace
                                    function.assignDF(DataItem, DataItemRead2, Variable048);
                                    
                                    
                                    endOfDF = false;   //Set end of DF to false
                                    DataItem = "";     //Set Data Item to empty again
                                    contadorDI += 1;   //Increase number of Data Item read

                                    if (contadorDI == (posiciones.Count))
                                    {
                                        // Cuando se ha leído todo el mensaje (FSPEC y Data Items)
                                        //string concatenatedDataItems = string.Join(", ", currentDataItems);
                                        // Añadir una nueva fila a la tabla con el FSPEC y los Data Items

                                        // Crear una nueva fila
                                        DataRow newRow = messageTable.NewRow();

                                        // Asignar valores de variable048 a la fila
                                        foreach (PropertyInfo property in properties)
                                        {
                                            newRow[property.Name] = property.GetValue(Variable048) ?? DBNull.Value; // Usa DBNull para valores null
                                        }

                                        // Añadir la fila a la tabla
                                        messageTable.Rows.Add(newRow);
                                        endOfFSPEC = false; //Initalize a new message with new FSPEC and new Data Items
                                        FSPEC = "";
                                        DataItem = "";
                                        contadorDI = 0;
                                        endOfDF = false;
                                        REP = 0;
                                        posiciones.Clear();
                                        posiciones2.Clear();
                                        Variable048 = new CAT048();


                                    }

                                }

                            }
                        }
                    }
                }
                // Mostrar la tabla de mensajes
                Console.WriteLine("Tabla de mensajes:");
                foreach (DataRow row in messageTable.Rows)
                {
                    Console.WriteLine(row);
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo AST: " + ex.Message);
            }

            
        }
  
}
}