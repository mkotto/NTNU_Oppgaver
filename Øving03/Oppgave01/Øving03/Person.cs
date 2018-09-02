using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving03
{
    class Person
    {
        public Person(String navn, int formue)
        {
            Navn = navn;
            Formue = formue;
        }
        /* Properties */
        public String Navn
        {
            get;
            private set;
        }

        public int Formue
        {
            get;
            private set;
        }
        public override string ToString()
        {
            return Navn + " " + Formue.ToString()+"\n";
        }
    }
}
