using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving03
{
    class Formueliste_1
    {
        public List<Person> personListe;
        private int stdNUM = 100;
        public Formueliste_1()
        {
            personListe = new List<Person>(stdNUM);
        }
        public Formueliste_1(int i) {
            personListe = new List<Person>(i);
        }
        public Formueliste_1(List<Person> p) {
            personListe = p;

        }
        public bool registrerNyPerson(Person p)
        {
            if(p == null)
            {
                return false;
                throw new Exception("Ugyldig objekt!");
            }
            personListe.Add(p);
            return true;
        }
        override public String ToString()
        {
            String temp = "";
            foreach (Person p in this.personListe) {
                temp += p.ToString()+"\n";
            }
            if(temp == "") { throw new Exception("Ingenting å vise!"); }
            return temp;
        }
        public Person getRikest()
        {
            Person rikest = new Person("***tom***", 0);
            foreach (Person p in personListe) {
                if (p.Formue > rikest.Formue) { rikest = p; }
            }
            return rikest;
        }
        public List<Person> sorter()
        {

            List<Person> sortertListe = this.personListe ;
            //sortertListe.Sort();
            sortertListe.Sort((a, b) => -1 * a.CompareTo(b));
            return sortertListe;
        }
        public void printSortert() {
            personListe.Sort();
            foreach(Person p in personListe)
            {
                Console.WriteLine(p);
            }
        }
        public void printInfo()
        {
            foreach(Person p in personListe)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
