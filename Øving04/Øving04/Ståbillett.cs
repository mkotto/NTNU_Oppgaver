using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
    public class Ståbillett : Billett
    {
        public Ståbillett(String tribunenavn, double p) : base(tribunenavn, p) { }
        public override String ToString() { return base.ToString(); }
        //public double pris { get; set; }
    }
}
