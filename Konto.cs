using System;

namespace Banksystem
{
    // Klass för att representera ett konto
    public class Konto
    {
        public string Namn { get; }  // Attribut för kontots namn
        public string KontoNummer { get; } // Attribut för kontonummer
        public decimal Saldo { get; private set; }  // Attribut för kontots saldo

        // Konstruktor för att initialisera ett konto
        public Konto(string namn, string kontoNummer, decimal initialSaldo)
        {
            Namn = namn;
            KontoNummer = kontoNummer;
            Saldo = initialSaldo;
        }

        // Metod för att sätta in pengar
        public void SättaIn(decimal belopp)
        {
            Saldo += belopp;
            Console.WriteLine($"{belopp} SEK har satts in på {Namn}. Nytt saldo: {Saldo} SEK");
        }

        // Metod för att ta ut pengar
        public void TaUt(decimal belopp)
        {
            if (belopp <= Saldo)
            {
                Saldo -= belopp;
                Console.WriteLine($"{belopp} SEK har tagits ut från {Namn}. Nytt saldo: {Saldo} SEK");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo.");
            }
        }

        // Metod för att visa saldo
        public void VisaSaldo()
        {
            Console.WriteLine($"Saldo för {Namn} (Konto: {KontoNummer}): {Saldo} SEK");
        }

        // Metod för att överföra pengar
        public void Överför(decimal belopp, Konto mottagare)
        {
            if (belopp <= Saldo)
            {
                Saldo -= belopp; // Minska saldo från avsändaren
                mottagare.SättaIn(belopp); // Sätta in belopp på mottagarens konto
                Console.WriteLine($"{belopp} SEK har överförts till {mottagare.Namn}. Nytt saldo: {Saldo} SEK");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo för överföring.");
            }
        }
    }
}
