using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    public delegate void Obvestilo(string data);
    class Termin  //trip
    {
        public event Obvestilo obvestilo;

        public void call()
        {
            obvestilo("ime");
        }

        //public void ObNoviPrijavi()
        //{
        //    Console.WriteLine("Potnik:" + this.Ime + ", uspešno ste prijavljeni na termin!");
        //}

        private DateTime datumOdhoda;
        private int trajanje;
        private Dictionary<string, Popotnik> seznamPrijavljenihOseb = new Dictionary<string, Popotnik>();
        public Dictionary<string, Popotnik> SeznamPrijavljenihOseb
        {
            get { return seznamPrijavljenihOseb; }
            set { seznamPrijavljenihOseb = value; }
        }

        //atributi: datumOdhoda, trajanje (v dneh) in seznamPrijavljenihOseb (polje).
        public DateTime DatumOdhoda { get; set; }
        public int Trajanje { get; set; }
        

        public Termin()
        {

        }

        public Termin(DateTime datumOdhoda, int trajanje, int steviloKabin)
        {
            this.datumOdhoda = datumOdhoda;
            this.trajanje = trajanje;
            this.seznamPrijavljenihOseb =  new Dictionary<string, Popotnik>(steviloKabin);
        }

        
    }
}
