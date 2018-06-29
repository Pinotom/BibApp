using System;

namespace ConsoleValidator
{
    public static class Validator
    {
        private const string MESSAGE = "Foutieve invoer. Probeer opnieuw.";


        public static DateTime GetDatumInVerleden(string ErrorMessage = MESSAGE, bool DatumInVerleden = false)
        {
            DateTime datum = new DateTime();
            if (DatumInVerleden)
            {
                while (!DateTime.TryParse(Console.ReadLine(), out datum) || datum > DateTime.Now)
                {
                    Console.WriteLine(ErrorMessage);
                    SetCursorTerug();
                }
            }
            else
            {
                while (!DateTime.TryParse(Console.ReadLine(), out datum))
                {
                    Console.WriteLine(ErrorMessage);
                    SetCursorTerug();
                }
            }
            ClearErrorMessage();
            return datum;
        }

        public static int GetMenuKeuze(int bovengrens, string ErrorMessage = "Dit is geen geldige keuze. Probeer opnieuw.", int ondergrens = 1)
        {
            int keuze;
            Console.WriteLine("Maak uw keuze:");
            while (!int.TryParse(Console.ReadLine(), out keuze) || !(keuze >= ondergrens && keuze <= bovengrens))
            {
                Console.WriteLine(ErrorMessage);
                SetCursorTerug();
            }
            ClearErrorMessage();
            return keuze;
        }

        public static bool GetGeldigAdminPaswoord(string input, string paswoord)
        {
            if (input == paswoord)
            {
                return true;
            }
            return false;
        }

        public static int GetJaartal(bool JaartalTotNu = false, string ErrorMessage = "Dit is geen geldig jaartal. Probeer opnieuw.")
        {
            int jaartal;
            if (JaartalTotNu)
            {
                while (!(int.TryParse(Console.ReadLine(), out jaartal) && jaartal > 0 && jaartal < DateTime.Now.Year))
                {
                    Console.WriteLine(ErrorMessage);
                    SetCursorTerug();
                }
            }
            else
            {
                while (!(int.TryParse(Console.ReadLine(), out jaartal) && jaartal > 0))
                {
                    Console.WriteLine(ErrorMessage);
                    SetCursorTerug();
                }
            }
            ClearErrorMessage();
            return jaartal;
        }

        public static bool DubbelCheck(string message = "Bent u zeker?")
        {
            return JaNee(message);
        }

        public static bool JaNee(string vraag, string ErrorMessage = MESSAGE)
        {
            Console.WriteLine(vraag + " (J/N)");
            string input = Console.ReadLine();
            while (input.ToUpper() != "J" && input.ToUpper() != "N" )
            {
                Console.WriteLine(ErrorMessage);
                SetCursorTerug();
                input = Console.ReadLine();
            }
            ClearErrorMessage();
            if (input.ToUpper() == "J")
            {
                return true;
            }
            return false;
        }

        private static void SetCursorTerug()
        {
            Console.SetCursorPosition(Console.CursorLeft, (Console.CursorTop - 2));
            int huidigeLijn = Console.CursorTop;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, huidigeLijn);
        }

        private static void ClearErrorMessage()
        {
            int huidigeLijn = Console.CursorTop;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, huidigeLijn);
        }
    }
}
