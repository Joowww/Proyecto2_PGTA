using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;
using MultiCAT6.Utils;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Accord.Math;

namespace AstDecoder
{
    public class CAT048
    {
        public List<Byte> DataBlock;
        public int DataLength;
        public int Message_length;

        // Variables for Data Item (010) [2 Oct]
        public int SAC { get; set; }
        public int SIC { get; set; }

        // Variables for Data Item (140) [3 Oct]
        public string UTC_TIME { get; set; }
        public int UTC_TIME_s { get; set; }

        // Variables for LAT, LON and H
        public double LAT { get; set; }
        public double LON { get; set; }
        public double H { get; set; }

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
        public string ADSB { get; set; }
        public string SCN { get; set; }
        public string PAI { get; set; }

        // Variables for Data Item (040) [4 Oct]
        public double RHO { get; set; }
        public double THETA { get; set; }

        // Variables for Data Item (070) [2 Oct] 
        public string V_070 { get; set; }
        public string G_070 { get; set; }
        public string MODE_3A { get; set; }

        // Variables for Data Item (090) [2 Oct] 
        public string V_090 { get; set; }
        public string G_090 { get; set; }
        public double FL { get; set; }

        // Mode C corrected
        public double ModeC_corrected { get; set; }

        // Variables for Data Item (130) [1+ 1+ Oct]
        public double SRL { get; set; }
        public double SRR { get; set; }
        public double SAM { get; set; }
        public double PRL { get; set; }
        public double PAM { get; set; }
        public double RPD { get; set; }
        public double APD { get; set; }
       
        // Variables for Data Item (220) [3 Oct]
        public string TA { get; set; }

        // Variables for Data Item (240) [6 Oct]
        public string TI { get; set; }

        // Variables for Data Item (250) [1+8*n Oct]
        public double MCP_ALT { get; set; }
        public double FMS_ALT {get; set; }
        public double BP {  get; set; }
        public char VNAV { get; set; }
        public char ALT_HOLD { get; set; }
        public char APP {  get; set; }
        public double TARGETR_ALT { get; set; }
        public double RA { get; set; }
        public double TTA { get; set; }
        public double GS { get; set; }
        public double TAR { get; set; }
        public double TAS { get; set; }
        public double HDG { get; set; }
        public double IAS { get; set; }
        public double MACH { get; set; }
        public double BAR { get; set; }
        public double IVV { get; set; }


        // Variables for Data Item (161) [2 Oct]
        public int TN { get; set; }

        // Variables for Data Item (042) [4 Oct]
        public double xComponent { get; set; }
        public double yComponent { get; set; }

        // Variables for Data Item (200) [4 Oct]
        public double calculatedGroundSpeed { get; set; }
        public double calculatedHeading { get; set; }

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
        public int Height_3D { get; set; }

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
            // Assign the converted value to SAC
            Variable048.SAC = Convert.ToInt32(sac, 2);
            // Get the next octet (8 bits)
            string sic = bytes2.Substring(8, 8);
            // Assign the converted value to SIC
            Variable048.SIC = Convert.ToInt32(sic, 2);  
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
            Variable048.UTC_TIME_s = (int)Math.Round(time);
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

                // Extracts the FX2 bit to decide whether to process the third octet
                string FX2 = oct2.Substring(7, 1);

                if (FX2 == "1")
                {
                    // Extracts the third octet (8 bits) and evaluates its bits
                    string oct3 = bytes2.Substring(16, 8);

                    // Extracts the ADSB bits and assigns the corresponding value to ADSB
                    string adsb = oct3.Substring(0, 2);
                    if ((adsb == "00") || (adsb == "10")) Variable048.ADSB = "N/A";
                    if (adsb == "01") Variable048.ADSB = "ADSB not populated";
                    if (adsb == "11") Variable048.ADSB = "ADSB populated";

                    // Extracts the SCN bits and assigns the corresponding value to SCN
                    string scn = oct3.Substring(2, 2);
                    if ((scn == "00") || (scn == "10")) Variable048.SCN = "N/A";
                    if (scn == "01") Variable048.SCN = "SCN not populated";
                    if (scn == "11") Variable048.SCN = "SCN populated";

                    // Extracts the PAI bits and assigns the corresponding value to PAI
                    string pai = oct3.Substring(4, 2);
                    if ((pai == "00") || (pai == "10")) Variable048.PAI = "N/A";
                    if (pai == "01") Variable048.PAI = "PAI not populated";
                    if (pai == "11") Variable048.PAI = "PAI populated";
                }
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
            // Assign the converted and adjusted value to RHO
            Variable048.RHO = Convert.ToInt32(rho, 2) * 0.00390625;
            // Get the next two octets (16 bits)
            string theta = bytes2.Substring(16, 16);
            // Assign the converted and adjusted value to THETA
            Variable048.THETA = Convert.ToInt32(theta, 2) * 0.00549316406;  
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
            Variable048.FL = (FL);

            // Assign the corresponding value for the V bit
            if (V == "0")
            {
                Variable048.V_090 = "Code validated";
            }
            else
            {
                Variable048.V_090 = "Code not validated";
            }

            // Assign the corresponding value for the G bit
            if (G == "0")
            {
                Variable048.G_090 = "Default";
            }
            else
            {
                Variable048.G_090 = "Garbled code";
            }

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
                        Variable048.SRL = Convert.ToInt32(oct2, 2) * 0.044; 
                        SRLbool = false;
                    }
                    else if (SRRbool)
                    {
                        Variable048.SRR = Convert.ToInt32(oct2, 2);
                        SRRbool = false;
                    }
                    else if (SAMbool)
                    {

                        Variable048.SAM = ComplementA2(oct2);
                        SAMbool = false;
                    }
                    else if (PRLbool)
                    {
                        // Degrees
                        Variable048.PRL = Convert.ToInt32(oct2, 2) * 0.044; //dg
                        PRLbool = false;
                    }
                    else if (PAMbool)
                    {
                        // dB
                        Variable048.PAM = ComplementA2(oct2); 
                        PAMbool = false;
                    }
                    else if (RPDbool)
                    {
                        int rpd = ComplementA2(oct2);
                        // NM
                        Variable048.RPD = rpd * (0.00390625); 
                        RPDbool = false;
                    }
                    else if (APDbool)
                    {
                        int apd = ComplementA2(oct2);
                        // Degrees ADD CA2
                        Variable048.APD = apd * (0.02197265625); 
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
            Variable048.TA = hexresult;
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
                if (value >= 1 && value <= 26)
                {
                    //  A-Z
                    identification[i] = (char)('A' + value - 1); 
                }
                else if (value >= 48 && value <= 57)
                {
                    // s 0-9
                    identification[i] = (char)('0' + value - 48); 
                }
                else
                {
                    // Space for invalid values
                    identification[i] = ' ';
                }
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
            Variable048.TN = Convert.ToInt32(tNumber, 2);
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
            Variable048.xComponent = ComplementA2(x) * 0.0078125;
            // Extracts and converts the 16 bits for the Y component
            string y = bytes2.Substring(16, 16);
            Variable048.yComponent = ComplementA2(y) * 0.0078125;
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
            Variable048.calculatedGroundSpeed = ((Convert.ToInt32(GS, 2)) * 0.22);
            // Extracts and converts the 16 bits for heading
            string Head = bytes2.Substring(16, 16);
            Variable048.calculatedHeading = (Convert.ToInt32(Head, 2) * (0.0055));
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
        }

        public void DF030(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF080(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF100(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF110(string bytes2, CAT048 Variable048)
        {
            string height = bytes2.Substring(2, 14);
            Variable048.Height_3D = ComplementA2(height);
        }

        public void DF120(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes2"></param>
        /// <param name="Variable048"></param>
        public void DF230(string bytes2, CAT048 Variable048)
        {
            int com = Convert.ToInt16(bytes2.Substring(0, 3),2);
            if (com == 0)
            {
                Variable048.COM = "No communications capability (surveillance only)";
            }
            else if (com == 1)
            {
                Variable048.COM = "Comm. A and Comm. B capability";
            }
            else if (com == 2)
            {
                Variable048.COM = "Comm. A and Comm. B and Uplink ELM";
            }
            else if (com == 3)
            {
                Variable048.COM = "Comm. A and Comm. B, Uplink ELM and Downlink ELM";
            }
            else if (com == 4)
            {
                Variable048.COM = "Level 5 Transponder capability";
            }
            else
            {
                Variable048.COM = "Not assigned";
            }

            int stat = Convert.ToInt16(bytes2.Substring(3, 3), 2);
            if (stat == 0)
            {
                Variable048.STAT = "No alert, no SPI, aircraft airborne";
            }
            else if (stat == 1)
            {
                Variable048.STAT = "No alert, no SPI, aircraft on ground";
            }
            else if (stat == 2)
            {
                Variable048.STAT = "Alert, no SPI, aircraft airborne";
            }
            else if (stat == 3)
            {
                Variable048.STAT = "Alert, no SPI, aircraft on ground";
            }
            else if (stat == 4)
            {
                Variable048.STAT = "Alert, SPI, aircraft airborne or on ground";
            }
            else if (stat == 5)
            {
                Variable048.STAT = "No alert, SPI, aircraft airborne or on ground";
            }
            else if (stat == 6)
            {
                Variable048.STAT = "Not assigned";
            }
            else if (stat == 7)
            {
                Variable048.STAT = "Unknown";
            }

            int si = Convert.ToInt16(bytes2.Substring(6, 1), 2);
            if (si == 0)
            {
                Variable048.SI = "SI-Code Capable";
            }
            else if (si == 1)
            {
                Variable048.SI = "II-Code Capable";
            }

            int mssc = Convert.ToInt16(bytes2.Substring(8, 1), 2);
            if (mssc == 0)
            {
                Variable048.MSSC = "No";
            }
            else if (mssc == 1)
            {
                Variable048.MSSC = "Yes";
            }

            int arc = Convert.ToInt16(bytes2.Substring(8, 1), 2);
            if (arc == 0)
            {
                Variable048.ARC = "100 ft resolution";
            }
            else if (arc == 1)
            {
                Variable048.ARC = "25 ft resolution";
            }

            int aic = Convert.ToInt16(bytes2.Substring(9, 1), 2);
            if (aic == 0)
            {
                Variable048.AIC = "No";
            }
            else if (aic == 1)
            {
                Variable048.AIC = "Yes";
            }

            string b1a = bytes2.Substring(10, 1);
            Variable048.B1A = "BDS 1,0 bit 16 = " + b1a;
            string b1b = bytes2.Substring(11, 4);
            Variable048.B1B = "BDS 1,0 bits 37/40 = " + b1b;
        }

        public void DF260(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF055(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF050(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF065(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF060(string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DFSP(string bytes2, CAT048 Variable048)
        {
            int octetIndex = 0;
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

        public void DFRE(string bytes2, CAT048 Variable048)
        {
            int octetIndex = 0;
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


        public void ReemplazarNulosConNA()
        {
            // Obtiene el tipo del objeto actual
            Type tipoObjeto = this.GetType();

            // Obtiene todas las propiedades del tipo del objeto
            foreach (var propiedad in tipoObjeto.GetProperties())
            {
                // Verifica si la propiedad puede leerse y escribirse
                if (propiedad.CanRead && propiedad.CanWrite)
                {
                    // Obtiene el valor actual de la propiedad
                    var valorPropiedad = propiedad.GetValue(this);

                    // Si el valor es nulo, establece "N/A"
                    if (valorPropiedad == null)
                    {
                        propiedad.SetValue(this, "N/A");
                    }
                }
            }
        }

        public int ComplementA2(string bytesCA2)
        {
            int result;
            char firstbit = bytesCA2[0];
            if (firstbit == '0')
            {
                result = Convert.ToInt32(bytesCA2, 2);

            }
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

                result = -complementA2Number;
            }

            return result;


        }


        public void DecodeBDS(int bds1, int bds2, string bdsdata, CAT048 Variable048)
        {
            if (bds1 == 4 & bds2 == 0)
            {
                // 12 bits MCP ALT
                string mcpalt_bits = bdsdata.Substring(1, 12); 
                int mcp_alt = Convert.ToInt32(mcpalt_bits, 2);
                mcp_alt = mcp_alt * 16;
                Variable048.MCP_ALT = mcp_alt;

                //bits FMS ALT
                string fmsalt_bits = bdsdata.Substring(14, 12); 
                int fms_alt = Convert.ToInt32(fmsalt_bits, 2);
                fms_alt = fms_alt * 16;
                Variable048.FMS_ALT = fms_alt;

                string baro = bdsdata.Substring(27, 12);
                double baro_alt = Convert.ToInt32(baro, 2);
                baro_alt = (baro_alt * 0.1 + 800);
                Variable048.BP = baro_alt;
                Variable048.VNAV = (bdsdata[48]);
                Variable048.ALT_HOLD = (bdsdata[49]);
                Variable048.APP = (bdsdata[50]);

            }

            if (bds1 == 5 & bds2 == 0)
            {
                string ra_bits = bdsdata.Substring(2, 9);
                double ra = ComplementA2(ra_bits);
                ra = (ra * 45) / 256;
                Variable048.RA = ra;

                string tta_bits;
                double tta;
                char statusTTA = bdsdata[12];
                if (statusTTA == '1')
                {
                    tta_bits = bdsdata.Substring(12, 11);
                    tta = ComplementA2(tta_bits);
                }
                else
                {
                    tta_bits = bdsdata.Substring(13, 10);
                    tta = Convert.ToInt32(tta_bits, 2);
                }
                tta = (tta * 90);
                tta = tta / 512;
                Variable048.TTA = tta;

                string gs_bits = bdsdata.Substring(24, 10);
                double gs = ComplementA2(gs_bits);
                gs = (gs * 1024) / 512;
                Variable048.GS = gs;

                string tar_bits = bdsdata.Substring(36, 9);
                double tar = ComplementA2(tar_bits);
                tar = tar / 8;
                tar= tar / 256;
                Variable048.TAR = tar;

                string tas_bits = bdsdata.Substring(46, 10);
                double tas = ComplementA2(tas_bits);
                tas = tas * 2;
                Variable048.TAS = tas;
            }

            if (bds1 == 6 & bds2 == 0)
            {
                string hdg_bits;
                double hdg;
                char statusHDG = bdsdata[1];
                if (statusHDG == '1')
                {
                    hdg_bits = bdsdata.Substring(1, 11);
                    hdg = ComplementA2(hdg_bits);
                }
                else
                {
                    hdg_bits = bdsdata.Substring(2, 10);
                    hdg = Convert.ToInt32(hdg_bits, 2);
                }
               
                hdg = (hdg * 90) / 512;
                Variable048.HDG = hdg;

                string IAS_bits = bdsdata.Substring (13, 10);
                double ias = ComplementA2(IAS_bits);
                Variable048.IAS = ias;

                string mach_bits = bdsdata.Substring(24, 10);
                double mach = ComplementA2(mach_bits);
                mach = (mach * 2.048) / 512;
                Variable048.MACH = mach;

                string bar_bits = bdsdata.Substring(36, 9);
                double bar = ComplementA2(bar_bits);
                bar = bar * 32;
                Variable048.BAR = bar;

                string ivv_bits = bdsdata.Substring(47, 9);
                double ivv = ComplementA2(ivv_bits);
                ivv = (ivv * 32);
                Variable048.IVV = ivv;
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
            if (cardinalpoints == "N" || cardinalpoints == "E")
                cardinalpoints = "1";
            if (cardinalpoints == "S" || cardinalpoints == "W")
                cardinalpoints = "-1";

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
            double barometricPressure = Variable048.BP;
            // Initialize corrected altitude to 0
            double correctedAltitude = 0;
            // Flight level from variable 048
            double flightLevel = Variable048.FL;

            if (flightLevel != 0)
            {
                // Convert to feet
                double altitude = Convert.ToDouble(flightLevel) * 100;
                // Convert to meters
                correctedAltitude = altitude * 0.3048;
                // Variable to indicate if the pressure is in a specific range
                bool PRES = false;

                // Check if the barometric pressure is within the range of 1013 to 1013.3 hPa or is zero
                if ((barometricPressure >= 1013 && barometricPressure <= 1013.3) || (barometricPressure == 0))
                {
                    // Indicates that the pressure is valid
                    PRES = true;
                }
                // QNH correction if the altitude is less than 6000 feet
                if (PRES == false && altitude < 6000 && barometricPressure != 0)
                {

                    double modeC = Math.Round(altitude + (Convert.ToDouble(barometricPressure) - 1013.2) * 30);
                    Variable048.ModeC_corrected = modeC;
                    correctedAltitude = modeC * 0.3048;
                }
            }
            // Call LatitudeLongitud function with Variable048 and the corrected altitude
            LatitudeLongitud(Variable048, correctedAltitude);
        }

        /// <summary>
        /// Get the variable LAT and LON
        /// </summary>
        /// <param name="data048"></param>
        /// <param name="correctedAltitude"></param>
        public void LatitudeLongitud(CAT048 data048, double correctedAltitude)
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
            CoordinatesWGS84 radarPosition = new CoordinatesWGS84 (radar_Latitude, radar_Longitude, terrainElevation);

            // From polar coordinates to cartesian coordinates
            double cordenateRadarX = Convert.ToDouble(data048.RHO) * Math.Sin(Convert.ToDouble(data048.THETA) * Math.PI / 180.0) * 1852.0; // From NM to m (* 1852)
            double cordenateRadarY = Convert.ToDouble(data048.RHO) * Math.Cos(Convert.ToDouble(data048.THETA) * Math.PI / 180.0) * 1852.0;

            // From cartesian coordinates to spherical coordinates
            double azimuth = GeoUtils.CalculateAzimuth(cordenateRadarX, cordenateRadarY);
            double range = Math.Sqrt(cordenateRadarX * cordenateRadarX + cordenateRadarY * cordenateRadarY);
            double elevation = Math.Asin((2 * earthRadius * (correctedAltitude - antennaHeight) + correctedAltitude * correctedAltitude - antennaHeight * antennaHeight - range * range) / (2 * range * (earthRadius + antennaHeight)));

            // Transform to polar coordinates
            CoordinatesPolar polarCoords = new CoordinatesPolar(range, azimuth, elevation);

            // Transform to Cartesian coordinates
            CoordinatesXYZ cartCoords = GeoUtils.change_radar_spherical2radar_cartesian(polarCoords);

            // Transform to geocentric coordinates
            CoordinatesXYZ geocCoords = GeoUs.change_radar_cartesian2geocentric(radarPosition, cartCoords);

            // Transform to geodesic coordinates
            CoordinatesWGS84 geodCoords = GeoUs.change_geocentric2geodesic(geocCoords);

            data048.LAT = geodCoords.Lat * 180 / Math.PI;
            data048.LON = geodCoords.Lon * 180 / Math.PI;
            if (data048.ModeC_corrected != 0)
                data048.H = geodCoords.Height - (data048.ModeC_corrected * 0.3048) + antennaHeight - terrainElevation;
            else
                data048.H = geodCoords.Height + antennaHeight - terrainElevation;
        }
    }
}

