using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
    public class Sortering
    {
        public delegate bool Sammenligner(Tribune a, Tribune b);
        public static void sorter(Tribune[] tabell, Sammenligner Sml)
        {
            Console.Write("\t");
            for (int i = 0; i < tabell.Length; i++)
            {
                Console.Write(tabell[i].visNavn());
                if (i < tabell.Length - 1)
                    Console.Write("  |  ");
            }
            for (int i = 0; i < tabell.Length; i++)
            {
                for (int j = 0; j < tabell.Length - 1; j++)
                {
                    if (Sml(tabell[j], tabell[j + 1])) bytt(tabell, j, j + 1);
                }
            }
            Console.WriteLine("\n  -> Liste etter sortering:");
            Console.Write("\t");
            for(int i = 0; i < tabell.Length; i++)
            {
                Console.Write(tabell[i].visNavn());
                if (i < tabell.Length - 1)
                    Console.Write("  |  ");
            }
            Console.WriteLine();
        }
        private static void bytt(Object[] tabell, int i, int j)
        {
            Object temp = tabell[i];
            tabell[i] = tabell[j];
            tabell[j] = temp;
        }
        /* Hjelpemetoder for oppgave e*/
        /*Sorter listen etter navn*/
        private static bool minSorteringEtterNavn(Tribune a, Tribune b) {
            bool temp = string.Compare(a.ToString(), b.ToString()) > 0;
            return temp;
        }
        public void sorterTabellenEtterNavn(Tribune[] t)
        {
            Console.WriteLine("***Sortering etter Tribunenavn***");
            Console.WriteLine("  -> Listen før sortering: ");
            Sammenligner sml = new Sammenligner(minSorteringEtterNavn);
            sorter(t, sml);
        }
        /* Sorterer listen etter hvor mye har solgt for*/
        private static bool minSorteringEtterInntekt(Tribune a, Tribune b)
        {
            /*Største tall vises først*/
            bool temp = a.SolgtFor() < b.SolgtFor();
            return temp;
        }

        public void sorterTabellenEtterInntekt(Tribune[] t)
        {
            Console.WriteLine("***Sortering etter hvor mye solgt for***");
            Console.WriteLine("  -> Listen før sortering: ");
            Sammenligner sml = new Sammenligner(minSorteringEtterInntekt);
            sorter(t, sml);
            Console.Write("  -> Bevis:\n\t");
            for (int i = 0; i < t.Length; i++) {
                Console.Write(t[i].Navn+": "+t[i].SolgtFor()+",-");
                if (i < t.Length - 1) { Console.Write("  | "); }
            }
        }
    }
}
