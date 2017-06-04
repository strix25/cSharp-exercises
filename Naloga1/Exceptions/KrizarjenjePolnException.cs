using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    public class KrizarjenjePolnException : Exception
    {
        public KrizarjenjePolnException(string message)
            : base(message)
        {
        }
    }
}
