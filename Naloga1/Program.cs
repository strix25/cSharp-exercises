using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
   

    public enum Spol { moški, ženski };
    public enum Prednosti { wifi, TV, klima, parkirišče, bazen };
    public enum Kajenje { da, ne };
    public enum BBalkon { da, ne};

    class Program
    {

        static void Main(string[] args)
        {
            //##############################################################
            //#################### naloga 6 ################################
            //##############################################################

            Ponudba.readfromfile();



           

            List<Oddih> itemToRemove = Ponudba.itemlist.FindAll(x => x.Destinacija.Drzava.Contains("Slovenija"));
            

            foreach (object o in itemToRemove)
            {
                Console.WriteLine(o);
            }

            Ponudba.itemlist.RemoveAll(x => x.Destinacija.Drzava.Contains("Slovenija"));
            

            //samo izpise vse z lista 
            foreach (object os in Ponudba.itemlist)
            {
                Console.WriteLine(os);
            }

            Console.WriteLine("##############");

            //Med Oddihi poiščite tistega z najdražjo ceno in ga odstranite. Za iskanje uporabite lambda izraz. Najden objekt pri tem tudi izpišite.
            var maxObject = Ponudba.itemlist.OrderByDescending(item => item.Cena).First();
            Console.WriteLine(maxObject);
            Ponudba.itemlist.Remove(maxObject);

            //samo izpise vse z lista 
            foreach (object os in Ponudba.itemlist)
            {
                Console.WriteLine(os);
            }

            Console.WriteLine("#############");

            //dodajte nov apartma
            Apartma delo = new Apartma(naziv: "nekaj", destinacija: new Destinacija { Drzava = "Slovenija" }, cena: 10, steviloProstihMest: 1, steviloPostelj: 1, dovoljenoKajenje: Kajenje.da);
            Ponudba.itemlist.Add(delo);

            foreach (object os in Ponudba.itemlist)
            {
                Console.WriteLine(os);
            }

            Console.WriteLine("#######vsaj eno prosto mesto ######");

            //Prebrano ponudbo ustrezno razporedite v dva podseznama. Eden naj vsebuje vse ponudbe, ki imajo na voljo
            //še vsaj eno prosto mesto, drug pa ostale, ki jih več nimajo. Oba podseznama tudi sortirajte po ceni.
            List<Oddih> vsajEnoMesto = new List<Oddih>();
            List<Oddih> nicProstihMest = new List<Oddih>();

            vsajEnoMesto = Ponudba.itemlist.Where(x => x.SteviloProstihMest > 0)
                         .ToList();

            foreach (object os in vsajEnoMesto)
            {
                Console.WriteLine(os);
            }

            Console.WriteLine("######Nic prostih mest#######");

            nicProstihMest = Ponudba.itemlist.Where(x => x.SteviloProstihMest == 0)
                         .ToList();

            foreach (object os in nicProstihMest)
            {
                Console.WriteLine(os);
            }

            Console.WriteLine("#############");
            //Ustvarite novo datoteko seznamPonudbeIzhod.csv, v katero zapišete samo ponudbe, katerih cena je nižja od 1500€.

            using (var file = File.CreateText("izhod.csv"))
            {
                file.WriteLine("potato");
                foreach (var arr in Ponudba.itemlist)
                {
                    file.WriteLine(string.Join(",", arr));
                }
            }
            //linq File.WriteAllLines("text.txt", Ponudba.itemlist.Select(x => string.Join(",", x)));

            Console.WriteLine("#############");
            //S pomočjo lambda izraza izračunajte povprečno ceno Oddihov, ter ga izpišite v glavnem programu.
            var potat = Ponudba.itemlist.Average(item => item.Cena);
            Console.WriteLine(potat);




            //##############################################################
            //#################### naloga 7 ################################
            //##############################################################

            Oseba oseba1 = new Oseba("Damjan", "Oslaj", Spol.moški, DateTime.Today);
            Oseba oseba2 = new Oseba("Joze", "Neka", Spol.moški, DateTime.Today);

            Popotnik popotnik1 = new Popotnik("Joze", "Ezoj", "joze@mail.com");
            Popotnik popotnik2 = new Popotnik("Franc", "Cnarf", "franc.mail.com");
            Popotnik popotnik3 = new Popotnik("Janez", "Zenaj", "janez.mail.com");
            Popotnik popotnik4 = new Popotnik("Jasnez", "Zsenaj", "jasnez.mail.com");

            var iii = popotnik1.GetType().Name;
            Console.WriteLine(iii + " ddddddddddd ");

            Krizarjenje krizarjenje1 = new Krizarjenje(BBalkon.da, 1, 10);
            Termin termin1 = new Termin(DateTime.Now, 5, 5);
            krizarjenje1.DodajTerminZaOdhod(termin1);

            krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik1);
            krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik2);
            krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik3);
            krizarjenje1.odstraniPopotnika(krizarjenje1.Odhodi[0], popotnik4);

            Console.WriteLine("§§§§§§§§§§§§");
            krizarjenje1.Odhodi[0].call();
            Console.WriteLine("§§§§§§§§§§§§");

            //vse kraje, katerih cena je manjša kot 1200 €
            Console.WriteLine("######Cena manjsa od 1200#######");
            List<Oddih> cenaMajnsaODtdvesto = new List<Oddih>();

            cenaMajnsaODtdvesto = Ponudba.itemlist.Where(x => x.Cena < 1200)
                         .ToList();

            foreach (object os in cenaMajnsaODtdvesto)
            {
                Console.WriteLine(os);
            }

            //število ponudb, kjer je destinacija Grčija
            Console.WriteLine("######Stevilo ponudb iz grcije#######");
            var steviloPonudbIzGrcije = Ponudba.itemlist.Where(x => x.Destinacija.Drzava == "Grčija")
                         .Count();
            Console.WriteLine(steviloPonudbIzGrcije);

            //vse ponudbe, ki imajo več kot 3 prosta mesta in jih uredite po ceni (od najcenejše do najdražje)
            Console.WriteLine("######Vec kot 3 mesta#######");
            List<Oddih> vecKotTriMesta = new List<Oddih>();
            //////functional verzija
            //vecKotTriMesta = Ponudba.itemlist.Where(x => x.SteviloProstihMest > 3).OrderBy(x => x.Cena)
            //             .ToList();

            //query verzija
            vecKotTriMesta = (from element in Ponudba.itemlist
                          where element.SteviloProstihMest > 3
                          orderby element.Cena
                          select element).ToList();

            foreach (object os in vecKotTriMesta)
            {
                Console.WriteLine(os);
            }

            //ceno najdražje ponudbe
            Console.WriteLine("######Cena najdrazje ponudbe#######");
            //var najdrazja = Ponudba.itemlist.Max(x => x.Cena);
             var najdrazja = (from d in Ponudba.itemlist select d.Cena).Max();
            Console.WriteLine(najdrazja);


















            //vse ponudbe iz spanije
            Console.WriteLine("######Ponudbe iz spanije#######");
            List<Oddih> spanija = new List<Oddih>();

            spanija = Ponudba.itemlist.Where(x => x.Destinacija.Drzava =="Španija"/* && x.GetType() == "Apartma"*/)
                         .ToList();

            foreach (object os in spanija)
            {
                Console.WriteLine(os);
            }
            //izpis ponudbe 16
            Console.WriteLine("######Ponudba 16#######");
            

            var sestnaj = Ponudba.itemlist.FirstOrDefault(x => x.Naziv == "Ponudba 16");

            Console.WriteLine(sestnaj);



            //cena najdrazje
            Console.WriteLine("######Cena najdrazje ponudbe#######");
            var najdrazjaPonudba = Ponudba.itemlist.Max(x => x.Cena);
            Console.WriteLine(najdrazjaPonudba);

            //////////////////////////linq q syntax//////////////////////////////
            /////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////
            //vse ponudbe iz spanije
            Console.WriteLine("######Ponudbe iz spanije LINQ#######");
            List<Oddih> spanija2 = new List<Oddih>();

            spanija2 = (from element in Ponudba.itemlist
                        where element.Destinacija.Drzava == "Španija"
                        select element).ToList();

            foreach (object os in spanija2)
            {
                Console.WriteLine(os);
            }

            //izpis ponudbe 16
            Console.WriteLine("######Ponudba 16 LINQ#######");

            var sestnaj2 = (from x in Ponudba.itemlist where x.Naziv == "Ponudba 16" select x).FirstOrDefault();
            Console.WriteLine(sestnaj2);

            //cena najdrazje
            Console.WriteLine("######Cena najdrazje ponudbe LINQ#######");

            var najdr = (from d in Ponudba.itemlist select d.Cena).Max();

            Console.WriteLine(najdr);

            Console.WriteLine("######Apartmas#######");
            List<Oddih> apartma = new List<Oddih>();

            apartma = Ponudba.itemlist.Where(x => x.Cena > 0 && x.GetType().Name == "Apartma")
                         .ToList();

            foreach (object os in apartma)
            {
                Console.WriteLine(os);
            }

            ///////
            ////////////
            ///////////////////////////
            //////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////
            //////Oseba oseba1 = new Oseba("Damjan", "Oslaj", Spol.moški, DateTime.Today);
            //////Oseba oseba2 = new Oseba("Joze", "Neka", Spol.moški, DateTime.Today);
            //////Console.WriteLine("Sta osebi enaki ? : " + oseba1.Equals(oseba2));

            //////Popotnik popotnik1 = new Popotnik("ne2kaj@mail.com", "3", "prii4mek");
            //////Popotnik popotnik2 = new Popotnik("ne22kaj@mail.com", "i2me", "1");
            //////Popotnik popotnik3 = new Popotnik("nekaj23@mail.com", "i1me", "pri4imek");

            //////Krizarjenje krizarjenje1 = new Krizarjenje(true, 1, 10);
            //////Termin termin1 = new Termin(DateTime.Now, 5, 5);
            //////krizarjenje1.DodajTerminZaOdhod(termin1);

            //////krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik1);
            //////krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik2);
            //////krizarjenje1.dodajPopotnika(krizarjenje1.Odhodi[0], popotnik3);

            //////krizarjenje1.odstraniPopotnika(krizarjenje1.Odhodi[0], popotnik3);

            //////Console.WriteLine("Odhod krizarjenja bo: " + krizarjenje1.VrniOdhod(0).DatumOdhoda);
            //////Console.WriteLine("Trenutno število odhodov je: " + krizarjenje1.VrniSteviloOdhodov());


            Console.ReadLine();
        }
    }
}
