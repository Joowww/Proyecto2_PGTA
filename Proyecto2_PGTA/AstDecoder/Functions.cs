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
        public string UTCTime { get; set; }

        //Variables for Data Item (020) [1+ ( "Variable") Oct]
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
        public string ZERO_020 { get; set; }
        public string FX_020 { get; set; }

        //Variables for Data Item (040) [4 Oct]
        public string RHO { get; set; }
        public string THETA { get; set; }

        //Variables for Data Item (070) [2 Oct]

        //Variables for Data Item (090) [2 Oct]

        //Variables for Data Item (130) [1+ 1+ Oct]
        public string SRL { get; set; }
        public string SRR { get; set; }
        public string SAM { get; set; }
        public string PRL { get; set; }
        public string PAM { get; set; }
        public string RPD { get; set; }
        public string APD { get; set; }


        //Variables for Data Item (220) [3 Oct]
        public string AIRCRAFT { get; set; }
        public string ADDRESS { get; set; }

        //Variables for Data Item (240) [6 Oct]
        public string Character1 { get; set; }
        public string Character2 { get; set; }
        public string Character3 { get; set; }
        public string Character4 { get; set; }
        public string Character5 { get; set; }
        public string Character6 { get; set; }
        public string Character7 { get; set; }
        public string Character8 { get; set; }


        //Variables for Data Item (250) [1+8*n Oct]
        public string REP { get; set; }
        public string MSB { get; set; }
        public string BDS { get; set; }
        public string DATA { get; set; }
        public string LSB { get; set; }
        public string BDS1 { get; set; }
        public string BDS2 { get; set; }


        //Variables for Data Item (161) [2 Oct]
        public string TRACK_NUMBER { get; set; }

        //Variables for Data Item (042) [4 Oct]

        //Variables for Data Item (200) [4 Oct]
        public string CALCULATED_GROUNDSPEED { get; set; }
        public string CALCULATED_HEADING { get; set; }

        //Variables for Data Item (170) [1+ Oct]
        public string CNF { get; set; }
        public string RAD { get; set; }
        public string DOU { get; set; }
        public string MAH { get; set; }
        public string CDM { get; set; }
        public string TRE { get; set; }
        public string GHO { get; set; }
        public string SUP { get; set; }
        public string TCC { get; set; }


        //Variables for Data Item (210) [4 Oct]
        public string SIGMA_X { get; set; }
        public string SIGMA_Y { get; set; }
        public string SIGMA_V { get; set; }
        public string SIGMA_H { get; set; }

        //Variables for Data Item (030) [1+ Oct]

        //Variables for Data Item (080) [2 Oct]

        //Variables for Data Item (100) [4 Oct]

        //Variables for Data Item (110) [2 Oct]

        //Variables for Data Item (120) [1+ Oct]

        //Variables for Data Item (230) [2 Oct]

        public string COM { get; set; }
        public string STAT { get; set; }
        public string SI { get; set; }
        public string ZERO_230 { get; set; }
        public string MSSC { get; set; }
        public string ARC { get; set; }
        public string AIC { get; set; }
        public string B1A { get; set; }
        public string B1B { get; set; }

        //Variables for Data Item (260) [7 Oct]
        public string ACASRA { get; set; }

        //Variables for Data Item (055) [1 Oct]

        //Variables for Data Item (050) [2 Oct]

        //Variables for Data Item (065) [1 Oct]

        //Variables for Data Item (060) [2 Oct]

        //Variables for Data Item (SP) [1+1+ Oct]

        //Variables for Data Item (RE) [1+1+ Oct]


        //Variables for Data Item (161) [2 Oct]
        public string Track_Number { get; set; }

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