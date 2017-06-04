using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    static class Ponudba
    {
        public static List<Oddih> itemlist = new List<Oddih>();
        public static void readfromfile()
        {
            var lines = System.IO.File.ReadAllLines("SeznamPonudbe.csv").Skip(1).TakeWhile(t => t != null);

            foreach (string item in lines)
            {
                var values = item.Split(',');
                //Naziv,Kraj,Destinacija,Št mest,cena,Tip,kajenje,balkon
                if (values[5] == "Apartma")
                { 

                    itemlist.Add(new Apartma()
                    {
                        Naziv = values[0],
                        Destinacija = new Destinacija { Kraj = values[1], Drzava = values[2] },
                        Cena = double.Parse(values[4], CultureInfo.InvariantCulture),
                        SteviloProstihMest = int.Parse(values[3]),
                        DovoljenoKajenje = (Kajenje) Enum.Parse(typeof(Kajenje), values[6])
                    });
                }
                else if (values[5] == "Izlet")
                {
                    itemlist.Add(new Izlet()
                    {
                        Naziv = values[0],
                        Destinacija = new Destinacija { Kraj = values[1], Drzava = values[2] },
                        Cena = double.Parse(values[4], CultureInfo.InvariantCulture),
                        SteviloProstihMest = int.Parse(values[3])
                    });
                }
                else if (values[5] == "Križarjenje")
                {
                    itemlist.Add(new Krizarjenje()
                    {
                        Naziv = values[0],
                        Destinacija = new Destinacija { Kraj = values[1], Drzava = values[2] },
                        Cena = double.Parse(values[4], CultureInfo.InvariantCulture),
                        SteviloProstihMest = int.Parse(values[3]),
                        Balkon = (BBalkon)Enum.Parse(typeof(BBalkon), values[7])
                    });
                }
                
            }
         
        }
    }
}
