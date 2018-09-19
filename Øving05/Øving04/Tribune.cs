using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øving04
{
    abstract public class Tribune
    {
        public Tribune(string navn, double pris, int kap)
        {
            Navn = navn;
            Pris = pris;
            Kapasitet = kap;
            inntekt = 0;
        }

        public virtual double Barnepris { get { return this.Pris / 2; } set { } }
        public string Navn { get; private set; }
        public double Pris { get; private set; }
        public int Kapasitet { get; private set; }
        abstract public Billett[] KjøpBillett(int antVoksne, int antBarn);//
        public string visNavn() { return this.Navn; }

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
        override public Billett[] KjøpBillett(int antVoksne, int antBarn)
        {
            KeyValuePair<bool, Ståbillett> kanSelge = this.SelgPlasser(antBarn + antVoksne);
            int antall = antBarn + antVoksne;
            if (kanSelge.Key)
            {
                Billett[] temp = new Ståbillett[antall];
                for (int i = 0; i < antVoksne; i++)
                {
                    /*legger til billetter for voksne*/
                    //SelgPlasser(antVoksne - i);
                    temp[i] = new Ståbillett(this.Navn, this.Pris);
                    inntekt += temp[i].pris;

                }
                for (int j = antVoksne; j < temp.Length; j++)
                {
                    /* legger til billetter for barn med barnepris */
                    temp[j] = new Ståbillett(this.Navn, this.Barnepris);
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
        //OPPGAVE D start
        public Billett[] KjøpBillett(String[] listeVoksne, String[] listeBarn)
        {
            KeyValuePair<bool, Ståbillett> kanSelge = this.SelgPlasser(listeVoksne.Length + listeBarn.Length);
            int antall = listeBarn.Length + listeVoksne.Length;
            if (kanSelge.Key)
            {
                Billett[] temp = new Ståbillett[antall];
                for (int i = 0; i < listeVoksne.Length; i++)
                {
                    /*legger til billetter for voksne*/
                    //SelgPlasser(antVoksne - i);
                    temp[i] = new Ståbillett(this.Navn, this.Pris);
                    inntekt += temp[i].pris;

                }
                for (int j = listeVoksne.Length; j < temp.Length; j++)
                {
                    /* legger til billetter for barn med barnepris */
                    temp[j] = new Ståbillett(this.Navn, this.Barnepris);
                    inntekt += temp[j].pris;
                }
                Console.WriteLine("[" + this.Navn + "]: Kvittering: " + antall + " billetter solgt");
                return temp;
            }
            else
            {
                Console.WriteLine("[" + this.Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges");
                return null;
            }

        }
        //OPPGAVE D end

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

        override public Billett[] KjøpBillett(int antVoksne, int antBarn) {
            bool kanSelges = this.SelgPlasser(antBarn + antVoksne).Key;
            Sittebillett n = this.SelgPlasser(antBarn+antVoksne).Value;
            int antall = antBarn + antVoksne;
            if (kanSelges) {
                Billett[] temp = new Sittebillett[antall];
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
        // OPPGAVE D start

        virtual public Billett[] KjøpBillett(String[] listeVoksne, String[] listeBarn)
        {
            bool kanSelges = false;
            if(listeBarn != null || listeVoksne != null) {
                if(listeVoksne.Length != 0 || listeBarn.Length != 0) {
                kanSelges =  this.SelgPlasser(listeBarn.Length + listeVoksne.Length).Key;
            }
            }
            int antall = 0;
            if (listeVoksne != null)    { antall += listeVoksne.Length;  }
            if (listeBarn != null)      { antall += listeBarn.Length;    }
            
            Sittebillett n = this.SelgPlasser( antall ).Value;
            //int antall = listeBarn.Length + listeVoksne.Length;
            if (kanSelges)
            {
                Billett[] temp = new Sittebillett[antall];
                int teller = n.plassnr + 1;
                for (int i = 0; i < listeVoksne.Length; i++)
                {
                    Sittebillett b = new Sittebillett(Navn, this.Pris, n.rad, teller);
                    temp[i] = b;
                    inntekt += Pris;
                }
                for (int j = listeVoksne.Length; j < temp.Length; j++)
                {
                    Sittebillett barneBillett = this.SelgPlasser(listeBarn.Length).Value;
                    temp[j] = barneBillett;
                    inntekt += Barnepris;
                }
                Console.WriteLine("[" + this.Navn + "]: Kvittering: " + antall + " billetter solgt");
                return temp;
            }
            else
            {
                if(antall > 0)
                    Console.WriteLine("[" + this.Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges på same rad, prøv et nytt tall.");
                else if(antall == 0) { Console.WriteLine("["+this.Navn+"] Bestillingensliste er tom, ingen kjøp er registrert, prøv igjen"); }
                return null;
            }
        }

        // OPPGAVE D end

        private KeyValuePair<bool, Sittebillett> SelgPlasser(int antall)
        {
            int kapPrRad = Kapasitet / AntallRader;
            int i = 0;
            while (i < AntallRader && antallSolgtPrRad[i] + antall > kapPrRad) i++;
            if (i < AntallRader)
            {
                antallSolgtPrRad[i] += antall;
                return new KeyValuePair<bool, Sittebillett>(true, new Sittebillett(this.Navn, this.Pris, i, antallSolgtPrRad[i]));
            }
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
        int rad, plass, antPrRad;

        public VIPtribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap, antRader)
        {
            antPrRad = Kapasitet / AntallRader;
            tilskuer = new string[AntallRader, antPrRad];
            rad = plass = 0;
        }

        /* OPPGAVE D*/
        public override Billett[] KjøpBillett(string[] listeVoksne, string[] listeBarn)
        {


            leggTilTilskuer(listeVoksne);
            leggTilTilskuer(listeBarn);

            return base.KjøpBillett(listeVoksne, listeBarn);
        }
        private void leggTilTilskuer(String[] s) {
            if (s == null) {
               // Console.WriteLine("Ingenting å legge til...");
            }
            else {
                for (int i = 0; i < s.Length; i++)
                {
                    if (kanSelges(i))
                    {
                        tilskuer[rad, plass] = s[i];
                        plass++;
                        if (plass == antPrRad - 1)
                        {
                            plass = 0;
                            rad++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("["+this.Navn+"]: ***Utsolgt***Kan ikke selge billett til følgende navn i listen: " + s[i]);
                    }
                }
            }
        }
        private bool kanSelges(int i) {
            bool temp = false;
            if (i < antPrRad && rad < AntallRader) {
                temp = true;
            }
            return temp;
        }
        public override string ToString()
        {
            String temp = this.Navn + "\nTislkuere";
            for (int i = 0; i < antPrRad; i++) {
                for (int j = 0; j < AntallRader; j++) {
                    temp +=tilskuer[j, i];
                    if(i != antPrRad-1)
                    temp += " | ";
                }
            }

            if (temp == "") return "ingenting å vise";
            else { return temp; }
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