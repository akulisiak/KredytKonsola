using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KredytKonsola
{
    internal class Kredyt
    {
        private double kwotaPoczatkowa;
        private double oprocentowanie = 7.77;
        private double rata;
        private double pozostalaKwota;
        private double aktualneOdsetki;
        private int iloscRat;
        private double sumaOdsetek = 0;

        public Kredyt(double kwotaPoczatkowa, int rata)
        {
            this.kwotaPoczatkowa = kwotaPoczatkowa;
            this.rata = rata;
        }

        public void AlgorytmObliczajacy()
        {
            aktualneOdsetki = kwotaPoczatkowa;
            pozostalaKwota = kwotaPoczatkowa;
            while (aktualneOdsetki > 0)
            {
                if (pozostalaKwota == 0) break;
                aktualneOdsetki = pozostalaKwota * ((oprocentowanie / 100) / 12);
                aktualneOdsetki = Math.Round(aktualneOdsetki, 2);

                if (pozostalaKwota + aktualneOdsetki < rata)
                {
                    rata = (aktualneOdsetki + pozostalaKwota);
                }

                pozostalaKwota = pozostalaKwota - (rata - aktualneOdsetki);
                pozostalaKwota = Math.Round(pozostalaKwota, 1);

                sumaOdsetek = sumaOdsetek + aktualneOdsetki;
                iloscRat++;
            }
            Console.WriteLine($"pozostala kwota: {pozostalaKwota}zł| aktualne odsetki: {aktualneOdsetki}zł| ilosc rat: {iloscRat}");
            Console.WriteLine("suma odsetek: " + Math.Round(sumaOdsetek, 2));
        }
    }
}