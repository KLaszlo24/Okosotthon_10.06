using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;

        private int maradtIdo;
        private List<double> homersekletAdatok;

        public double JelenlegiHomerseklet { get => jelenlegiHomerseklet; private set => jelenlegiHomerseklet = value; }
        public double CelHomerseklet { get => celHomerseklet; private set => celHomerseklet = value; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            JelenlegiHomerseklet = 21.0;
            this.celHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string ertek = parancs.Substring("BEALLIT_HOMERSEKLET:".Length);

                if (double.TryParse(ertek, out double homerseklet))
                {
                    this.celHomerseklet = homerseklet;
                }
            }
        }

        public override string AllapotJelentes()
        {
           return $"A jelenlegi hőmérséklet: {JelenlegiHomerseklet}";
        }

        protected override bool OnTesztFuttatasa()
        {
            if (this.celHomerseklet >= 5.0 && this.celHomerseklet <= 35.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IdozitestBeallit(int perc)
        {
            maradtIdo = perc;

           
            while (maradtIdo > 0 && JelenlegiHomerseklet < CelHomerseklet)
            {
                JelenlegiHomerseklet += 1;
                maradtIdo--;

                homersekletAdatok.Add(JelenlegiHomerseklet);
            }
        }

        public int GetMaradtIdo()
        {
            return maradtIdo;
        }

        public string StatisztikatKeszit()
        {
            if (homersekletAdatok.Count == 0)
            {
                return "Nincs rendelkezésre álló hőmérsékleti adat.";
            }

            double minimum = homersekletAdatok[0];
            double maximum = homersekletAdatok[0];
            double osszeg = 0;

            foreach (double homerseklet in homersekletAdatok)
            {
                if (homerseklet < minimum)
                    minimum = homerseklet;

                if (homerseklet > maximum)
                    maximum = homerseklet;

                osszeg += homerseklet;
            }

            double atlag = osszeg / homersekletAdatok.Count;

            return
                $"Hőmérsékleti statisztika:\n" +
                $"Mérések száma: {homersekletAdatok.Count}\n" +
                $"Minimum: {minimum:F1} °C\n" +
                $"Maximum: {maximum:F1} °C\n" +
                $"Átlag: {atlag:F1} °C";
        }
    }
}
