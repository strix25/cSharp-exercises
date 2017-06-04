using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    interface IProdajni
    {
        void dodajPopotnika(Termin odhod, Popotnik popotnik);
        void odstraniPopotnika(Termin odhod, Popotnik popotnik);
        Termin VrniOdhod(int indeks);
        int VrniSteviloOdhodov();
    }
}
