using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{

   /* ØVING05 : Oppgave A
    * Vi setter Billett superklassen som abstract. Grunnen til det er at i denne øvingnen brukte vi superklassen 
    * kun til å videreutvikle flere barneklasser. Superklassen blir ikke brukt verken i mainmetoden for opprette 
    * et objekt eller til å samling/tabbel i Tribune barneklassene.     
    * Jeg ville også sette ToString() metoden til abstract siden den blir overidet i barneklassene, men kompilatoren klager på syntaxfeil siden ToString() er arvet fra Object klassen som en standart funksjon.
    */
    public class Billett
    {
        String  tribunenavn { get; set; }
        public double  pris        { get; set; }
        public  Billett(String tribunenavn, double pris) {
            this.tribunenavn = tribunenavn;
            this.pris = pris;
        }

        virtual public String ToString() { return "navn: " +this.tribunenavn + " / pris: " + this.pris + ",-"; }
        
    }
}
