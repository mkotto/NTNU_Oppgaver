using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving03
{
    class Formueliste_1
    {
        private Person[] personListe { get; set; }
        private int stdNUM = 100;
        public int teller { get; set; }

        public Formueliste_1() {
            personListe = new Person[stdNUM];
            teller = 0;
        }

        public Formueliste_1(int i)
        {
            personListe = new Person[i];
            teller = 0;
        }

        public Formueliste_1(Formueliste_1 f) {
            personListe = f.personListe;
            teller = f.teller;            
        }

        public bool registrerNyPerson(Person p)
        {
            bool registrert = false;
            try {
                if (teller < personListe.Length){
                    personListe[teller] = p;
                    registrert = true;
                    ++teller;
                }else{
                    throw new Exception("Tabellen er full!");
                }
            } catch(Exception e){
                Console.WriteLine("Error: "+e.Message);
            }
            return registrert;
        }

        public Person getRikest() {
            Person temp = new Person("", 0);
            if (!erTom()) {
                for(int i = 0; i < teller; i++)
                {
                    if (personListe[i].Formue > temp.Formue) { temp = personListe[i]; }
                }
            }else { throw new Exception("Ingenting å vise!"); return null; }
            return temp;
        }

        public Person[] sorter()
        {
            Person[] tempTab = this.personListe;
            Person temp = new Person("", 0);
            for (int i = 0; i < teller; i++)
            {
                for (int j = 0; j < teller - 1; j++)
                {
                    if (tempTab[j].Formue < tempTab[j + 1].Formue)
                    {
                        temp = tempTab[j + 1];
                        tempTab[j + 1] = tempTab[j];
                        tempTab[j] = temp;
                    }
                }
            }
            return tempTab;
        }

        override public String ToString()
        {
            String temp = "";
            if(teller != 0)
            {
                foreach (Person p in personListe) {
                    temp += (p);
                }
            }
            return temp;
        }
        public bool erTom() { return teller == 0; }
        public void visAntall() { Console.WriteLine(this.teller); }
    }
}
