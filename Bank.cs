using System;

namespace Banksystem
{
    // Klass för att hantera banksystemet
    public class BankSystem
    {
        // Deklaration av tre kunder
        private Kunde kund1;
        private Kunde kund2;
        private Kunde kund3;

        // Konstruktor för att initialisera kunder
        public BankSystem()
        {
            // Skapa kunder med användarnamn, PIN-kod, kontotyp och initialsaldo
            kund1 = new Kunde("Användare1", "1234", "Privatkonto", 1000);
            kund2 = new Kunde("Användare2", "2345", "Sparkonto", 2000);
            kund3 = new Kunde("Användare3", "3456", "ISK-konto", 1500);
        }

        // Metod för att köra banksystemet
        public void Kör()
        {
            bool körning = true; // Flagga för att kontrollera om programmet ska fortsätta köra

            while (körning)
            {
                Console.WriteLine("\n--- Välkommen till Banksystemet ---");
                Console.Write("Ange ditt användarnamn: ");
                string användarnamn = Console.ReadLine(); // Läs in användarnamn
                Console.Write("Ange din PIN-kod: ");
                string pinKod = Console.ReadLine(); // Läs in PIN-kod

                // Kontrollera om användarnamn och PIN-kod är korrekta
                Kunde inloggadKund = Inloggning(användarnamn, pinKod);
                if (inloggadKund != null) // Om inloggning lyckades
                {
                    while (true)
                    {
                        // Visa alternativ till användaren
                        Console.WriteLine("\n1. Kontrollera saldo");
                        Console.WriteLine("2. Sätta in pengar");
                        Console.WriteLine("3. Ta ut pengar");
                        Console.WriteLine("4. Överföra pengar");
                        Console.WriteLine("5. Stäng applikationen");
                        Console.Write("Välj ett alternativ: ");

                        string input = Console.ReadLine(); // Läs in användarens val

                        // Välj åtgärd baserat på användarens val
                        switch (input)
                        {
                            case "1":
                                inloggadKund.VisaSaldo(); // Visa saldo
                                break;
                            case "2":
                                inloggadKund.SättaIn(); // Sätta in pengar
                                break;
                            case "3":
                                inloggadKund.TaUt(); // Ta ut pengar
                                break;
                            case "4":
                                inloggadKund.Överför(); // Överföra pengar
                                break;
                            case "5":
                                körning = false; // Avsluta programmet
                                Console.WriteLine("Applikationen stängs.");
                                return; // Avsluta metoden
                            default:
                                Console.WriteLine("Ogiltigt alternativ. Vänligen försök igen.");
                                break;
                        }
                    }
                }
                else // Om inloggning misslyckades
                {
                    Console.WriteLine("Ogiltigt användarnamn eller PIN-kod. Försök igen.");
                }
            }
        }

        // Metod för att logga in
        private Kunde Inloggning(string användarnamn, string pinKod)
        {
            // Kontrollera varje kund
            if (kund1 != null && kund1.Användarnamn == användarnamn && kund1.PINKod == pinKod)
                return kund1; // Returnera inloggad kund
            if (kund2 != null && kund2.Användarnamn == användarnamn && kund2.PINKod == pinKod)
                return kund2; // Returnera inloggad kund
            if (kund3 != null && kund3.Användarnamn == användarnamn && kund3.PINKod == pinKod)
                return kund3; // Returnera inloggad kund

            return null; // Ingen kund hittades
        }
    }
}
