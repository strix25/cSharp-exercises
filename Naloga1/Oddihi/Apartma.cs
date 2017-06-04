using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{

    class Apartma : Oddih
    {
        // število postelj, dovoljeno kajenje ter seznam (polje!) prednosti (enum Prednosti)
        private int steviloPostelj;
        private Kajenje dovoljenoKajenje;
        private Prednosti[] prednosti;

        public int SteviloPostelj
        {
            get { return steviloPostelj; }
            set { steviloPostelj = value; }
        }
        public Kajenje DovoljenoKajenje
        {
            get { return dovoljenoKajenje; }
            set { dovoljenoKajenje = value; }
        }
        public Prednosti[] Prednosti {
            get { return prednosti; }
            set { prednosti = value; }
        } //mora biti polje

        public Apartma()
        {

        }

        public override double vrniCenoZDoplacili()
        {
            //Apartma tako, da za vsako prednost (enum Prednosti) osnovni ceni prištejete dodatnih 5%
            if (Prednosti.Length > 0)
            {
                Cena = Cena + Prednosti.Length * (Cena * 0.05);
            }

            return this.Cena;
        }

        public void IzpisPolja()
        {
            for (int i = 0; i < this.prednosti.Length; i++)
            {
                Console.WriteLine(prednosti[i]);
            }
        }

        public override void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", Naziv, Destinacija, Cena, SteviloProstihMest, Prednosti, SteviloPostelj, DovoljenoKajenje));
        }

        //konstruktorji
        //public Apartma():base() { }

        public Apartma(string naziv, Destinacija destinacija, double cena, int steviloProstihMest, int steviloPostelj, Kajenje dovoljenoKajenje, Prednosti[] elements) : base(naziv, destinacija, cena, steviloProstihMest)
        {
            prednosti = elements;
            this.steviloPostelj = steviloPostelj;
            this.dovoljenoKajenje = dovoljenoKajenje;
        }

        public Apartma(string naziv, Destinacija destinacija, double cena, int steviloProstihMest, int steviloPostelj, Kajenje dovoljenoKajenje) : base(naziv, destinacija, cena, steviloProstihMest)
        {
            this.steviloPostelj = steviloPostelj;
            this.dovoljenoKajenje = dovoljenoKajenje;
        }

    }
}
