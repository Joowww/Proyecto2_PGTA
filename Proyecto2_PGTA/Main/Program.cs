using System;
using System.Diagnostics.Metrics;
using System.IO;
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
                        string DataField = "";

                        int DataFieldFSPEC = 0;

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
                                char FX = binaryString[binaryString.Length - 1]; //Obtain FX
                                if (FX == '0')
                                    endOfFSPEC = true; // Shifts to true if FX is 0 to contiue reading
                                FSPEC += binaryString; // Concatenate binaryString to FSPEC


                            }

                            if (i >= 3 && endOfFSPEC ==true)
                            {
                                if (endOfDF == false)
                                {
                                    string binaryString = Convert.ToString(currentByte, 2).PadLeft(8, '0'); //Convert to string bits
                                    char FX = binaryString[binaryString.Length - 1]; //Obtain FX
                                    if (FX == '0')
                                        endOfDF = true; // Shifts to true if FX is 0 to contiue reading
                                    DataField += binaryString; // Concatenate binaryString to FSPEC


                                    int numOfDataFields = FSPEC.Length;
                                    if (endOfDF == true)
                                    {
                                        Function function = new Function();  // Instanciar la clase de otro proyecto
                                        function.assignDF(DataField, FSPEC); //Call function to assign to Data Field
                                        endOfDF = false;//Set end of DF to false
                                        DataField = ""; //Set DataField to empty again
                                    }

                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Lectura completada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo AST: " + ex.Message);
            }


        }
    }
  


    
    
}