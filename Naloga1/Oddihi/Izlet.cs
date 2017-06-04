using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Izlet : Oddih
    {
        //Razred Izlet, ki je dopolnjen z atributoma zbirno mesto ter vodič
        private string zbirnoMesto;
        private string vodic;

        public string ZbirnoMesto
        {
            get { return zbirnoMesto; }
            set { zbirnoMesto = value; }
        }
        public string Vodic
        {
            get { return vodic; }
            set { vodic = value; }
        }

        public override double vrniCenoZDoplacili()
        {
            return this.Cena;
        }
        public Izlet() : base(){}

        public override void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", Naziv, Destinacija, Cena, SteviloProstihMest, ZbirnoMesto, Vodic));
        }
    }
}
