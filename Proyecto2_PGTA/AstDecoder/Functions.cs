using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;


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
        public string SAC { get; set; }
        public string SIC { get; set; }

        //Variables for Data Item (140) [3 Oct]
        public string UTC_Time { get; set; }

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
        public string RHO { get; set; }
        public string THETA { get; set; }

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
        public string aircraftAddress { get; set; }

        //Variables for Data Item (240) [6 Oct]
        public string character1 { get; set; }
        public string character2 { get; set; }
        public string character3 { get; set; }
        public string character4 { get; set; }
        public string character5 { get; set; }
        public string character6 { get; set; }
        public string character7 { get; set; }
        public string character8 { get; set; }

        //Variables for Data Item (250) [1+8*n Oct]
        public string REP { get; set; }
        public string BDSDATA { get; set; }
        public string BDS1 { get; set; }
        public string BDS2 { get; set; }

        //Variables for Data Item (161) [2 Oct]
        public string trackNumber { get; set; }

        //Variables for Data Item (042) [4 Oct]
        public string xComponent { get; set; }
        public string yComponent { get; set; }

        //Variables for Data Item (200) [4 Oct]
        public string calculatedGroundSpeed { get; set; }
        public string calculatedHeading { get; set; }

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
        public string sigmaX { get; set; }
        public string sigmaY { get; set; }
        public string sigmaV { get; set; }
        public string sigmaH { get; set; }

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
        public string Height_3D { get; set; }

        //Variables for Data Item (120) [1+ Oct]
        public string CAL1 { get; set; }
        public string RDS { get; set; }
        public string D { get; set; }
        public string CAL2 { get; set; }

        //Variables for Data Item (230) [2 Oct]
        public string COM { get; set; }
        public string STAT { get; set; }
        public string SI { get; set; }
        public string MSSC { get; set; }
        public string ARC { get; set; }
        public string AIC { get; set; }
        public string B1A { get; set; }
        public string B1B { get; set; }

        //Variables for Data Item (260) [7 Oct]
        public string ACASRA { get; set; }

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
        int DataFieldCounter = 1;
        public void assignDF(string bytes, string FSPEC) //Assign bytes to DataField
        {
            if (FSPEC[0] == 1)
            {
                DF010(bytes); //Call function DF010
            }
            if (FSPEC[1] == 1)
            {
                //Call function DF140
            }



        }

        public void DF010(string bytes2)
        {
            string sac = bytes2.Substring(0, 8);//Get first octet
            this.SAC = sac; //Assign to SAC
            string sic = bytes2.Substring(8, 16);//Get first octet
            this.SIC = sac; //Assign to SIC
        }
    }

}