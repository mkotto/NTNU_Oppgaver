using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innlevering02
{
    class Program
    {
        static void Main(string[] args)
        {
            Brøk a = new Brøk(27, 3);
            Console.WriteLine("Brøk a: " + a.ToString());
            Console.WriteLine("Største fellesfaktor til brøk a: " + a.finnStørsteFellesFaktor(a.Teller, a.Nevner));
            a.forkorteBrøk();
            Console.WriteLine("Brøk a etter forkortelse: " + a.ToString()+"\n");

            Brøk b = new Brøk(16, 12);
            Console.WriteLine("Brøk b: " + b.ToString());
            Console.WriteLine("Største fellesfaktor til brøk b: " + b.finnStørsteFellesFaktor(b.Teller, b.Nevner));
            b.forkorteBrøk();
            Console.WriteLine("Brøk b etter forkortelse: " + b.ToString()+"\n");
            /*
             * Tester multiplikasjon
             */
            Console.WriteLine("Multiplikasjon av to brøk: ");
            Brøk c = a.multipliser(b);
            Console.WriteLine(c.ToString());

            /*Tester andre konstruktører*/

            Brøk d = new Brøk(a);
            Console.WriteLine("\nTesting av andre konstrukt\n"+d.ToString());
            Brøk e = new Brøk();
            Console.WriteLine(e.ToString());
            Brøk f = new Brøk(7);
            Console.WriteLine(f.ToString());

            MessageBox.Show("Programmet avsluttes...");
        }
    }
}
