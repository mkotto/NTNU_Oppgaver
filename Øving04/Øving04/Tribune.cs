using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
    public class Tribune
    {
        public Tribune(string navn, double pris, int kap)
        {
            Navn = navn;
            Pris = pris;
            Kapasitet = kap;
            inntekt = 0;
        }

        public  virtual double Barnepris { get { return this.Pris / 2; } set { } }
        public  string  Navn    { get; private set; }
        public  double  Pris { get; private set; }
        public  int     Kapasitet { get; private set; }
        //public virtual void Rabatt() { this.Pris = this.Pris / 2; }
        /* OPPGAVE E: JEG LEGGER TIL EN LOKAL VARIABEL I SUPERKLASSE SOM ER TILGJENGELIG FOR ANDRE METODER. I KJØPBILLETT METODEN ØKER INNTEKT VARIABELEN BASERT PÅ ANTVOKSNE OG ANTBARN VARIABLENE*/
        protected double  inntekt;

        virtual public double SolgtFor()
        {
            return inntekt;
        }
        public virtual int AntallSolgtePlasser
        {
            get
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return Navn + " har kapasitet " + Kapasitet + " og pris " + Pris + " kroner.";
        }
    }


    public class Ståtribune : Tribune
    {
        private int antallSolgtePlasser;
        public Ståtribune(string navn, double pris, int kap )
            : base(navn, pris, kap)
        {
            antallSolgtePlasser = 0;
        }
        public override int AntallSolgtePlasser
        {
            get
            {
                return antallSolgtePlasser;
            }
        }
        /* OPPGAVE D */
        public Ståbillett[] KjøpBillett(int antVoksne, int antBarn)
        {
            KeyValuePair<bool, Ståbillett> kanSelge = this.SelgPlasser(antBarn + antVoksne);
            int antall = antBarn + antVoksne;
            if (kanSelge.Key)
            {
                Ståbillett[] temp = new Ståbillett[antall];
                for (int i = 0; i < antVoksne; i++)
                {
                    /*legger til billetter for voksne*/
                    //SelgPlasser(antVoksne - i);
                    temp[i] = new Ståbillett(this.Navn, this.Pris);
                    /* OPPGAVE D: ØKER INNTEKTENE MED BARNE PRIS MED HVER REGISTRERTE VOKSNEBILLETT*/
                    inntekt += temp[i].pris;

                }
                for (int j = antVoksne; j < temp.Length; j++)
                {
                    /* legger til billetter for barn med barnepris */
                    temp[j] = new Ståbillett(this.Navn, this.Barnepris);
                    /* OPPGAVE D: ØKER INNTEKTENE MED BARNE PRIS MED HVER REGISTRERTE BARNEBILLETT*/
                    inntekt += temp[j].pris;
                }
                Console.WriteLine("[" + this.Navn + "]: Kvittering: " + antall + " billetter solgt");
                return temp;
            }
            else {
                Console.WriteLine("[" + this.Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges");
                return null;
            }
            
        }

        private KeyValuePair<bool, Ståbillett> SelgPlasser(int antall)
        {
            
            if (AntallSolgtePlasser + antall <= Kapasitet)
            {
                antallSolgtePlasser += antall;
                return new KeyValuePair<bool, Ståbillett>(true, new Ståbillett(this.Navn, this.Pris));
            }
            else return new KeyValuePair<bool, Ståbillett>(false, new Ståbillett(this.Navn, this.Pris));
        }
    }

    public class Sittetribune : Tribune
    {
        private int[] antallSolgtPrRad;

        public Sittetribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap)
        {
            AntallRader = antRader;
            antallSolgtPrRad = new int[AntallRader];
            for (int i = 0; i < AntallRader; i++) antallSolgtPrRad[i] = 0;
        }

        public int AntallRader
        {
            get;
            private set;
        }

        public override int AntallSolgtePlasser
        {
            get
            {
                int total = 0;
                for (int i = 0; i < AntallRader; i++) total += antallSolgtPrRad[i];
                return total;
            }
        }
        /* OPPGAVE D*/
        public Sittebillett[] KjøpBillett(int antVoksne, int antBarn) {
            bool kanSelges = this.SelgPlasser(antBarn + antVoksne).Key;
            Sittebillett n = this.SelgPlasser(antBarn+antVoksne).Value;
            int antall = antBarn + antVoksne;
            if (kanSelges) {
                Sittebillett[] temp = new Sittebillett[antall];
                int teller = n.plassnr + 1;
                for (int i = 0; i < antVoksne; i++)
                {
                    Sittebillett b = new Sittebillett(Navn, this.Pris, n.rad, teller);
                    temp[i] = b;
                    inntekt += Pris;
                }
                for (int j = antVoksne; j < temp.Length; j++)
                {
                    Sittebillett barneBillett = this.SelgPlasser(antBarn).Value;
                    temp[j] = barneBillett;
                    inntekt += Barnepris;
                }
                Console.WriteLine("[" + this.Navn + "]: Kvittering: " + antall + " billetter solgt");
                return temp;
            } else{
                
                Console.WriteLine("["+this.Navn+"]: Oppgitt antall ("+antall+ ") billetter kan ikke selges på same rad, prøv et nytt tall.");
                return null;
            }
        }
        /*METODEN BLE ENDRET TIL NY RETURN TYPE SOM HOLDER TO NYE DATATYPER ISTEDEN FOR EN ENKEL BOOL*/
        private KeyValuePair<bool, Sittebillett> SelgPlasser(int antall)
        {
            int kapPrRad = Kapasitet / AntallRader;
            int i = 0;
            while (i < AntallRader && antallSolgtPrRad[i] + antall > kapPrRad) i++;
            if (i < AntallRader)
            {
                antallSolgtPrRad[i] += antall;
                return new KeyValuePair<bool, Sittebillett>(true, new Sittebillett(this.Navn, this.Pris, i, antallSolgtPrRad[i]));
            }/*NÅR METODEN FINNER INGEN LEDIGE PLASSER GIR DEN NULL OBJEKT SOM RESULTAT I TILLEGG TI BOOLSKE FALSE VERDIEN*/
            else return new KeyValuePair<bool, Sittebillett>(false, null);

        }
        public override string ToString()
        {
            return base.ToString() + " Antall rader er " + AntallRader + ".";
        }
    }

    public class VIPtribune : Sittetribune
    {
        private string[,] tilskuer;

        public VIPtribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap, antRader)
        {
            int antPrRad = Kapasitet / AntallRader;
            tilskuer = new string[AntallRader, antPrRad];
        }

        public override double Barnepris
        {
            get
            {
                return base.Pris;
            }

            set
            {
                base.Barnepris = value;
            }
        }
    }
}