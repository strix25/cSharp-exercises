using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Krizarjenje : Oddih, IProdajni
    {
        //Razredu Križarjenje dodajte atribut številoKabin.
        //Razredu Križarjenje dodajte atribut odhodi, ki naj bo tipa polje Terminov.Velikost polja je poljubna.
        

        private BBalkon balkon;
        private int dodatnoLezisce;
        private  int steviloKabin;
        private List<Termin> odhodi = new List<Termin>();

        public List<Termin> Odhodi
        {
            get { return odhodi; }
            set { odhodi = value; }
        }

        public  int SteviloKabin
        {
            get { return steviloKabin; }
            set { steviloKabin = value; }
        }
       
        public BBalkon Balkon
        { 
            get { return balkon; }
            set { balkon = value; }
        }
        public int DodatnoLezisce
        {
            get { return dodatnoLezisce; }
            set { dodatnoLezisce= value; }
        }

        public void OdstraniTermin(Termin termin)
        {
            foreach (var IskanTermin in odhodi)
            {
                if (IskanTermin == termin)
                {
                    odhodi.Remove(termin);
                    break;
                }
            }
        }

        public Termin VrniNajkasnejsiTermin()
        {
            Termin xy = new Termin();
            DateTime zacasni = new DateTime(2000, 1, 1);
            foreach (var zadnjiTermin in odhodi)
            {
                if (zacasni.Date < zadnjiTermin.DatumOdhoda.Date)
                {
                    zacasni = zadnjiTermin.DatumOdhoda;
                    xy.DatumOdhoda = zadnjiTermin.DatumOdhoda;
                }
            }
            return xy;
        }

        public List<Termin> VrniTermineBrezPotnikov()
        {
            //vrne vse termine, na katere ni prijavljenih potnikov

            List<Termin> termini = new List<Termin>();
            foreach (var termin in odhodi)
            {
                if (termin.SeznamPrijavljenihOseb.Count() == 0)
                {
                    termini.Add(termin);
                }
            }


            return termini;
        }

        public override double vrniCenoZDoplacili()
        {
            //Krizarjenje tako, da za dodatno ležišče prištejete 70 EUR ter dodatnih 30% za kabino z balkonom

            if (this.Balkon == BBalkon.da)
            {
                this.Cena = Cena * 1.3;
            }
            if (this.DodatnoLezisce > 0)
            {
                this.Cena = this.Cena + (this.DodatnoLezisce * 70);
            }
            return this.Cena;
        }

        //TODO: //Razredu Križarjenje dodajte metodo, ki doda nov termin za odhod.
        public void DodajTerminZaOdhod(Termin termin)
        {
            odhodi.Add(termin);
        }
            
        public Krizarjenje():base() { }

        public Krizarjenje(string naziv, Destinacija destinacija, double cena, int steviloProstihMest, BBalkon balkon, int dodatnoLezisce, int steviloKabin) : base(naziv, destinacija, cena, steviloProstihMest)
        {
            this.balkon = balkon;
            this.dodatnoLezisce = dodatnoLezisce;
            this.steviloKabin = steviloKabin;
        }

        public Krizarjenje(BBalkon balkon, int dodatnoLezisce, int steviloKabin)
        {
            this.balkon = balkon;
            this.dodatnoLezisce = dodatnoLezisce;
            this.steviloKabin = steviloKabin;
        }
        public override void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", Naziv, Destinacija, Cena, SteviloProstihMest, Balkon, DodatnoLezisce));
        }

        /*
            void dodajPopotnika (Termin odhod, Popotnik popotnik), ki doda popotnika v podan termin odhoda
            void odstraniPopotnika (Termin odhod, Popotnik popotnik), ki odstrani popotnika iz podanega termina odhoda
            Termin vrniOdhod (int indeks)
            int vrniŠteviloOdhodov()
         */
         
        
        public void dodajPopotnika(Termin odhod, Popotnik popotnik)
        {
            //if (SteviloProstihMest == 0)
            //{
            //    throw new KrizarjenjePolnException("To krizarjenje je ze polno");
            //}
            foreach (var termin in odhodi)
            {
                if (odhod == termin)
                {
                    termin.SeznamPrijavljenihOseb.Add(popotnik.ElektronskiNaslov, popotnik);
                    odhod.obvestilo += popotnik.print;
                }
            }
        }

        

        //public void print(string name)
        //{
        //    Console.WriteLine("yes we got the name : " + name);
        //}

        public void odstraniPopotnika(Termin odhod, Popotnik popotnik)
        {
            foreach (var termin in odhodi)
            {
                if (termin == odhod)
                {
                    try
                    {
                        if (!(termin.SeznamPrijavljenihOseb.ContainsKey(popotnik.ElektronskiNaslov)))
                        {
                            throw new PopotnikNeObstajaException("Ta popotnik ne obstaja");

                        }
                    }
                    catch(PopotnikNeObstajaException e)
                    {
                        Whatever.ErrorLogging(e);
                        Console.WriteLine("eror; {0}", e);
                    }
                    

                    foreach (var IskanPopotnik in termin.SeznamPrijavljenihOseb.ToList())
                    {
                        if (IskanPopotnik.Value.ElektronskiNaslov.Equals(popotnik.ElektronskiNaslov))
                        {
                            termin.SeznamPrijavljenihOseb.Remove(IskanPopotnik.Value.ElektronskiNaslov);
                        }
                    }
                }
            }
            //if (potato == false)
            //{
            //    throw new PopotnikNeObstajaException("Ta popotnik ne obstaja");
            //}
        }

        public Termin VrniOdhod(int indeks)
        {
            int stevec = 0;
            foreach (var termin in odhodi)
            {
                if (stevec == indeks)
                {
                    return termin;
                }
                stevec++;
            }

            return null;
        }

        public int VrniSteviloOdhodov()
        {
            int stevecOdhodov = 0;
            foreach (var odhod in odhodi)
            {
                stevecOdhodov++;
            }
            // ALI int i = odhodi.Count;

            return stevecOdhodov;
        }
    }
}
