using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
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
