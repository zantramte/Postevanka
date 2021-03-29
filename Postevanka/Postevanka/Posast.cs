using System;
using System.Collections.Generic;
using System.Text;

namespace Postevanka
{
    public class Posast
    {
        public static int Moja_Izbira, Zmnozek, Prvo, Drugo, Cifra;
        public static Random Nakljucno = new Random();
        private static List<int> Stevilke_kopija = new List<int>();
        public static List<int> Stevilke = new List<int>();

        public static bool Preveri_ustreznost()
        {
            if (Moja_Izbira == Zmnozek)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static int Vrni_Prvo()
        {
            Prvo = Nakljucno.Next(0, 11);
            return Prvo;
        }

        public static int Vrni_Drugo()
        {
            Drugo = Nakljucno.Next(0, 11);
            return Drugo;
        }

        public static void Polni()
        {
            Zmnozek = Prvo * Drugo;
            Stevilke_kopija.Clear();
            Stevilke.Clear();
            Stevilke.Add(Zmnozek);

            for (int indeks = 0; indeks < 101; indeks++)
            {
                Stevilke_kopija.Add(indeks);

                if (indeks == Zmnozek)
                {
                    Stevilke_kopija.RemoveAt(indeks);
                }
            }
            
            for (int indeks = 0; indeks < 9; indeks++)
            {               
                Cifra = Nakljucno.Next(Stevilke_kopija.Count);
                Stevilke.Add(Cifra);
                Stevilke_kopija.RemoveAt(Cifra);
            }
        }
    }
}
