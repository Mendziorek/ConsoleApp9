using System;
using System.Text;
using System.Threading.Channels;
using System.Xml;

namespace lyczydlo
{

    class calculator
    {
        static void Main(string[] args)
        {
        start:

            Console.WriteLine("Witaj w kalkulatorze wypłaty WOD-KAN Trans, postępuj proszę zgodnie z komunikatami poniżej aby poznać prawdę.");
            #region Stawka Godzinowa 'stawka_godzinowa'
            Console.WriteLine("     Na początek podaj swoją stawkę godzinową.");
            string stawka_godzinowa1 = Console.ReadLine();
            int stawka_godzinowa = int.Parse(stawka_godzinowa1);
            #endregion
            #region Przepracowane godziny 'surowe_godziny'
            Console.WriteLine("     Podaj faktyczną ilość godzin spędzonych w pracy (bez urlopu).");
            string surowe_godziny1 = Console.ReadLine();
            int surowe_godziny = int.Parse(surowe_godziny1);
            #endregion
            #region Urlop zdrowotny 'l4'
            Console.WriteLine("     Podaj teraz ilość godzin spędzoną na L4, jeżeli brak wpisz 'brak' lub '0'.");
            int l4 = 0;
            bool validInput = false;
            decimal premial4 = 0.1m;

            while (!validInput)
            {
                string l41 = Console.ReadLine();

                if (l41.ToLower() == "brak" || l41 == "0")
                {
                    validInput = true;
                    premial4 = 0.1m;
                }
                else if (int.TryParse(l41, out l4) && l4 > 0)
                {
                    validInput = true;
                    premial4 = 0m;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa wartość. Proszę wpisać cyfrę lub 'brak'.");
                }
            }

            #endregion
            #region Ilość godzin urlopu 'urlop_wypoczynkowy'
            int urlop_wypoczynkowy = 0;
            bool validInput1 = false;

            while (!validInput1)
            {
                Console.WriteLine("     Podaj ilość godzin spędzonych na urlopie, jeżeli brak wpisz 'brak' lub '0'.");
                string urlop_wypoczynkowy1 = Console.ReadLine();

                if (urlop_wypoczynkowy1.ToLower() == "brak")
                {
                    validInput1 = true;
                }
                else if (int.TryParse(urlop_wypoczynkowy1, out urlop_wypoczynkowy))
                {
                    validInput1 = true;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa wartość. Proszę wpisać cyfrę lub 'brak' lub '0'.");
                }
            }
            #endregion
            #region Soboty 'sobota'
            Console.WriteLine("     Podaj teraz przepracowaną ilość sobót.");
            string sobota1 = Console.ReadLine();
            int sobota = int.Parse(sobota1);
            //sobota to 100, godziny z soboty są we wszystkich godzinach surowych.
            #endregion
            #region Premia uznaniowa 'premia_u'
            //premia uznaniowa za godziny przepracowane, chuj wie od czego zależy.
            decimal premia_u = 0.2m;
            #endregion
            #region -- Obliczenia
            Console.WriteLine(" "); //przerwa wizualna
            decimal podstawa = stawka_godzinowa * surowe_godziny;
            decimal podstawa1 = 3261.53m;
            Console.WriteLine("     Przyjęto wynagrodzenie podstawowe w wysokości " + podstawa1 + " PLN podstawy, przelewu na konto.");
            int stawka_podstawowa = surowe_godziny * stawka_godzinowa;
            int stawka_urlopowa = urlop_wypoczynkowy * stawka_godzinowa;
            int stawka_sobota = sobota * 100;
            Console.WriteLine(" "); //przerwa wizualna
            decimal premia = -podstawa + ((stawka_podstawowa * premial4) + (stawka_podstawowa * premia_u) + stawka_podstawowa + stawka_urlopowa + stawka_sobota);
            #endregion
            Console.WriteLine("Twoje wynagrodzenie wyniesie: " + podstawa1 + " - przelewu na konto oraz: " + ((premia + podstawa) - podstawa1) + " - w kopercie.");
            Console.WriteLine("                                                                                   Razem: " + (premia + podstawa) + " PLN");
            Console.WriteLine("Przechodzę do początku...");
            #region Przerwa wizualna
            Console.WriteLine(" "); //przerwa wizualna
            Console.WriteLine(" "); //przerwa wizualna
            Console.WriteLine(" "); //przerwa wizualna
            Console.WriteLine(" "); //przerwa wizualna
            Console.WriteLine(" "); //przerwa wizualna
            #endregion
            goto start; // Przeniesienie wykonania kodu na początek skryptu

        }
    }
}