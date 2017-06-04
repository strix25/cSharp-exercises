using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Oseba
    {
        private string ime;
        private string priimek;
        private Spol spol;
        private DateTime rojstniDatum;
        private bool hasValue = false;
        //Razredu Oseba dodajte nespremenljivo lastnost (property) zacetnica, ki vrača prvo črko imena in priimka, ločena s piko. (Primer: M.J)
        private string zacetnica;

        public string Zacetnica
        {
            get
            {
                this.zacetnica = this.ime[0] + "." + this.priimek[0];
                return this.zacetnica;
            }
        }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Priimek { get { return priimek; } set { priimek = value; } }
        public Spol Spol { get { return spol; } set { spol = value; } }
        public  DateTime RojstniDatum
        {
          get
            {
                return rojstniDatum;
            }
          set
            {
                if (!hasValue)
                { /*throw new InvalidOperationException("Value already set");*/
                    this.rojstniDatum = value;
                    this.hasValue = true;
                }
            }
        }

        public Oseba(){}

        public Oseba(string ime, string priimek)
        {
            this.Ime = ime;
            this.Priimek = priimek;
        }

        public Oseba(string ime, string priimek, Spol spol, DateTime rojstniDatum) : this(ime, priimek)
        {
            this.Spol = spol;
            this.RojstniDatum = rojstniDatum;
        }

        public virtual void izpis()
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}", Ime, Priimek, Spol, RojstniDatum));
        }

        public override bool Equals(object obj)
        {
            //imata enako ime, priimek, spol in datum rojstva.
            Oseba obj1 = obj as Oseba;

            return ime == obj1.ime && priimek == obj1.priimek && spol == obj1.spol && rojstniDatum==obj1.rojstniDatum;
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
