using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ØVING01 OPPGAVE02
 * MAJRBEK KOTTO
 */
namespace Øving03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> sListe = new List<Person>();
                sListe.Add(new Person("Ola", 245000));
                sListe.Add(new Person("Chris", 125000));
                sListe.Add(new Person("Zara", 4478999));
                
                Formueliste_1 f = new Formueliste_1(sListe);
                /*tester registrerNyPerson() metoden*/
                f.registrerNyPerson(new Person("Majrbek", 251000));
                f.registrerNyPerson(new Person("Liza", 252115));

                Console.WriteLine("Usortert:");
                Console.WriteLine(f.ToString());
                Console.WriteLine("\nSortert: ");
                /*tester sorteringsmetoden*/
                Formueliste_1 sortert = new Formueliste_1(f.sorter());
                Console.WriteLine(sortert.ToString());
                /*tester rikest() metoden*/
                Console.WriteLine("\nRikeste person: " + sortert.getRikest());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally {
                Console.WriteLine("Programmet avsluttes...");
            }
        }
    }
}