using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
    public class Sittebillett : Billett
    {
        public int rad     { get; set; }
        public int plassnr { get; set; }
        public Sittebillett(String tribunenavn, double pris, int rad, int plassnr) : base(tribunenavn, pris){
            this.rad        = rad;
            this.plassnr    = plassnr;
        }
        public override string ToString()
        {
            return base.ToString() + " / rad: " + this.rad + " / plassnummer: " + this.plassnr;
        }
    }
}
