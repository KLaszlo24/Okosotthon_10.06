using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        private bool zartE;
        private string pinKod;

        public bool ZartE { get => zartE; private set => zartE = value; }

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = "alma";
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            throw new NotImplementedException();
        }


        public override string AllapotJelentes()
        {
            throw new NotImplementedException();
        }

        protected override bool OnTesztFuttatasa()
        {
            throw new NotImplementedException();
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            throw new NotImplementedException();
        }


    }
}
