using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosKozpontRiaszto : OkosEszkoz, IStatisztika, IHangjelzo, IIdozitheto
    {

        private int maradtIdo;
        private int veszjelzesekSzama;
        private int csipogasokSzama;
        private bool aktiv;
        
        public void Csipog(int hosszu)
        {
            csipogasokSzama++;
            Console.WriteLine($"A riasztó {hosszu} másodpercig csipog.");
        }

        public int GetMaradtIdo()
        {
            return maradtIdo;
        }

        public void IdozitestBeallit(int perc)
        {
            maradtIdo = perc;
            Console.WriteLine($"Az időzítő {perc} percre lett beállítva");
        }

        public string StatisztikatKeszit()
        {
            return
                $"Központi riasztó statisztikája:\n" +
                $"Vészjelzések száma: {veszjelzesekSzama}\n" +
                $"Csipogások száma: {csipogasokSzama}\n" +
                $"Hátralévő idő: {maradtIdo} perc\n" +
                $"Aktív: {(aktiv ? "igen" : "nem")}";
        }

        public void VeszjelzesInditasa()
        {
            aktiv = true;
            veszjelzesekSzama++;

            Console.WriteLine("A központi riasztó aktiválódott!");
        }
    }
}
