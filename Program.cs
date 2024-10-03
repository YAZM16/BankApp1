using System;

namespace Banksystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapa en instans av banksystemet
            BankSystem bankSystem = new BankSystem();
            bankSystem.Kör(); // Starta banksystemet
        }
    }
}
