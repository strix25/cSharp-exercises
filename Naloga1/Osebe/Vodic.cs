using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Vodic : Oseba
    {
        private string kontaktnaStevilka;
        private int stevilkaLicence;

        public string KontaktnaStevilka
        {
            get { return kontaktnaStevilka; }
            set { kontaktnaStevilka = value; }
        }
        public int StevilkaLicence
        {
            get { return stevilkaLicence; }
            set { stevilkaLicence = value; }
        }

        public Vodic():base(){ }

        public override void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", Ime, Priimek, Spol, RojstniDatum, KontaktnaStevilka, StevilkaLicence));
        }
    }
}
