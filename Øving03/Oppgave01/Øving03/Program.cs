using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*ØVING01 OPPGAVE01*/
namespace Øving03
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Formueliste_1 f = new Formueliste_1();
                Person a = new Person("Mike", 1554877);
                Person b = new Person("Kevin", 154477);
                Person c = new Person("Erik", 2224877);
                Person d = new Person("Liza", 250000);
                f.registrerNyPerson(a);
                f.registrerNyPerson(b);
                f.registrerNyPerson(c);
                f.registrerNyPerson(d);
                Console.WriteLine("Usortert liste: \n");
                Console.WriteLine(f.ToString());
                Person rikest = f.getRikest();
                Console.WriteLine("Rikeste person: " + rikest);
                Person[] sortert = f.sorter();
                Console.WriteLine("Sortert liste:\n");
                foreach (Person p in sortert)
                {
                    Console.Write(p);
                }
            } catch (Exception e) {
                Console.WriteLine("\nError: "+e.Message);
            } finally {
                Console.WriteLine("\nProgrammet avsluttes...");
            }
            
        }

    }
}
