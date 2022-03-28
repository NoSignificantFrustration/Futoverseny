using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Futoverseny
{
    public class Resztvevo
    {
        public string rajtszam;
        public string nev;
        public string szuldatum;
        public string orszag;
        public double idoperc;
        public double idomasodperc;

        public Resztvevo(string sor)
        {
            string[] t = sor.Split(";");
            rajtszam = t[0];
            nev = t[1];
            szuldatum = t[2];
            orszag = t[3];
            idoperc = double.Parse(t[4].Split(":")[0]);
            idomasodperc = double.Parse(t[4].Split(":")[1], CultureInfo.InvariantCulture);
        }
    }
}
