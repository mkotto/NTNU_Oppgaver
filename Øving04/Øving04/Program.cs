using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Øving04
{
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

            double solgtFor = feltA.SolgtFor() + feltB.SolgtFor() + kafeen.SolgtFor();
            res += "Solgt for: " + solgtFor + " kroner\n";

            MessageBox.Show(res, "Tribuner", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            //           Console.WriteLine();
        }

    }
}
