using System;

namespace Banksystem
{
    // Klass för att representera en kund
    public class Kunde
    {
        public string Användarnamn { get; } // Attribut för användarnamn
        public string PINKod { get; } // Attribut för PIN-kod
        private Konto konto; // Attribut för konto

        // Konstruktor för att initialisera en kund
        public Kunde(string användarnamn, string pinKod, string kontonamn, decimal initialSaldo)
        {
            Användarnamn = användarnamn;
            PINKod = pinKod;
            konto = new Konto(kontonamn, Guid.NewGuid().ToString(), initialSaldo); // Skapa ett konto med unikt kontonummer
        }

        // Metod för att visa saldo
        public void VisaSaldo()
        {
            konto.VisaSaldo();
        }

        // Metod för att sätta in pengar
        public void SättaIn()
        {
            Console.Write("Ange belopp att sätta in: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
            {
                konto.SättaIn(belopp);
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp. Var god ange ett positivt nummer.");
            }
        }

        // Metod för att ta ut pengar
        public void TaUt()
        {
            Console.Write("Ange belopp att ta ut: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
            {
                konto.TaUt(belopp);
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp. Var god ange ett positivt nummer.");
            }
        }

        // Metod för att överföra pengar
        public void Överför()
        {
            Console.Write("Ange belopp att överföra: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal belopp) && belopp > 0)
            {
                // Här skulle vi be användaren att ange kontonummer för mottagaren
                Console.Write("Ange mottagarens användarnamn: ");
                string mottagarNamn = Console.ReadLine();

                // Hitta mottagaren (i det här exemplet finns det inga samlingar)
                // Vi kan för enkelhetens skull bara anta att mottagaren är en av de definierade kunderna
                Konto mottagare = HittaKonto(mottagarNamn);

                if (mottagare != null)
                {
                    konto.Överför(belopp, mottagare); // Överför beloppet
                }
                else
                {
                    Console.WriteLine("Ingen kund med det användarnamnet hittades.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp. Var god ange ett positivt nummer.");
            }
        }

        // Metod för att hitta konto baserat på användarnamn (här är en enkel version)
        private Konto HittaKonto(string användarnamn)
        {
            // Här skulle vi normalt söka igenom alla kunder för att hitta rätt konto.
            // Eftersom vi inte har någon samling för det just nu, återgår vi till null
            if (användarnamn == "Användare1")
            {
                return new Konto("Privatkonto", Guid.NewGuid().ToString(), 1000); // Skapa ett nytt konto för demonstration
            }
            else if (användarnamn == "Användare2")
            {
                return new Konto("Sparkonto", Guid.NewGuid().ToString(), 2000); // Skapa ett nytt konto för demonstration
            }
            else if (användarnamn == "Användare3")
            {
                return new Konto("ISK-konto", Guid.NewGuid().ToString(), 1500); // Skapa ett nytt konto för demonstration
            }
            return null; // Ingen kund hittades
        }
    }
}
