using System;
using BusinessLogic;
using ConsoleValidator;

namespace BibApplicatie
{
    class Program
    {
        static bool basismenu = false;
        static void Main(string[] args)
        {
            CollectieBibliotheek bib = new CollectieBibliotheek();
            do
            {
                Bezoeker user = GetUser(Menu.LogIn());
                basismenu = false;
                do
                {
                    if (user is Medewerker)
                    {
                        ActiesMedewerker(Menu.BasisMenuMedewerker(user), user as Medewerker);
                        Console.WriteLine("Druk op een toets om terug te keren");
                        Console.ReadKey();
                    }
                    else if (user is Lid)
                    {

                        ActiesLid(Menu.BasisMenuLid(user), user as Lid);
                        Console.WriteLine("Druk op een toets om terug te keren");
                        Console.ReadKey();
                    }
                    else
                    {
                        ActiesBezoeker(Menu.BasisMenuBezoeker(user), user);
                        Console.WriteLine("Druk op een toets om terug te keren");
                        Console.ReadKey();
                    }
                } while (!basismenu);
            } while (true);
        }

        private static Bezoeker GetUser(Bezoeker user)
        {
            while (user == null)
            {
                user = Menu.LogIn();
            }
            return user;
        }

        private static void ActiesBezoeker(int keuze, Bezoeker bezoeker)
        {
            switch (keuze)
            {
                case 1:
                    Menu.ClearScherm();
                    Console.WriteLine("Registreer als lid:");
                    Console.WriteLine();
                    bezoeker.RegistreerAlsLid();
                    basismenu = true;
                    break;
                case 2:
                    Menu.ClearScherm();
                    string zoekterm = Menu.SubMenuZoekItem();
                    Menu.ItemsTonen(bezoeker.ZoekItem(zoekterm));
                    break;
                case 3:
                    Menu.ClearScherm();
                    Overzicht(bezoeker);
                    break;
                case 4:
                    basismenu = true;
                    break;
                default:
                    break;
            }
        }

        private static void ActiesLid(int keuze, Lid lid)
        {
            switch (keuze)
            {
                case 1:
                    Menu.ClearScherm();
                    string zoekterm = Menu.SubMenuZoekItem();
                    Menu.ItemsTonen(lid.ZoekItem(zoekterm));
                    break;
                case 2:
                    Menu.ClearScherm();
                    Overzicht(lid);
                    break;
                case 3:
                    Item item = Menu.ItemUitlenen(lid);
                    if (item != null)
                    {
                        lid.Uitlenen(item);
                    }
                    break;
                case 4:
                    item = Menu.ItemReserveren(lid);
                    if (item != null)
                    {
                        lid.Reserveren(item);
                    }
                    break;
                case 5:
                    item = Menu.ItemTerugbrengen(lid);
                    if (item != null)
                    {
                        lid.Terugbrengen(item);
                    }
                    break;
                case 6:
                    Menu.ToonUitleenhistoriek(lid);
                    break;
                case 7:
                    Menu.ToonUitgeleendeItems(lid);
                    break;
                case 8:
                    Menu.ToonGereserveerdeItems(lid);
                    break;
                case 9:
                    basismenu = true;
                    break;
                default:
                    break;
            }
        }

        private static void ActiesMedewerker(int keuze, Medewerker medewerker)
        {
            Item item;
            switch (keuze)
            {
                case 1:
                    Menu.ClearScherm();
                    string zoekterm = Menu.SubMenuZoekItem();
                    Menu.ItemsTonen(medewerker.ZoekItem(zoekterm));
                    break;
                case 2:
                    Menu.ClearScherm();
                    Overzicht(medewerker);
                    break;
                case 3:
                    item = Menu.ItemUitlenen(medewerker);
                    if (item != null)
                    {
                        medewerker.Uitlenen(item);
                    }
                    break;
                case 4:
                    item = Menu.ItemReserveren(medewerker);
                    if (item != null)
                    {
                        medewerker.Reserveren(item);
                    }
                    break;
                case 5:
                    item = Menu.ItemTerugbrengen(medewerker);
                    if (item != null)
                    {
                        medewerker.Terugbrengen(item);
                    }
                    break;
                case 6:
                    Menu.ToonUitleenhistoriek(medewerker);
                    break;
                case 7:
                    Menu.ToonUitgeleendeItems(medewerker);
                    break;
                case 8:
                    Menu.ToonGereserveerdeItems(medewerker);
                    break;
                case 9:
                    medewerker.PromoveerLidNaarMedewerker(Menu.GetLid());
                    break;
                case 10:
                    
                    medewerker.VoegItemToe(Menu.ItemToevoegen());
                    break;
                case 11:
                    medewerker.VoerItemAf(Menu.ItemAfvoeren());
                    break;
                case 12:
                    if (Validator.JaNee("Wilt u ledenbestanden aanmaken van alle leden?"))
                    {
                        medewerker.MaakLedenBestanden();
                    }
                    break;
                case 13:
                    basismenu = true;
                    break;
                default:
                    break;
            }
        }

        private static void Overzicht(Bezoeker bezoeker)
        {
            int keuze = Menu.SubMenuOverzicht();
            switch (keuze)
            {
                case 1:
                    Menu.ClearScherm();
                    bezoeker.ToonOverzichtBoek();
                    break;
                case 2:
                    Menu.ClearScherm();
                    bezoeker.ToonOverzichtStripverhaal();
                    break;
                case 3:
                    Menu.ClearScherm();
                    bezoeker.ToonOverzichtCD();
                    break;
                case 4:
                    Menu.ClearScherm();
                    bezoeker.ToonOverzichtDVD();
                    break;
                default:
                    break;
            }
        }
    }
}
