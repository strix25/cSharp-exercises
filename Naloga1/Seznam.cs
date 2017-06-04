using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Seznam
    {
        //seznam oseb v katerega shranimo 4 random popotnike, 
        //izpis vse osebe ki so zenske(), osebo ki ima dolocen email(mail), osebe rojene med dvema datumoma(dva datuma)
        private List<Popotnik> popotniki = new List<Popotnik>();

        public List<Popotnik> Popotniki
        {
            get { return popotniki; }
            set { popotniki = value; }
        }

        public List<Popotnik> izpisZensk()
        {
            List<Popotnik> zenske = new List<Popotnik>();
            foreach (var x in popotniki)
            {
                if (x.Spol == Spol.ženski)
                {
                    zenske.Add(x);
                }
            }
            return zenske;
        }

        public void osebaZMailom(string elektronskiNaslov)
        {
            foreach (var x in popotniki)
            {
                if (x.ElektronskiNaslov == elektronskiNaslov)
                {
                    Console.WriteLine(x.Ime);
                    break;
                }
            }
        }

        public List<Popotnik> medDvemaDatumoma(DateTime prvi, DateTime drugi)
        {

            List<Popotnik> people = new List<Popotnik>();
            foreach (var x in popotniki)
            {
                if (x.RojstniDatum > prvi && x.RojstniDatum < drugi)
                {
                    people.Add(x);
                }
            }
            return people;
        }
    }
}
