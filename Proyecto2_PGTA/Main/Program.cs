using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.Sockets;
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

                        List<int> posiciones = new List<int>();

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
                                                      
                                    for (int i2 = 0; i2 < FSPEC.Length; i2++)
                                    {
                                        if (FSPEC[i] == '1')
                                        {
                                            posiciones.Add(i2);  //Get positions with a 1, Data Field present
                                        }
                                    }
                                    continue;
                                }
                                
                            }

                            
                            if (i >= 3 && endOfFSPEC ==true && contadorDI<=posiciones.Count) //When FSPEC is read, read all Data Item until last one
                            {
                                    string DataItemRead = Convert.ToString(posiciones[contadorDI] + 1);   //Get what Data Item ID is being processed

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
                                    if (DataItemRead == "3" ||  DataItemRead == "10" || DataItemRead == "14" || DataItemRead == "16" || DataItemRead == "20")
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
                                        if (FX == '0')
                                            endOfDF = true; // Shifts to true if FX is 0 to contiue reading
                                        DataItem += binaryString; // Concatenate binaryString 
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

                                    // Case where DataF Item has 4 bytes
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

                                    // Case where DataF Item has 7 bytes
                                    if (DataItemRead == "22")
                                        {
                                            string octet = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                            DataItem += octet; // Concatenate binaryString
                                            if (DataItem.Length == (7 * 8)) //6*8 bits
                                            {
                                                endOfDF = true; //Now Data Item is complete
                                            }
                                        }


                                //Once Data Item is all read, call function 
                                if (endOfDF == true)
                                {
                                    Function function = new Function();  // Iniciate a class from the othe namItem
                                    endOfDF = false;   //Set end of DF to false
                                    DataItem = "";     //Set Data Item to empty again
                                    contadorDI += 1;   //Increase number of Data Item read

                                    if (contadorDI == posiciones.Count)
                                    {
                                        endOfFSPEC = false; //Initalize a new message with new FSPEC and new Data Items
                                    }
                                }

                            }
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo AST: " + ex.Message);
            }


        }
    }
  
}