using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Destinacija
    {
        private string drzava;
        private string kraj;

        public string Drzava { get { return drzava; } set { drzava = value; } }
        public string Kraj { get { return kraj; } set { kraj = value; } }

        public Destinacija() { }

        public Destinacija(string drzava)
        {
            this.Drzava = drzava;
        }

        public Destinacija(string drzava, string kraj) : this(drzava)
        {
            this.Kraj = kraj;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", Drzava, Kraj);
        }

        public void izpis()
        {
            Console.WriteLine(string.Format("{0} {1}", Drzava, Kraj));
        }
    }
}
