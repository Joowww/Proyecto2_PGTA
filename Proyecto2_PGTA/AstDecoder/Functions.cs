using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;

namespace AstDecoder
{
    public class CAT048
    {
        //Cambiar formato para no tener copia

        //public UsefulFunctions useful_functions; ????
        public List<Byte> DataBlock;
        public int DataLength;
        public int Message_length;

        //Variables for Data Item (010) [2 Oct]
        public int SAC { get; set; }
        public int SIC { get; set; }

        //Variables for Data Item (140) [3 Oct]
        public float UTC_Time { get; set; }

        //Variables for Data Item (020) [1+ ("Variable") Oct]
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
        public string FX_020 { get; set; }

        //Variables for Data Item (040) [4 Oct]
        public int RHO { get; set; }
        public int THETA { get; set; }

        //Variables for Data Item (070) [2 Oct] 
        public string V_070 { get; set; }
        public string G_070 { get; set; }
        public string L_070 { get; set; }
        public string A4_070 { get; set; }
        public string A2_070 { get; set; }
        public string A1_070 { get; set; }
        public string B4_070 { get; set; }
        public string B2_070 { get; set; }
        public string B1_070 { get; set; }
        public string C4_070 { get; set; }
        public string C2_070 { get; set; }
        public string C1_070 { get; set; }
        public string D4_070 { get; set; }
        public string D2_070 { get; set; }
        public string D1_070 { get; set; }

        //Variables for Data Item (090) [2 Oct] 
        public string V_090 { get; set; }
        public string G_090 { get; set; }
        public string flightLevel { get; set; }

        //Variables for Data Item (130) [1+ 1+ Oct]
        public string SRL { get; set; }
        public string SRR { get; set; }
        public string SAM { get; set; }
        public string PRL { get; set; }
        public string PAM { get; set; }
        public string RPD { get; set; }
        public string APD { get; set; }
        public string FX_130 { get; set; }

        //Variables for Data Item (220) [3 Oct]
        public int aircraftAddress { get; set; }

        //Variables for Data Item (240) [6 Oct]
        public int character1 { get; set; }
        public int character2 { get; set; }
        public int character3 { get; set; }
        public int character4 { get; set; }
        public int character5 { get; set; }
        public int character6 { get; set; }
        public int character7 { get; set; }
        public int character8 { get; set; }

        //Variables for Data Item (250) [1+8*n Oct]
        public string REP { get; set; }
        public string BDSDATA { get; set; }
        public string BDS1 { get; set; }
        public string BDS2 { get; set; }

        //Variables for Data Item (161) [2 Oct]
        public int trackNumber { get; set; }

        //Variables for Data Item (042) [4 Oct]
        public int xComponent { get; set; }
        public int yComponent { get; set; }

        //Variables for Data Item (200) [4 Oct]
        public int calculatedGroundSpeed { get; set; }
        public int calculatedHeading { get; set; }

        //Variables for Data Item (170) [1+ Oct]
        public string CNF { get; set; }
        public string RAD { get; set; }
        public string DOU { get; set; }
        public string MAH { get; set; }
        public string CDM { get; set; }
        public string FX_170_1 { get; set; }
        public string TRE { get; set; }
        public string GHO { get; set; }
        public string SUP { get; set; }
        public string TCC { get; set; }

        //Variables for Data Item (210) [4 Oct]
        public int sigmaX { get; set; }
        public int sigmaY { get; set; }
        public int sigmaV { get; set; }
        public int sigmaH { get; set; }

        //Variables for Data Item (030) [1+ Oct]
        public string code { get; set; }
        public string FX_030 { get; set; }

        //Variables for Data Item (080) [2 Oct]
        public string QA4_080 { get; set; }
        public string QA2_080 { get; set; }
        public string QA1_080 { get; set; }
        public string QB4_080 { get; set; }
        public string QB2_080 { get; set; }
        public string QB1_080 { get; set; }
        public string QC4_080 { get; set; }
        public string QC2__080 { get; set; }
        public string QC1__080 { get; set; }
        public string QD4__080 { get; set; }
        public string QD2__080 { get; set; }
        public string QD1__080 { get; set; }

        //Variables for Data Item (100) [4 Oct]
        public string V__100 { get; set; }
        public string G__100 { get; set; }
        public string C1_100 { get; set; }
        public string A1_100 { get; set; }
        public string C2_100 { get; set; }
        public string A2_100 { get; set; }
        public string C4_100 { get; set; }
        public string A4_100 { get; set; }
        public string B1_100 { get; set; }
        public string D1__100 { get; set; }
        public string B2_100 { get; set; }
        public string D2_100 { get; set; }
        public string B4_100 { get; set; }
        public string D4_100 { get; set; }
        public string QC1_100 { get; set; }
        public string QA1_100 { get; set; }
        public string QC2_100 { get; set; }
        public string QA2_100 { get; set; }
        public string QC4_100 { get; set; }
        public string QA4_100 { get; set; }
        public string QB1_100 { get; set; }
        public string QD1__100 { get; set; }
        public string QB2_100 { get; set; }
        public string QD2_100 { get; set; }
        public string QB4_100 { get; set; }
        public string QD4_100 { get; set; }

        //Variables for Data Item (110) [2 Oct]
        public int Height_3D { get; set; }

        //Variables for Data Item (120) [1+ Oct]
        public string CAL1 { get; set; }
        public string RDS { get; set; }
        public string D { get; set; }
        public string CAL2 { get; set; }

        //Variables for Data Item (230) [2 Oct]
        public int COM { get; set; }
        public int STAT { get; set; }
        public int SI { get; set; }
        public int MSSC { get; set; }
        public int ARC { get; set; }
        public int AIC { get; set; }
        public int B1A { get; set; }
        public int B1B { get; set; }

        //Variables for Data Item (260) [7 Oct]
        public int ACASRA { get; set; }

        //Variables for Data Item (055) [1 Oct]
        public string V_055 { get; set; }
        public string G_055 { get; set; }
        public string L_055 { get; set; }
        public string A4_055 { get; set; }
        public string A2_055 { get; set; }
        public string A1_055 { get; set; }
        public string B2_055 { get; set; }
        public string B1_055 { get; set; }

        //Variables for Data Item (050) [2 Oct]
        public string V__050 { get; set; }
        public string G__050 { get; set; }
        public string L_050 { get; set; }
        public string A4_050 { get; set; }
        public string A2_050 { get; set; }
        public string A1_050 { get; set; }
        public string B4_050 { get; set; }
        public string B2_050 { get; set; }
        public string B1_050 { get; set; }
        public string C4_050 { get; set; }
        public string C2_050 { get; set; }
        public string C1_050 { get; set; }
        public string D4_050 { get; set; }
        public string D2_050 { get; set; }
        public string D1_050 { get; set; }

        //Variables for Data Item (065) [1 Oct]
        public string QA4_065 { get; set; }
        public string QA2_065 { get; set; }
        public string QA1_065 { get; set; }
        public string QB2_065 { get; set; }
        public string QB1_065 { get; set; }

        //Variables for Data Item (060) [2 Oct]
        public string QA4_060 { get; set; }
        public string QA2_060 { get; set; }
        public string QA1_060 { get; set; }
        public string QB4_060 { get; set; }
        public string QB2_060 { get; set; }
        public string QB1_060 { get; set; }
        public string QC4_060 { get; set; }
        public string QC2__060 { get; set; }
        public string QC1__060 { get; set; }
        public string QD4__060 { get; set; }
        public string QD2__060 { get; set; }
        public string QD1__060 { get; set; }

        //Variables for Data Item (SP) [1+1+ Oct]

        //Variables for Data Item (RE) [1+1+ Oct]

    }

    public class Function
    {
        // Delegado que representará las funciones que vas a almacenar en el diccionario
        delegate void MiFuncion(string cadenadebits, CAT048 Variable048);

        // Diccionario que asocia un ID (int) con una función (MiFuncion)
        Dictionary<int, MiFuncion> DataField_FunctionsDictionary;

        // Constructor de la clase donde se inicializa el diccionario
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
        
        public void assignDF(string bytes, int contador, CAT048 Variable048) //Assign bytes to DataField
        {
            
            DataField_FunctionsDictionary[contador+1](bytes, Variable048); //Call the function associated to the ID with the bytes read as input

        }

        public void DF010 (string bytes2, CAT048 Variable048) //Get SIC and SAC
        {
            string sac = bytes2.Substring(0, 8);//Get first octet
            Variable048.SAC = Convert.ToInt32(sac,2);  //Assign to SAC
            string sic = bytes2.Substring(8, 8);   //Get first octet
            Variable048.SIC = Convert.ToInt32(sic, 2);  //Assign to SIC
        }

        public void DF140 (string bytes2, CAT048 Variable048) //Get time UTC
        {
            Variable048.UTC_Time = (Convert.ToInt32(bytes2, 2)); 
            Variable048.UTC_Time = Variable048.UTC_Time * 1 / 128;//Get decimals *1/128
        }

        public void DF020 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF040 (string bytes2, CAT048 Variable048)
        {
            string rho = bytes2.Substring(0, 16);//Get two first octets
            Variable048.RHO = Convert.ToInt32(rho, 2);  //Assign to RHO
            string theta = bytes2.Substring(16, 16);   //Get two octets
            Variable048.THETA = Convert.ToInt32(theta, 2);  //Assign to THETA
        }

        public void DF070 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF090 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF130 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF220 (string bytes2, CAT048 Variable048)
        {
            string ad = bytes2.Substring(0, 24);//Get three first octets
            Variable048.aircraftAddress = Convert.ToInt32(ad, 2);  //Assign to Aircraft Address
        }

        public void DF240 (string bytes2, CAT048 Variable048)
        {
            string c1 = bytes2.Substring(0, 6);
            Variable048.character1 = Convert.ToInt32(c1, 2);
            string c2 = bytes2.Substring(6, 6);
            Variable048.character2 = Convert.ToInt32(c2, 2);
            string c3 = bytes2.Substring(12, 6);
            Variable048.character3 = Convert.ToInt32(c3, 2);
            string c4 = bytes2.Substring(18, 6);
            Variable048.character4 = Convert.ToInt32(c4, 2);
            string c5 = bytes2.Substring(24, 6);
            Variable048.character5 = Convert.ToInt32(c5, 2);
            string c6 = bytes2.Substring(30, 6);
            Variable048.character6 = Convert.ToInt32(c6, 2);
            string c7 = bytes2.Substring(36, 6);
            Variable048.character7 = Convert.ToInt32(c7, 2);
            string c8 = bytes2.Substring(42, 6);
            Variable048.character8 = Convert.ToInt32(c8, 2);
        }

        public void DF250 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF161 (string bytes2, CAT048 Variable048)
        {
            string tNumber = bytes2.Substring(4, 12);
            Variable048.trackNumber = Convert.ToInt32(tNumber, 2);
        }

        public void DF042 (string bytes2, CAT048 Variable048)
        {
            string x = bytes2.Substring(0, 16);
            Variable048.xComponent = Convert.ToInt32(x, 2);
            string y = bytes2.Substring(16, 16);
            Variable048.yComponent = Convert.ToInt32(y, 2);
        }

        public void DF200 (string bytes2, CAT048 Variable048)
        {
            //string GS = bytes2.Substring(0, 16);
            //Variable048.calculatedGroundSpeed = Convert.ToInt32(GS, 2);
            //string Head = bytes2.Substring(16, 16);
            //Variable048.calculatedHeading = Convert.ToInt32(Head, 2);
        }

        public void DF170 (string bytes2, CAT048 Variable048)
        {
        }

        public void DF210 (string bytes2, CAT048 Variable048)
        {
            //string sX = bytes2.Substring(0, 8);
            //Variable048.sigmaX = Convert.ToInt32(sX, 2);
            //string sY = bytes2.Substring(8, 8);
            //Variable048.sigmaY = Convert.ToInt32(sY, 2);
            //string sV = bytes2.Substring(16, 8);
            //Variable048.sigmaV = Convert.ToInt32(sV, 2);
            //string sH = bytes2.Substring(24, 8);
            //Variable048.sigmaH = Convert.ToInt32(sH, 2);
        }

        public void DF030 (string bytes2, CAT048 Variable048) //NOT NECESSARY
        {
        }

        public void DF080 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF100 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF110 (string bytes2, CAT048 Variable048)
        {
            string height = bytes2.Substring(2, 14);
            Variable048.Height_3D = Convert.ToInt32(height, 2);
        }

        public void DF120 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF230 (string bytes2, CAT048 Variable048)
        {
            string com = bytes2.Substring(0, 3);
            Variable048.COM = Convert.ToInt32(com, 2);
            string stat = bytes2.Substring(3, 3);
            Variable048.STAT = Convert.ToInt32(stat, 2);
            string si = bytes2.Substring(6, 1);
            Variable048.SI = Convert.ToInt32(si, 2);
            string mssc = bytes2.Substring(8, 1);
            Variable048.MSSC = Convert.ToInt32(mssc, 2);
            string arc = bytes2.Substring(9, 1);
            Variable048.ARC = Convert.ToInt32(arc, 2);
            string aic = bytes2.Substring(10, 1);
            Variable048.AIC = Convert.ToInt32(aic, 2);
            string b1a = bytes2.Substring(11, 1);
            Variable048.B1A = Convert.ToInt32(b1a, 2);
            string b1b = bytes2.Substring(12, 4);
            Variable048.B1B = Convert.ToInt32(b1b, 2);
        }

    public void DF260 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
            string acasra = bytes2.Substring(0, 56);
            Variable048.ACASRA = Convert.ToInt32(acasra, 2);
        }

        public void DF055 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF050 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF065 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DF060 (string bytes2, CAT048 Variable048)//NOT NECESSARY
        {
        }

        public void DFSP (string bytes2, CAT048 Variable048)
        {
        }

        public void DFRE (string bytes2, CAT048 Variable048)
        {
        }
    }

 }

