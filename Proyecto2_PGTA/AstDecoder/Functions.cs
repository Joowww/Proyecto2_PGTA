using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;
using MultiCAT6.Utils;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Accord.Math;
using System.Data;
using Accord.Statistics;
using Simulation;

namespace AstDecoder
{
    public class CAT048
    {
        public List<Byte> DataBlock;
        public int DataLength;
        public int Message_length;

        // Variables for Data Item (010) [2 Oct]
        public string SAC { get; set; }
        public string SIC { get; set; }

        // Variables for Data Item (140) [3 Oct]
        public string UTC_TIME { get; set; }
        public string UTC_TIME_s { get; set; }

        // Variables for LAT, LON and H
        public string LAT { get; set; }
        public string LON { get; set; }
        public string H { get; set; }

        // Variables for Data Item (020) [1+ ("Variable") Oct]
        public string TYP { get; set; }
        public string SIM { get; set; }
        public string RDP { get; set; }
        public string SPI { get; set; }
        public string RAB { get; set; }
        public string TST { get; set; }
        public string ERR { get; set; }
        public string XPP { get; set; }
        public string ME { get; set; }
        public string MI { get; set; }
        public string FOE_FRI { get; set; }

        // Variables for Data Item (040) [4 Oct]
        public string RHO { get; set; }
        public string THETA { get; set; }

        // Variables for Data Item (070) [2 Oct] 
        public string V_070 { get; set; }
        public string G_070 { get; set; }
        public string MODE_3A { get; set; }

        // Variables for Data Item (090) [2 Oct] 
        public string V_090 { get; set; }
        public string G_090 { get; set; }
        public string FL { get; set; }

        // Mode C corrected
        public string ModeC_corrected { get; set; }

        // Variables for Data Item (130) [1+ 1+ Oct]
        public string SRL { get; set; }
        public string SRR { get; set; }
        public string SAM { get; set; }
        public string PRL { get; set; }
        public string PAM { get; set; }
        public string RPD { get; set; }
        public string APD { get; set; }
       
        // Variables for Data Item (220) [3 Oct]
        public string TA { get; set; }

        // Variables for Data Item (240) [6 Oct]
        public string TI { get; set; }

        // Variables for Data Item (250) [1+8*n Oct]
        public string MCP_ALT { get; set; }
        public string FMS_ALT {get; set; }
        public string BP {  get; set; }
        public string VNAV { get; set; }
        public string ALT_HOLD { get; set; }
        public string APP {  get; set; }
        public string TARGET_ALT_SOURCE { get; set; }
        public string RA { get; set; }
        public string TTA { get; set; }
        public string GS { get; set; }
        public string TAR { get; set; }
        public string TAS { get; set; }
        public string HDG { get; set; }
        public string IAS { get; set; }
        public string MACH { get; set; }
        public string BAR { get; set; }
        public string IVV { get; set; }


        // Variables for Data Item (161) [2 Oct]
        public string TN { get; set; }

        // Variables for Data Item (042) [4 Oct]
        public string xComponent { get; set; }
        public string yComponent { get; set; }

        // Variables for Data Item (200) [4 Oct]
        public string GS_KT { get; set; }
        public string HEADING { get; set; }

        // Variables for Data Item (170) [1+ Oct]
        public string CNF { get; set; }
        public string RAD { get; set; }
        public string DOU { get; set; }
        public string MAH { get; set; }
        public string CDM { get; set; }
        public string TRE { get; set; }
        public string GHO { get; set; }
        public string SUP { get; set; }
        public string TCC { get; set; }

        // Variables for Data Item (110) [2 Oct]
        public string Height_3D { get; set; }

        // Variables for Data Item (230) [2 Oct]
        public string COM { get; set; }
        public string STAT { get; set; }
        public string SI { get; set; }
        public string MSSC { get; set; }
        public string ARC { get; set; }
        public string AIC { get; set; }
        public string B1A { get; set; }
        public string B1B { get; set; }
    }

    public class Function
    {
        // Delegate that will represent the functions you are going to store in the dictionary
        delegate void MiFuncion(string cadenadebits, CAT048 Variable048);

        // Dictionary that associates an ID (int) with a function (MiFuncion)
        Dictionary<int, MiFuncion> DataField_FunctionsDictionary;

        // Constructor of the class where the dictionary is initialized
        public Function()
        {
            DataField_FunctionsDictionary = new Dictionary<int, MiFuncion>
            {
                { 1, DF010},
                { 2, DF140},
                { 3, DF020},
                { 4, DF040},
                { 5, DF070},
                { 6, DF090},
                { 7, DF130},
                { 8, DF220},
                { 9, DF240},
                { 10, DF250},
                { 11, DF161},
                { 12, DF042},
                { 13, DF200},
                { 14, DF170},
                { 15, DF210},
                { 16, DF030},
                { 17, DF080},
                { 18, DF100},
                { 19, DF110},
                { 20, DF120},
                { 21, DF230},
                { 22, DF260},
                { 23, DF055},
                { 24, DF030},
                { 25, DF050},
                { 26, DF065},
                { 27, DF060},
                { 28, DFSP},
                { 29, DFRE},
            };
        }

        /// <summary>
        /// Assign bytes to DataField
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="contador"></param>
        /// <param name="Variable048"></param>
        public void assignDF(string bytes, int contador, CAT048 Variable048) 
        {
            //Call the function associated to the ID with the bytes read as input
            DataField_FunctionsDictionary[contador](bytes, Variable048); 

        }

        /// <summary>
        /// Get SIC and SAC from DF010
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF010(string bytes2, CAT048 Variable048) 
        {
            // Get the first octet (8 bits)
            string sac = bytes2.Substring(0, 8);
            int sac2 = Convert.ToInt32(sac, 2);
            // Assign the converted value to SAC
            Variable048.SAC = Convert.ToString(sac2);
            // Get the next octet (8 bits)
            string sic = bytes2.Substring(8, 8);
            // Assign the converted value to SIC
            int sic2 = Convert.ToInt32(sic, 2);
            Variable048.SIC = Convert.ToString(sic2);  
        }

        /// <summary>
        /// Get time UTC from DF140
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF140(string bytes2, CAT048 Variable048) 
        {
            // Converts the binary string to an integer and multiplies it by 1/128 to get the decimal value for time
            decimal time = (Convert.ToInt32(bytes2, 2)) * 1m / 128m;
            // Converts the time in seconds to a TimeSpan object (Time duration)
            TimeSpan Time = TimeSpan.FromSeconds((double)time);
            // Assigns the time in "hh:mm:ss:fff" format to the UTC_TIME property of the CAT048 object
            Variable048.UTC_TIME = Time.ToString(@"hh\:mm\:ss\:fff");
            // Rounds the decimal value of time and assigns it as an integer to the UTC_TIME_s property
            Variable048.UTC_TIME_s = Convert.ToString((int)Math.Round(time));
        }

        /// <summary>
        /// Get information from DF020
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF020(string bytes2, CAT048 Variable048)
        {
            // Extracts the first octet (8 bits) from the binary string
            string oct1 = bytes2.Substring(0, 8);

            // Extracts the detection type and assigns the corresponding value to TYP
            string typ = oct1.Substring(0, 3);
            if (typ == "000") Variable048.TYP = "No detection";
            if (typ == "001") Variable048.TYP = "PSR";
            if (typ == "010") Variable048.TYP = "SSR";
            if (typ == "011") Variable048.TYP = "SSR + PSR";
            if (typ == "100") Variable048.TYP = "Mode S All-Call";
            if (typ == "101") Variable048.TYP = "Mode S Roll-Call";
            if (typ == "110") Variable048.TYP = "Mode S All-Call + PSR";
            if (typ == "111") Variable048.TYP = "Mode S Roll-Call + PSR";

            // Extracts the simulation bit and assigns the corresponding value to SIM
            string sim = oct1.Substring(3, 1);
            if (sim == "0") Variable048.SIM = "Actual target report";
            if (sim == "1") Variable048.SIM = "Simulated target report";

            // Extracts the RDP bit and assigns the corresponding value to RDP
            string rdp = oct1.Substring(4, 1);
            if (rdp == "0") Variable048.RDP = "RDP Chain 1";
            if (rdp == "1") Variable048.RDP = "RDP Chain 2";

            // Extracts the SPI bit and assigns the corresponding value to SPI
            string spi = oct1.Substring(5, 1);
            if (spi == "0") Variable048.SPI = "Absence of SPI";
            if (spi == "1") Variable048.SPI = "Special Position Identification";

            // Extracts the RAB bit and assigns the corresponding value to RAB
            string rab = oct1.Substring(6, 1);
            if (rab == "0") Variable048.RAB = "Report from Aircraft";
            if (rab == "1") Variable048.RAB = "Report from Field";

            // Extracts the FX1 bit to decide whether to process the second octet
            string FX1 = oct1.Substring(7, 1);

            if (FX1 == "1")
            {
                // Extracts the second octet (8 bits) and evaluates its bits
                string oct2 = bytes2.Substring(8, 8);

                // Extracts the test bit and assigns the corresponding value to TST
                string tst = oct2.Substring(0, 1);
                if (tst == "0") Variable048.TST = "Real target report";
                if (tst == "1") Variable048.TST = "Test target report";

                // Extracts the error bit and assigns the corresponding value to ERR
                string err = oct2.Substring(1, 1);
                if (err == "0") Variable048.ERR = "No Extended Range";
                if (err == "1") Variable048.ERR = "Extended Range present";

                // Extracts the XPP bit and assigns the corresponding value to XPP
                string xpp = oct2.Substring(2, 1);
                if (xpp == "0") Variable048.XPP = "No X-Pulse present";
                if (xpp == "1") Variable048.XPP = "X-Pulse present";

                // Extracts the ME bit and assigns the corresponding value to ME
                string me = oct2.Substring(3, 1);
                if (me == "0") Variable048.ME = "No military emergency";
                if (me == "1") Variable048.ME = "Military emergency";

                // Extracts the MI bit and assigns the corresponding value to MI
                string mi = oct2.Substring(4, 1);
                if (mi == "0") Variable048.MI = "No military identification";
                if (mi == "1") Variable048.MI = "Military identification";

                // Extracts the FOE/FRI bits and assigns the corresponding value to FOE_FRI
                string foe_fri = oct2.Substring(5, 2);
                if (foe_fri == "00") Variable048.FOE_FRI = "No Mode 4 interrogation";
                if (foe_fri == "01") Variable048.FOE_FRI = "Friendly target";
                if (foe_fri == "10") Variable048.FOE_FRI = "Unknown target";
                if (foe_fri == "11") Variable048.FOE_FRI = "No reply";
            }
        }

        /// <summary>
        /// Get and assign RHO and THETA values from a binary string from DF040
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF040(string bytes2, CAT048 Variable048)
        {
            // Get the first two octets (16 bits)
            string rho = bytes2.Substring(0, 16);
            double rho2 = Convert.ToInt32(rho, 2) * 0.00390625;
            // Assign the converted and adjusted value to RHO
            Variable048.RHO = Convert.ToString(rho2);
            // Get the next two octets (16 bits)
            string theta = bytes2.Substring(16, 16);
            double theta2 = Convert.ToInt32(theta, 2) * 0.00549316406;
            // Assign the converted and adjusted value to THETA
            Variable048.THETA = Convert.ToString(theta2);  
        }

        /// <summary>
        /// Get and assign values of V, G, and Mode 3/A code from DF070
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF070(string bytes2, CAT048 Variable048)
        {
            // Get the first bit and assign the corresponding value to V_070
            string v = bytes2.Substring(0, 1);
            if (v == "0")
                Variable048.V_070 = "V";
            if (v == "1")
                Variable048.V_070 = "NV";

            // Get the second bit and assign the corresponding value to G_070
            string g = bytes2.Substring(1, 1);
            if (g == "0")
                Variable048.G_070 = "Default";
            if (g == "1")
                Variable048.G_070 = "Garbled code";

            // Get the bits for Mode 3/A code, convert to octal, and assign
            string mode_3A = bytes2.Substring(4, 12);
            int dec = Convert.ToInt32(mode_3A, 2);
            string octal = Convert.ToString(dec, 8);
            Variable048.MODE_3A = octal;
        }

        /// <summary>
        /// Get and assign values of V, G, and flight level from DF090
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF090(string bytes2, CAT048 Variable048)
        {
            // Get the first bit
            string V = bytes2.Substring(0, 1);
            // Get the second bit
            string G = bytes2.Substring(1, 1);
            // Get and convert the next 14 bits to calculate the flight level (FL)
            double FL = ComplementA2(bytes2.Substring(2, 14)) * 0.25;
            Variable048.FL = Convert.ToString((FL));

            // Assign the corresponding value for the V bit
            if (V == "0") { Variable048.V_090 = "Code validated"; }
            else { Variable048.V_090 = "Code not validated"; }

            // Assign the corresponding value for the G bit
            if (G == "0") { Variable048.G_090 = "Default"; }
            else { Variable048.G_090 = "Garbled code"; }
        }

        /// <summary>
        /// Get and and assigns various values from a binary string from DF130
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF130(string bytes2, CAT048 Variable048)
        {
            // Initializes booleans for each parameter to extract
            bool SRLbool = false;
            bool SRRbool = false;
            bool SAMbool = false;
            bool PRLbool = false;
            bool PAMbool = false;
            bool RPDbool = false;
            bool APDbool = false;

            // Gets the length of the input string
            int length130 = bytes2.Length;

            // Gets the first octet (8 bits)
            string oct1 = bytes2.Substring(0, 8);

            // Checks and sets booleans based on the bits of the first octet
            if (oct1.Substring(0, 1) == "1") { SRLbool = true; }
            if (oct1.Substring(1, 1) == "1") { SRRbool = true; }
            if (oct1.Substring(2, 1) == "1") { SAMbool = true; }
            if (oct1.Substring(3, 1) == "1") { PRLbool = true; }
            if (oct1.Substring(4, 1) == "1") { PAMbool = true; }
            if (oct1.Substring(5, 1) == "1") { RPDbool = true; }
            if (oct1.Substring(6, 1) == "1") { APDbool = true; }

            // If the last bit of the first octet is "0", proceeds to extract the next octets
            if (oct1.Substring(7, 1) == "0")
            {
                int cont130 = 0;
                while (cont130 < (length130 - 8))
                {
                    // Gets the next octet (8 bits)
                    string oct2 = bytes2.Substring(8 + cont130, 8); 
                    // Assigns the value of the octet to the corresponding field in Variable048
                    if (SRLbool)
                    {
                        // Degrees
                        Variable048.SRL = Convert.ToString(Convert.ToInt32(oct2, 2) * 0.044); 
                        SRLbool = false;
                    }
                    else if (SRRbool)
                    {
                        Variable048.SRR = Convert.ToString(Convert.ToInt32(oct2, 2));
                        SRRbool = false;
                    }
                    else if (SAMbool)
                    {

                        Variable048.SAM = Convert.ToString(ComplementA2(oct2));
                        SAMbool = false;
                    }
                    else if (PRLbool)
                    {
                        // Degrees
                        Variable048.PRL = Convert.ToString(Convert.ToInt32(oct2, 2) * 0.044); //dg
                        PRLbool = false;
                    }
                    else if (PAMbool)
                    {
                        // dB
                        Variable048.PAM = Convert.ToString(ComplementA2(oct2)); 
                        PAMbool = false;
                    }
                    else if (RPDbool)
                    {
                        int rpd = ComplementA2(oct2);
                        // NM
                        Variable048.RPD = Convert.ToString(rpd * (0.00390625)); 
                        RPDbool = false;
                    }
                    else if (APDbool)
                    {
                        int apd = ComplementA2(oct2);
                        // Degrees ADD CA2
                        Variable048.APD = Convert.ToString(apd * (0.02197265625)); 
                        APDbool = false;
                    }

                    // Increments the counter
                    cont130 += 8;
                }
            }



        }

        /// <summary>
        /// Get and converts three bytes from a binary string to hexadecimal
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF220(string bytes2, CAT048 Variable048)
        {
            // Gets three octets (24 bits)
            string byte1TA = bytes2.Substring(0, 8);
            string byte2TA = bytes2.Substring(8, 8);
            string byte3TA = bytes2.Substring(16, 8);

            // Converts each octet to byte
            byte byte1 = Convert.ToByte(byte1TA, 2);
            byte byte2 = Convert.ToByte(byte2TA, 2);
            byte byte3 = Convert.ToByte(byte3TA, 2);

            // Combines the bytes into a hexadecimal string
            string hexresult = byte1.ToString("X2") + byte2.ToString("X2") + byte3.ToString("X2");

            // Assigns the hexadecimal result to TA
            Variable048.TA = Convert.ToString(hexresult);
        }

        /// <summary>
        /// Converts 8 characters of 6 bits into letters and numbers
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF240(string bytes2, CAT048 Variable048)
        {
            // Gets 8 groups of 6 bits.
            string c1 = bytes2.Substring(0, 6);
            int character1 = Convert.ToInt32(c1, 2);
            string c2 = bytes2.Substring(6, 6);
            int character2 = Convert.ToInt32(c2, 2);
            string c3 = bytes2.Substring(12, 6);
            int character3 = Convert.ToInt32(c3, 2);
            string c4 = bytes2.Substring(18, 6);
            int character4 = Convert.ToInt32(c4, 2);
            string c5 = bytes2.Substring(24, 6);
            int character5 = Convert.ToInt32(c5, 2);
            string c6 = bytes2.Substring(30, 6);
            int character6 = Convert.ToInt32(c6, 2);
            string c7 = bytes2.Substring(36, 6);
            int character7 = Convert.ToInt32(c7, 2);
            string c8 = bytes2.Substring(42, 6);
            int character8 = Convert.ToInt32(c8, 2);

            // Creates an array to store the resulting characters.
            int[] charactersTI = { character1, character2, character3, character4, character5, character6, character7, character8 };
            char[] identification = new char[8];

            // Converts each group of 6 bits into a corresponding character (letter or number)
            for (int i = 0; i < 8; i++)
            {
                int value = charactersTI[i];
                //  A-Z
                if (value >= 1 && value <= 26) { identification[i] = (char)('A' + value - 1); }
                // s 0-9
                else if (value >= 48 && value <= 57) { identification[i] = (char)('0' + value - 48); }
                // Space for invalid values
                else { identification[i] = ' '; }
            }

            // Creates a string from the identified characters and assigns it to TI
            string ti = new string(identification);
            Variable048.TI = ti;

        }

        /// <summary>
        /// Decodes multiple BDS data from 250
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF250(string bytes2, CAT048 Variable048)
        {
            // Gets the first octet that indicates how many BDS records there are
            string rep = bytes2.Substring(0, 8);
            int REP = Convert.ToInt32(rep, 2);
            int index = 0;

            // Iterates through the BDS records according to the REP value
            for (int l = 0; l < REP; l++)
            {
                // Extracts BDS data and BDS1 and BDS2 values
                string bdsdata = bytes2.Substring(index + 8, 56);
                string bds1 = bytes2.Substring(index + 64, 4);
                int BDS1 = Convert.ToInt32(bds1, 2);
                string bds2 = bytes2.Substring(index + 68, 4);
                int BDS2= Convert.ToInt32(bds2, 2);
                // Moves the index forward by 64 bits
                index += 64;

                // Calls a method to decode the BDS data
                DecodeBDS(BDS1, BDS2, bdsdata, Variable048);
            }
        }

        /// <summary>
        /// Get and assign a number from DF161.
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF161(string bytes2, CAT048 Variable048)
        {
            // Extracts the 12 bits for the TNumber and converts it to an integer
            string tNumber = bytes2.Substring(4, 12);
            int tNumber2 = Convert.ToInt32(tNumber, 2);
            Variable048.TN = Convert.ToString(tNumber2);
        }
        
        /// <summary>
        /// Get and assign X and Y components from DF042.
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF042(string bytes2, CAT048 Variable048)
        {
            // Extracts and converts the 16 bits for the X component
            string x = bytes2.Substring(0, 16);
            Variable048.xComponent = Convert.ToString(ComplementA2(x) * 0.0078125);
            // Extracts and converts the 16 bits for the Y component
            string y = bytes2.Substring(16, 16);
            Variable048.yComponent = Convert.ToString(ComplementA2(y) * 0.0078125);
        }

        /// <summary>
        /// Get ground speed and heading from DF200
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF200(string bytes2, CAT048 Variable048)
        {
            // Extracts and converts the 16 bits for ground speed
            string GS = bytes2.Substring(0, 16);
            Variable048.GS_KT = Convert.ToString(((Convert.ToInt32(GS, 2)) * 0.22));
            // Extracts and converts the 16 bits for heading
            string Head = bytes2.Substring(16, 16);
            Variable048.HEADING = Convert.ToString((Convert.ToInt32(Head, 2) * (0.0055)));
        }

        /// <summary>
        /// Processes and get information from DF170
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF170(string bytes2, CAT048 Variable048)
        {
            // Variable to determine the end of processing and the loop will continue until endDF is set to true
            bool endDF = false;
            while (endDF == false)
            {
                // Extracts the first bit to determine track confirmation
                string cnf = bytes2.Substring(0, 1);
                if (cnf == "0") { Variable048.CNF = "Confirmed Track"; }
                else { Variable048.CNF = "Tentative Track"; }

                // Extracts the next 2 bits to determine the radar type
                string rad = bytes2.Substring(1, 2);
                if (rad == "00") { Variable048.RAD = "Combined Track"; }
                else if (rad == "01") { Variable048.RAD = "PSR Track"; }
                else if (rad == "10") { Variable048.RAD = "SSR / Mode S Track"; }
                else { Variable048.RAD = "Invalid"; }

                // Extracts the next bit to determine confidence
                string dou = bytes2.Substring(3, 1);
                if (dou == "0") { Variable048.DOU = "Normal confidence"; }
                else { Variable048.DOU = "Low confidence in plot to track association."; }

                // Extracts the next bit to determine horizontal detection
                string mah = bytes2.Substring(4, 1);
                if (mah == "0") { Variable048.MAH = "No horizontal man.sensed"; }
                else { Variable048.MAH = "Horizontal man. sensed"; }
                // Extracts the next 2 bits to determine maneuvering
                string cdm = bytes2.Substring(5, 2);
                if (cdm == "00")
                { Variable048.CDM = "Maintaining"; }
                else if (cdm == "01")
                { Variable048.CDM = "Climbing"; }
                else if (cdm == "10") { Variable048.CDM = "Descending";}
                else { Variable048.CDM = "Unknown"; }

                // Extracts the next bit to determine whether to continue processing
                string fx = bytes2.Substring(7, 1);
                if (Convert.ToInt32(fx, 2) == 0)
                {
                    // Ends the loop if fx is 0
                    endDF = true;
                }
            }
        }

        public void DF210(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF030(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF080(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF100(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        /// <summary>
        /// Decodes the 3D height from the DF110 
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF110(string bytes2, CAT048 Variable048)
        {
            // Extract 14 bits starting from index 2 of the DF110 data string.
            // This portion of the binary string represents the height in 3D.
            string height = bytes2.Substring(2, 14);
            // Convert the extracted binary string (height) into a signed integer using two's complement.
            // This is necessary to correctly handle potential negative values in the height data.
            Variable048.Height_3D = Convert.ToString(ComplementA2(height));
        }

        public void DF120(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        /// <summary>
        /// Decodes the DF230 binary string and extracts various communication and status information
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF230(string bytes2, CAT048 Variable048)
        {
            // Extract the first 3 bits representing communication capability
            // Decode the communication capability based on the extracted 3-bit value
            int com = Convert.ToInt16(bytes2.Substring(0, 3),2);
            if (com == 0) { Variable048.COM = "No communications capability (surveillance only)"; }
            else if (com == 1) { Variable048.COM = "Comm. A and Comm. B capability"; }
            else if (com == 2) { Variable048.COM = "Comm. A and Comm. B and Uplink ELM"; }
            else if (com == 3) { Variable048.COM = "Comm. A and Comm. B, Uplink ELM and Downlink ELM"; }
            else if (com == 4) { Variable048.COM = "Level 5 Transponder capability"; }
            else { Variable048.COM = "Not assigned"; }

            // Extract the next 3 bits representing the status (STAT) of the aircraft
            // Decode the status (STAT) based on the extracted 3-bit value
            int stat = Convert.ToInt16(bytes2.Substring(3, 3), 2);
            if (stat == 0){ Variable048.STAT = "No alert, no SPI, aircraft airborne"; }
            else if (stat == 1) { Variable048.STAT = "No alert, no SPI, aircraft on ground"; }
            else if (stat == 2) { Variable048.STAT = "Alert, no SPI, aircraft airborne"; }
            else if (stat == 3) { Variable048.STAT = "Alert, no SPI, aircraft on ground"; }
            else if (stat == 4) { Variable048.STAT = "Alert, SPI, aircraft airborne or on ground"; }
            else if (stat == 5) { Variable048.STAT = "No alert, SPI, aircraft airborne or on ground"; }
            else if (stat == 6) { Variable048.STAT = "Not assigned"; }
            else if (stat == 7) { Variable048.STAT = "Unknown"; }

            // Extract the next bit representing SI-Code capability
            // Decode the SI-Code capability based on the extracted bit value
            int si = Convert.ToInt16(bytes2.Substring(6, 1), 2);
            if (si == 0) { Variable048.SI = "SI-Code Capable"; }
            else if (si == 1) { Variable048.SI = "II-Code Capable"; }

            // Extract the next bit representing Mode S Subnetwork Capability (MSSC)
            // Decode the MSSC capability based on the extracted bit value
            int mssc = Convert.ToInt16(bytes2.Substring(8, 1), 2);
            if (mssc == 0) { Variable048.MSSC = "No"; }
            else if (mssc == 1) { Variable048.MSSC = "Yes"; }

            // Extract the next bit representing Altitude Reporting Capability (ARC)
            // Decode the ARC based on the extracted bit value
            int arc = Convert.ToInt16(bytes2.Substring(8, 1), 2);
            if (arc == 0) { Variable048.ARC = "100 ft resolution"; }
            else if (arc == 1) { Variable048.ARC = "25 ft resolution"; }

            // Extract the next bit representing Aircraft Identification Capability (AIC)
            // Decode the AIC capability based on the extracted bit value
            int aic = Convert.ToInt16(bytes2.Substring(9, 1), 2);
            if (aic == 0) { Variable048.AIC = "No"; }
            else if (aic == 1) { Variable048.AIC = "Yes"; }

            // Extract the BDS 1,0 bit 16 value and store it
            string b1a = bytes2.Substring(10, 1);
            Variable048.B1A = "BDS 1,0 bit 16 = " + b1a;
            // Extract the BDS 1,0 bits 37/40 value and store it
            string b1b = bytes2.Substring(11, 4);
            Variable048.B1B = "BDS 1,0 bits 37/40 = " + b1b;
        }

        public void DF260(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF055(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF050(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF065(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        public void DF060(string bytes2, CAT048 Variable048) 
        {
            //NOT NECESSARY
        }

        /// <summary>
        /// Processes SP (Signal Processing) data from DFSP
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DFSP(string bytes2, CAT048 Variable048)
        {
            // Current octet index
            int octetIndex = 0;
            // Controls the processing loop
            bool moreData = true;

            while (moreData)
            {
                // Extract 8 bits (1 octet)
                string spData = bytes2.Substring(octetIndex * 8, 8);  
                octetIndex++;

                // Process the specific bits of this octet according to what you need for the SP Data Item

                // If the FX bit is 1, continue
                moreData = (Convert.ToInt32(spData.Substring(7, 1), 2) == 1);  
            }
        }

        /// <summary>
        /// Processes RE (Request Element) data from DFRE
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DFRE(string bytes2, CAT048 Variable048)
        {
            // Current octet index
            int octetIndex = 0;
            // Controls the processing loop
            bool moreData = true;

            while (moreData)
            {
                // Extract 8 bits (1 octet)
                string reData = bytes2.Substring(octetIndex * 8, 8); 
                octetIndex++;

                // Process the specific bits of this octet according to what you need for the RE Data Item

                // If the FX bit is 1, continue
                moreData = (Convert.ToInt32(reData.Substring(7, 1), 2) == 1);  
            }
        }


        /// <summary>
        /// Replaces null values in the object's properties with "N/A"
        /// </summary>
        public void ReemplazarNulosConNA()
        {
            // Get the type of the current object
            Type tipoObjeto = this.GetType();

            // Get all properties of the object's type
            foreach (var propiedad in tipoObjeto.GetProperties())
            {
                // Check if the property can be read and written
                if (propiedad.CanRead && propiedad.CanWrite)
                {
                    // Get the current value of the property
                    var valorPropiedad = propiedad.GetValue(this);

                    // If the value is null, set it to "N/A"
                    if (valorPropiedad == null) { propiedad.SetValue(this, "N/A"); }
                }
            }
        }

        /// <summary>
        /// Calculates the two's complement of a binary string
        /// </summary>
        /// <param name="bytesCA2"></param>
        /// <returns></returns>
        public int ComplementA2(string bytesCA2)
        {
            int result;
            // First bit to determine if positive or negative
            char firstbit = bytesCA2[0];
            if (firstbit == '0') { result = Convert.ToInt32(bytesCA2, 2); }
            else
            {
                // Invert bits
                char[] invertedBits = new char[bytesCA2.Length];
                for (int i = 0; i < bytesCA2.Length; i++)
                {
                    // Change 0 for 1
                    invertedBits[i] = bytesCA2[i] == '0' ? '1' : '0';  
                }

                // Integer number and add 1
                int invertedNumber = Convert.ToInt32(new string(invertedBits), 2);
                int complementA2Number = invertedNumber + 1;

                // Return the negative of the complement
                result = -complementA2Number;
            }

            return result;


        }


        /// <summary>
        /// Decodes BDS (Basic Data Source) information based on input parameters
        /// </summary>
        /// <param name="bds1"></param>
        /// <param name="bds2"></param>
        /// <param name="bdsdata"></param>
        /// <param name="Variable048"></param>
        public void DecodeBDS(int bds1, int bds2, string bdsdata, CAT048 Variable048)
        {
            // Check if BDS type is 4 and subtype is 0 (indicating a specific data structure)
            if (bds1 == 4 & bds2 == 0)
            {
                // Decode MCP (Minimum Control Pressure) altitude from the BDS data
                // Extract 12 bits (MCP ALT) starting from index 1
                string mcpalt_bits = bdsdata.Substring(1, 12);
                // Convert binary to integer
                int mcp_alt = Convert.ToInt32(mcpalt_bits, 2);
                // Scale adjustment for MCP altitude
                mcp_alt = mcp_alt * 16;
                // Store the result in the CAT048 object
                Variable048.MCP_ALT = Convert.ToString(mcp_alt);

                // Decode FMS (Flight Management System) altitude
                // Extract another 12 bits (FMS ALT) starting from index 14
                string fmsalt_bits = bdsdata.Substring(14, 12); 
                int fms_alt = Convert.ToInt32(fmsalt_bits, 2);
                // Scale adjustment for FMS altitude
                fms_alt = fms_alt * 16;
                // Store the result
                Variable048.FMS_ALT = Convert.ToString(fms_alt);

                // Decode barometric altitude
                // Extract 12 bits starting from index 27
                string baro = bdsdata.Substring(27, 12);
                // Convert binary to integer
                double baro_alt = Convert.ToInt32(baro, 2);
                // Adjust based on pressure
                baro_alt = (baro_alt * 0.1 + 800);
                // Store barometric altitude
                Variable048.BP = Convert.ToString(baro_alt);
                // Vertical Navigation flag
                Variable048.VNAV = Convert.ToString(bdsdata[48]);
                // Altitude Hold flag
                Variable048.ALT_HOLD = Convert.ToString(bdsdata[49]);
                // Approach flag
                Variable048.APP = Convert.ToString(bdsdata[50]);
                // Target Alt Source 
                string TARalt = bdsdata.Substring(54, 2);
                Variable048.TARGET_ALT_SOURCE = Convert.ToString(Convert.ToInt32(TARalt, 2));

            }

            // Check if BDS type is 5 and subtype is 0
            if (bds1 == 5 & bds2 == 0)
            {
                // Decode RA (Rate of Climb or Descent)
                // Extract 9 bits starting from index 2
                string ra_bits = bdsdata.Substring(2, 9);
                // Use two's complement to decode
                double ra = ComplementA2(ra_bits);
                // Scale adjustment
                ra = (ra * 45) / 256;
                // Store Rate of Climb/Descent
                Variable048.RA = Convert.ToString(ra);

                // Decode TTA 
                string tta_bits;
                double tta;
                // Status flag for TTA
                char statusTTA = bdsdata[12];
                if (statusTTA == '1')
                {
                    // Extract TTA bits
                    tta_bits = bdsdata.Substring(12, 11);
                    // Decode using two's complement
                    tta = ComplementA2(tta_bits);
                }
                else
                {
                    // Extract alternative TTA bits
                    tta_bits = bdsdata.Substring(13, 10);
                    // Convert directly to integer
                    tta = Convert.ToInt32(tta_bits, 2);
                }
                // Scales adjustments
                tta = (tta * 90);
                tta = tta / 512;
                //Store TTA
                Variable048.TTA = Convert.ToString(tta);

                // Decode GS (Ground Speed)
                string gs_bits = bdsdata.Substring(24, 10);
                // Decode using two's complement
                double gs = ComplementA2(gs_bits);
                // Scale adjustment
                gs = (gs * 1024) / 512;
                //Store GS
                Variable048.GS = Convert.ToString(gs);

                // Decode TAR (True Airspeed Reference)
                string tar_bits = bdsdata.Substring(36, 9);
                // Decode using two's complement
                double tar = ComplementA2(tar_bits);
                // Scales adjustments
                tar = tar / 8;
                tar= tar / 256;
                //Store TAR
                Variable048.TAR = Convert.ToString(tar);

                // Decode TAS (True Airspeed)
                string tas_bits = bdsdata.Substring(46, 10);
                // Decode using two's complement
                double tas = ComplementA2(tas_bits);
                // Scale adjustment
                tas = tas * 2;
                //Store TAS
                Variable048.TAS = Convert.ToString(tas);
            }
            // Check if BDS type is 6 and subtype is 0
            if (bds1 == 6 & bds2 == 0)
            {
                // Decode HDG 
                string hdg_bits;
                double hdg;
                // Status flag 
                char statusHDG = bdsdata[1];
                if (statusHDG == '1')
                {
                    // Extract HDG bits
                    hdg_bits = bdsdata.Substring(1, 11);
                    // Decode using two's complement
                    hdg = ComplementA2(hdg_bits);
                }
                else
                {
                    // Extract alternative HDG bits
                    hdg_bits = bdsdata.Substring(2, 10);
                    // Convert directly to integer
                    hdg = Convert.ToInt32(hdg_bits, 2);
                }

                // Scale adjustment
                hdg = (hdg * 90) / 512;
                //Store HDG
                Variable048.HDG = Convert.ToString(hdg);

                // Decode IAS (Indicated Airspeed)
                string IAS_bits = bdsdata.Substring (13, 10);
                // Decode using two's complement
                double ias = ComplementA2(IAS_bits);
                //Store IAS
                Variable048.IAS = Convert.ToString(ias);

                // Decode MACH (Mach Number)
                string mach_bits = bdsdata.Substring(24, 10);
                // Decode using two's complement
                double mach = ComplementA2(mach_bits);
                // Scale adjustment
                mach = (mach * 2.048) / 512;
                //Store MACH
                Variable048.MACH = Convert.ToString(mach);

                // Decode BAR (Barometric Value)
                string bar_bits = bdsdata.Substring(36, 9);
                // Decode using two's complement
                double bar = ComplementA2(bar_bits);
                // Scale adjustment
                bar = bar * 32;
                //Store BAR
                Variable048.BAR = Convert.ToString(bar);

                // Decode IVV (Inertial Vertical Velocity)
                string ivv_bits = bdsdata.Substring(47, 9);
                // Decode using two's complement
                double ivv = ComplementA2(ivv_bits);
                // Scale adjustment
                ivv = (ivv * 32);
                //Store IVV
                Variable048.IVV = Convert.ToString(ivv);
            }
        }

        /// <summary>
        /// Function to convert coordinates to decimal degrees
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="cardinalpoints"></param>
        /// <returns></returns>
        public double Get_Minutes_To_Degrees(double degrees, double minutes, double seconds, string cardinalpoints)
        {
            // Assigns a numerical value to cardinal points: "N" or "E" as 1, "S" or "W" as -1
            if (cardinalpoints == "N" || cardinalpoints == "E") { cardinalpoints = "1"; }
            if (cardinalpoints == "S" || cardinalpoints == "W") { cardinalpoints = "-1"; }

            // Returns the value in degrees
            double convert = (degrees + (minutes / 60) + (seconds / 3600)) * Convert.ToInt32(cardinalpoints);
            return convert;
        }
        /// <summary>
        ///  Gets the corrected altitude based on barometric pressure and flight level
        /// </summary>
        /// <param name="Variable048"></param>
        public void H (CAT048 Variable048)
        {
            // Barometric pressure from variable 048
            double barometricPressure = Convert.ToDouble(Variable048.BP);
            // Initialize corrected altitude to 0
            double Altitude = 0;
            // Flight level from variable 048
            double flightLevel = Convert.ToDouble(Variable048.FL);

            if (flightLevel != 0)
            {
                // Convert to feet
                double altitude = Convert.ToDouble(flightLevel) * 100;
                // Convert to meters
                Altitude = altitude * 0.3048;
                // Variable to indicate if the pressure is in a specific range
                bool PRES = false;

                // Check if the barometric pressure is within the range of 1013 to 1013.3 hPa or is zero
                if ((barometricPressure >= 1013 && barometricPressure <= 1013.3) || (barometricPressure == 0)) { PRES = true; }
                // QNH correction if the altitude is less than 6000 feet
                if (PRES == false && altitude < 6000 && barometricPressure != 0 && altitude>0)
                {
                    double modeC = Math.Round(altitude + (Convert.ToDouble(barometricPressure) - 1013.2) * 30);
                    Variable048.ModeC_corrected = Convert.ToString(modeC);
                }
                if (altitude <= 0)
                    Altitude = 0;
            }
            // Call LatitudeLongitud function with Variable048 and the corrected altitude
            LatitudeLongitud(Variable048, Altitude);
        }

        /// <summary>
        /// Get the variable LAT and LON
        /// </summary>
        /// <param name="data048"></param>
        /// <param name="correctedAltitude"></param>
        public void LatitudeLongitud(CAT048 data048, double Altitude)
        {
            // Radar variables
            double latRadar = Get_Minutes_To_Degrees(41.0, 18.0, 2.5284, "N");
            string radar_Latitude = latRadar.ToString();
            
            double lonRadar = Get_Minutes_To_Degrees(2.0, 6.0, 7.4095, "E");
            string radar_Longitude = lonRadar.ToString();

            double terrainElevation = 2.007;
            double antennaHeight = 25.25;
            double earthRadius = 6371000.0;

            GeoUtils GeoUs = new GeoUtils();

            // Save the radar coordinates (in WGS84)
            CoordinatesWGS84 radarPosition = new CoordinatesWGS84 (radar_Latitude, radar_Longitude, terrainElevation + antennaHeight);

            // From polar coordinates to cartesian coordinates
            double cordenateRadarX = Convert.ToDouble(data048.RHO) * Math.Sin(Convert.ToDouble(data048.THETA) * Math.PI / 180.0) * 1852.0; // From NM to m (* 1852)
            double cordenateRadarY = Convert.ToDouble(data048.RHO) * Math.Cos(Convert.ToDouble(data048.THETA) * Math.PI / 180.0) * 1852.0;

            // From cartesian coordinates to spherical coordinates
            double azimuth = GeoUtils.CalculateAzimuth(cordenateRadarX, cordenateRadarY);
            double range = Math.Sqrt(cordenateRadarX * cordenateRadarX + cordenateRadarY * cordenateRadarY);
            double elevation = Math.Asin((2 * earthRadius * (Altitude - (antennaHeight + terrainElevation)) + Altitude * Altitude - (antennaHeight + terrainElevation) * (antennaHeight + terrainElevation)  - range * range) / (2 * range * (earthRadius + antennaHeight + terrainElevation)));

            // Transform to polar coordinates
            CoordinatesPolar polarCoords = new CoordinatesPolar(range, azimuth, elevation);

            // Transform to Cartesian coordinates
            CoordinatesXYZ cartCoords = GeoUtils.change_radar_spherical2radar_cartesian(polarCoords);

            // Transform to geocentric coordinates
            CoordinatesXYZ geocCoords = GeoUs.change_radar_cartesian2geocentric(radarPosition, cartCoords);

            // Transform to geodesic coordinates
            CoordinatesWGS84 geodCoords = GeoUs.change_geocentric2geodesic(geocCoords);

            data048.LAT = Convert.ToString(geodCoords.Lat * 180 / Math.PI);
            data048.LON = Convert.ToString(geodCoords.Lon * 180 / Math.PI);
            data048.H = Convert.ToString(geodCoords.Height);
        }


    }
}

