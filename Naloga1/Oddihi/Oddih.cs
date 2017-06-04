using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    
    abstract class Oddih
    {
        public bool vrniZDavkom = false;
        public decimal popust = 0;
        private const double DDV = 0.22;

        private string naziv;
        private Destinacija destinacija;
        private double cena;
        private int steviloProstihMest;

        public string Naziv { get { return naziv; } set { naziv = value; } }
        public Destinacija Destinacija { get { return destinacija; } set { destinacija = value; } }
        public double Cena { get { return cena; } set { cena = value; } }
        public int SteviloProstihMest { get { return steviloProstihMest; } set { steviloProstihMest = value; } }

        public Oddih(){}

        public Oddih(string naziv)
        {
            this.Naziv = naziv;
        }

        public Oddih(string naziv, Destinacija destinacija, double cena, int steviloProstihMest) : this(naziv)
        {
            this.Destinacija = destinacija;
            this.Cena = cena;
            this.SteviloProstihMest = steviloProstihMest;
        }

        public virtual void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", Naziv, Destinacija, Cena, SteviloProstihMest));
        }

        public double vrniCenoOddiha()
        {
            return Cena;
        }

        public double vrniCenoOddiha(bool vrniZDavkom)
        {
            if (vrniZDavkom)
            {
                return Cena + (Cena * (double)DDV);
            }
            else
            {
                return Cena;
            }
        }

        public double vrniCenoOddiha(double popust)
        {
            try
            {
                if (popust <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Whatever.ErrorLogging(e);
                Console.WriteLine(e);
            }
            
            return Cena - (Cena * (popust * (double)0.1));
        }

        public double vrniCenoOddiha(double popust, bool vrniZDavkom)
        {
            try
            {
                if (popust <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Whatever.ErrorLogging(e);
                Console.WriteLine(e);
            }
            if (vrniZDavkom)
            {
                return Cena - (Cena * (popust * (double)0.1));
            }
            else
            {
                return (Cena - (Cena * (popust * (double)0.1))) * (double)DDV;
            }
        }
        public override string ToString()
        {
            return Naziv + " " + cena + " " + Destinacija.Drzava + " " + Destinacija.Kraj + " " + SteviloProstihMest;
        }
        public abstract double vrniCenoZDoplacili();


    }
}
