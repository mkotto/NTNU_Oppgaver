
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innlevering_01_Oppgave_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int tall1, tall2, res = 0;
            String op, temp, regneart;
            bool gjenta = true;


            while (gjenta)//applikasjonen stopper når boolske gjenta variabelen endres til false
            {
                regneart = "";
                Console.Write("Skriv første tallet: ");
                temp = Console.ReadLine();
                tall1 = Int32.Parse(temp);

                Console.Write("Skriv andre tallet: ");
                temp = Console.ReadLine();
                tall2 = Int32.Parse(temp);

                Console.Write("Skriv regneart: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "+":
                        res = tall1 + tall2;
                        regneart = "+";
                        break;
                    case "-":
                        res = tall1 - tall2;
                        regneart = "-";
                        break;

                    default:
                        Console.WriteLine("Ugyldig regneart, handlingen er avbrudt");
                        break;
                }

                
                


                if (regneart == "+" || regneart == "-" && regneart!="")
                {

                    if (regneart == "+") { res = tall1 + tall2; }
                    else if (regneart == "-") { res = tall1 - tall2; }


                    Console.WriteLine(tall1 + regneart + tall2 + " = " + res);
                }
                else
                {
                    //Console.WriteLine("Feil ");
                }
                bool YN = true;
                //endres til false når N eller Y er gitt som svar
                //YN variabelen endres til false kun når brukeren har velget riktige alternativ
                while (YN) {

                    Console.Write("Prøve igjen?[Y|N]: ");
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "Y":
                        case "y":
                            Console.WriteLine("Tilbake til start...\n");
                            YN = false;
                            break;
                        case "n":
                        case "N":
                            Console.WriteLine("Applikasjonen avsluttes...");
                            gjenta = false;
                            YN = false;
                            break;
                        default:
                            Console.WriteLine("Ugyldig svar, prøv igjen");
                            break;
                    }
                }


            }

        }
    }
}