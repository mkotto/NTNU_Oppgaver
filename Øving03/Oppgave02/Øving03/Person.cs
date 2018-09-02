using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Øving03
{
    class Person : IComparable, IEquatable<Person>
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
            return Navn + "  " + Formue.ToString();
        }
        /*
         * hjelpemetoder for å sammenligne objekter fra liste
         */
        public int CompareTo(Object obj)
        {

            if (obj is Person)
            {
                Person p = (Person)obj;
                return Formue.CompareTo(p.Formue);
            }
            return 2;
        }
        public bool Equals(Person obj)
        {
            return Formue == obj.Formue;
        }
    }
}
