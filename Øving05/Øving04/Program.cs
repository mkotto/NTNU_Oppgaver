using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Øving04
{
    /* MAJRBEK KOTTO
     * ØVING 05: POLIMORFI
     * 
     * OPPGAVE A): Vi setter Billett superklassen som abstract. Grunnen til det er at i denne øvingnen brukte vi superklassen 
     * kun til å videreutvikle flere barneklasser. Superklassen blir ikke brukt verken i mainmetoden for opprette et objekt eller til å samling/tabbel i Tribune barneklassene.     
     * Jeg ville også sette ToString() metoden til abstract siden den blir overidet i barneklassene, men kompilatoren klager på syntaxfeil siden ToString() er arvet fra Object klassen som en standart funksjon.
     * 
     * OPPGAVE B): Retur typene til alle subklassene av Tribune er: Sittebillett og Ståbillett. Begge klassene arver fra Billett superklassen. 
     * I C# er det tillatt å lagre forskjellige objekter i en tabell dersom alle objektene/klassene arver fra samme superklasse. 
     * Så i dette tilfelle endrer vi retur type til Billett[] uten å få noen kompileringsfeil.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Ståtribune feltA = new Ståtribune("Felt A", 50, 1000);
            Sittetribune feltB = new Sittetribune("Felt B", 250, 200, 20);
            VIPtribune kafeen = new VIPtribune("Kafe Fotball", 1000, 10, 2);
            String res = "";
            res += "Kapasitet på felt A: " + feltA.Kapasitet + "\n";
            res += "Kapasitet på felt B: " + feltB.Kapasitet + "\n";
            res += "Kapasitet i kafeen: " + kafeen.Kapasitet + "\n";


            feltA.KjøpBillett(10, 5);

            feltA.KjøpBillett(7, 25);

            feltB.KjøpBillett(5, 1);
            feltB.KjøpBillett(3, 4);
            feltB.KjøpBillett(10, 1);
            feltB.KjøpBillett(1, 2);
            feltB.KjøpBillett(1, 15);

            feltA.KjøpBillett(7, 70);
            feltA.KjøpBillett(300, 250);
            feltA.KjøpBillett(300, 150);
            feltA.KjøpBillett(500, 25);
            feltA.KjøpBillett(7, 25);
            String[] ttt = { "Egil", "Mike", "Fredrik", "Jarle" };
            String[] tt = { "Majrbek", "Arne" };
            String[] t = { "Egil" };
            kafeen.KjøpBillett(null, null);
            kafeen.KjøpBillett(tt, t);
            kafeen.KjøpBillett(tt, ttt);

            /* Oppgave e start */
            #region Oppgave E sortering/delegater
                Sortering sort = new Sortering();
                Tribune[] tab = {kafeen, feltA, feltB };
                sort.sorterTabellenEtterNavn(tab);
                Tribune[] tab1 = { feltA, kafeen,feltB };
                sort.sorterTabellenEtterInntekt(tab1);
            #endregion
            /* Oppgave e end */
            double solgtFor = feltA.SolgtFor() + feltB.SolgtFor() + kafeen.SolgtFor();
            res += "Solgt for: " + solgtFor + " kroner\n";

            MessageBox.Show(res, "Tribuner", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
