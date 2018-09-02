using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innlevering02
{
    class Brøk
    {
        private int teller, nevner;

        public int Teller
        {
            get { return teller; }
            set { teller = value; }
        }
        public int Nevner
        {
            get { return nevner; }
            set { nevner = value; }
        }
        /* start B 
         * ***DONE***
         * Lag fire konstruktører: En standardkonstruktør (sett teller lik 0 og nevner lik 1), en
         * konstruktør som lager en brøk av et heltall (telleren skal være heltallet, nevneren
         * skal være 1), en med to parametere (teller og nevner) og en som kopierer
         * innholdet av en annen brøk.
         */

                public Brøk()
                { // standard konstruktør
                    this.teller = 0;
                    this.nevner = 1;
                }

                public Brøk(int teller)
                {
                    this.teller = teller;
                    this.nevner = 1;
                }

                public Brøk(int teller, int nevner)
                {
                    this.teller = teller;

                    if (nevner != 0)//kontrollerer at 0 er ikke gitt i parameter, ellers setter konstruktøren nevner til 1
                        this.nevner = nevner;
                    else
                        this.nevner = 1;
                }

                public Brøk(Brøk kl)
                {
                    this.teller = kl.Teller;
                    this.nevner = kl.Nevner;
                }
        /*slutt B*/

        /*C 
         * ***DONE***
         *Lag en metode som finner verdien av brøken, dvs. den verdien vi får hvis vi deler
         *teller på nevner (husk å unngå heltallsdivisjon)
         */

        public double finnVerdien()
        {
            double res = (double)this.teller / (double)this.nevner;
            return res;
        }
        /*D 
         * ***DONE***
         * Lag en klassemetode som finner største felles faktor av to tall. Dette gjøres slik
         * for tallene a og b: c = a%b. Gjenta til c blir lik 0: a=b; b=c; c = a%b; Når c er blitt 0,
         * er største felles faktor b. Eksempel: Finn største felles faktor for tallene 15 og 40:
         * Løsning a=15, b=40, c=15%40=15. a=b=40, b=c=15, c=40%15=10. a=b=15,
         * b=c=10, c=15%10=5. a=b=10, b=c=5, c=10%5=0. Altså er største felles faktor lik
         * 5. Kontroll: 15=3*5, 40=2*2*2*5.
         */

        public int finnStørsteFellesFaktor(int a, int b)
        {
            int c = 1; //Vi starter med minste fellesfaktor som vi kan finne både i teller og nevner

            for (int i = 1; i <= a; i++) {
                if(a%i== 0 && b%i==0 && i > c) {
                    c = i;
                }
            }
            
            return c;
        }
        /*E
         * ***DONE***
         * Lag en objektmetode som forkorter en brøk ved å dele både teller og nevner med
         * deres største felles faktor.
         */

        public void  forkorteBrøk() {
            int temp = this.finnStørsteFellesFaktor(this.teller, this.nevner);
            this.teller = this.teller / temp;
            this.nevner = this.nevner / temp;
        }

        /*F 
         * ***DONE***
         * Lag en objektmetode som forkorter en brøk ved å dele både teller og nevner med
         * deres største felles faktor.
         */

        public Brøk multipliser(Brøk br) {
            int a = this.teller * br.teller;
            int b = this.nevner * br.nevner;

            Brøk temp = new Brøk(a, b);
            temp.forkorteBrøk();

            return temp;
        }

        /* G   
         * ***DONE***
         * Lag en ToString()-metode som skriver ut brøken på formen teller/nevner = verdi,for eksempel 1/4 = 0.25
         */

        public String ToString() {
            return (this.teller+ " / " + this.nevner + " = " + this.finnVerdien());
        }
    }
}
