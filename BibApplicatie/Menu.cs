using System;
using System.Collections.Generic;
using ConsoleValidator;
using BusinessLogic;

namespace BibApplicatie
{
    static class Menu
    {
        public static void ClearScherm()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                             BIBLIOTHEEKPROGRAMMA");
            Console.WriteLine("________________________________________________________________________________");
            Console.WriteLine();
        }

        public static Bezoeker LogIn()
        {
            ClearScherm();
            ToonLogIn();
            int keuze = Validator.GetMenuKeuze(3);
            switch (keuze)
            {
                case 1:
                    Console.WriteLine("Welkom bezoeker,");
                    Console.WriteLine("Gelieve volgende gegevens in te vullen.");
                    return new Bezoeker(VraagString("Voornaam:"), VraagString("Familienaam:"));
                case 2:
                    return GetLid();
                case 3:
                    return GetMedewerker();
                default:
                    break;
            }
            return null;
        }

        private static void ToonLogIn()
        {
            Console.WriteLine("Welkom,");
            Console.WriteLine("Hoe wil je verdergaan?");
            Console.WriteLine("1. Bezoeker");
            Console.WriteLine("2. Lid");
            Console.WriteLine("3. Medewerker");
        }

        private static string VraagString(string label)
        {
            Console.WriteLine($"{label}");
            return Console.ReadLine();
        }

        public static Lid GetLid()
        {
            ClearScherm();
            List<Lid> leden = new List<Lid>();
            Console.WriteLine();
            Console.WriteLine($"     {"Voornaam",-15}{"Familienaam",-25}{"Geboortedatum",-15}{"Lid/Medewerker",-15}");
            Console.WriteLine("---------------------------------------------------------------------------");
            int index = 0;
            foreach (Lid lid in CollectieBibliotheek.Leden)
            {
                if (!(lid is Medewerker))
                {
                    Console.WriteLine($"{++index,3}. {lid}");
                    leden.Add(lid);
                }
            }
            if (index == 0)
            {
                Console.WriteLine("Er zijn geen leden ingeschreven.");
                return null;
            }
            Console.WriteLine();
            int keuze = Validator.GetMenuKeuze(index);
            return leden[keuze - 1];
        }

        private static Medewerker GetMedewerker()
        {
            ClearScherm();
            List<Medewerker> medewerkers = new List<Medewerker>();
            Console.WriteLine();
            Console.WriteLine($"     {"Voornaam",-15}{"Familienaam",-25}{"Geboortedatum",-15}{"Lid/Medewerker",-15}");
            Console.WriteLine("---------------------------------------------------------------------------");
            int index = 0;
            foreach (Lid lid in CollectieBibliotheek.Leden)
            {
                if (lid is Medewerker)
                {
                    Medewerker medewerker = lid as Medewerker;
                    Console.WriteLine($"{++index,3}. {medewerker}");
                    medewerkers.Add(medewerker);
                }
            }
            Console.WriteLine();
            int keuze = Validator.GetMenuKeuze(index);
            Console.WriteLine("Paswoord: (= admin)");
            if (Validator.GetGeldigAdminPaswoord(Console.ReadLine(),"admin"))
            {
                return medewerkers[keuze - 1];
            }
            Console.WriteLine("Fout paswoord.");
            return null;
        }

        public static int BasisMenuBezoeker(Bezoeker user)
        {
            ClearScherm();
            ToonBasisMenuBezoeker(user);
            return Validator.GetMenuKeuze(4);
        }

        public static int BasisMenuLid(Bezoeker user)
        {
            ClearScherm();
            ToonBasisMenuLid(user);
            return Validator.GetMenuKeuze(9);
        }

        public static int BasisMenuMedewerker(Bezoeker user)
        {
            ClearScherm();
            ToonBasisMenuMedewerker(user);
            return Validator.GetMenuKeuze(12);
        }

        private static void ToonBasisMenuBezoeker(Bezoeker user)
        {
            Console.WriteLine($"Welkom {user.Voornaam},");
            Console.WriteLine();
            Console.WriteLine("1. Registreer als lid");
            Console.WriteLine("2. Zoek item");
            Console.WriteLine("3. Overzicht items");
            Console.WriteLine("4. Ga naar hoofdmenu");
        }

        private static void ToonBasisMenuLid(Bezoeker user)
        {
            Console.WriteLine($"Welkom {user.Voornaam},");
            Console.WriteLine();
            Console.WriteLine("1. Zoek item");
            Console.WriteLine("2. Overzicht items");
            Console.WriteLine("3. Leen item uit");
            Console.WriteLine("4. Reserveer item");
            Console.WriteLine("5. Breng item terug");
            Console.WriteLine("6. Bekijk uitleenhistoriek");
            Console.WriteLine("7. Bekijk uitgeleende items");
            Console.WriteLine("8. Bekijk gereserveerde items");
            Console.WriteLine("9. Ga naar hoofdmenu");
        }

        private static void ToonBasisMenuMedewerker(Bezoeker user)
        {
            Console.WriteLine($"Welkom {user.Voornaam},");
            Console.WriteLine();
            Console.WriteLine("1. Zoek item");
            Console.WriteLine("2. Overzicht items");
            Console.WriteLine("3. Leen item uit");
            Console.WriteLine("4. Reserveer item");
            Console.WriteLine("5. Breng item terug");
            Console.WriteLine("6. Bekijk uitleenhistoriek");
            Console.WriteLine("7. Bekijk uitgeleende items");
            Console.WriteLine("8. Bekijk gereserveerde items");
            Console.WriteLine("9. Promoveer lid naar medewerker");
            Console.WriteLine("10. Voeg item toe aan collectie");
            Console.WriteLine("11. Voer item af uit collectie");
            Console.WriteLine("12. Ledenbestanden aanmaken");
            Console.WriteLine("13. Ga naar hoofdmenu");
        }

        public static string SubMenuZoekItem()
        {
            Console.WriteLine("Geef een titel of ID-nummer in om te zoeken:");
            return Console.ReadLine();
        }

        public static void ItemsTonen(List<Item> gevondenItems)
        {
            int aantalItems = gevondenItems.Count;
            if (aantalItems == 0)
            {
                Console.WriteLine("Er is geen item gevonden voor deze zoekterm.");
                return;
            }
            Console.WriteLine("Zoekresultaten:");
            Console.WriteLine($"     {"ID",-5}{"Titel",-30}{"Auteur",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            for (int i = 0; i < aantalItems; i++)
            {
                Console.WriteLine($"{(i + 1),3}. {gevondenItems[i]}");
            }
            Console.WriteLine();
        }

        public static int SubMenuOverzicht()
        {
            ClearScherm();
            ToonSubMenuOverzicht();
            return Validator.GetMenuKeuze(4);
        }

        private static void ToonSubMenuOverzicht()
        {
            Console.WriteLine("Van wat wilt u een overzicht?");
            Console.WriteLine();
            Console.WriteLine("1. Overzicht boeken");
            Console.WriteLine("2. Overzicht stripverhalen");
            Console.WriteLine("3. Overzicht CD's");
            Console.WriteLine("4. Overzicht DVD's");
        }

        public static Item ItemUitlenen(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Item uitlenen");
            Console.WriteLine();
            Console.WriteLine("Welk item wilt u uitlenen?");
            List<Item> gevondenItems = lid.ZoekItem(SubMenuZoekItem());
            ItemsTonen(gevondenItems);
            int aantalItems = gevondenItems.Count;
            if (aantalItems == 0)
            {
                return null;
            }
            int keuze = Validator.GetMenuKeuze(aantalItems);
            if (Validator.DubbelCheck("Item uitlenen?"))
            {
                return gevondenItems[keuze-1];
            }
            return null;

        }

        public static Item ItemReserveren(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Item reserveren");
            Console.WriteLine();
            Console.WriteLine("Welk item wilt u reserveren?");
            List<Item> gevondenItems = lid.ZoekItem(SubMenuZoekItem());
            ItemsTonen(gevondenItems);
            int aantalItems = gevondenItems.Count;
            if (aantalItems == 0)
            {
                return null;
            }
            int keuze = Validator.GetMenuKeuze(aantalItems);
            if (Validator.DubbelCheck("Item reserveren?"))
            {
                return gevondenItems[keuze - 1];
            }
            return null;
        }

        public static Item ItemTerugbrengen(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Item terugbrengen:");
            Console.WriteLine();
            Console.WriteLine("Welk item wilt u terugbrengen?");
            Console.WriteLine();
            List<Item> items = new List<Item>();
            int index = 0;
            for (int i = 0; i < lid.ItemsUitgeleend.Length; i++)
            {
                if (lid.ItemsUitgeleend[i] != null)
                {
                    items.Add(lid.ItemsUitgeleend[i]);
                }
            }
            foreach (Item item in items)
            {
                Console.WriteLine($"{++index}. {item.Titel} - {item.Maker} - {item.SoortItem}");
            }
            if (index == 0)
            {
                Console.WriteLine("U heeft geen items uitgeleend, dus kan er ook geen terugbrengen.");
                return null;
            }
            int keuze = Validator.GetMenuKeuze(index);
            return items[keuze - 1];
        }

        public static void ToonUitleenhistoriek(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Uitleenhistoriek:");
            Console.WriteLine();
            foreach (var item in lid.UitleenHistoriek)
            {
                Console.WriteLine($"{item.Value.ToShortDateString()} - {item.Key.Titel} - {item.Key.Maker}");
            }
            Console.WriteLine();
        }

        public static void ToonUitgeleendeItems(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Items uitgeleend:");
            Console.WriteLine();
            foreach (Item item in lid.ItemsUitgeleend)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item.Titel} - {item.Maker}");
                }
            }
            Console.WriteLine();
        }

        public static void ToonGereserveerdeItems(Lid lid)
        {
            ClearScherm();
            Console.WriteLine("Items gereserveerd:");
            Console.WriteLine();
            foreach (Item item in lid.Reservatie)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item.Titel} - {item.Maker}");
                }
            }
            Console.WriteLine();
        }

        public static Item ItemToevoegen()
        {
            ClearScherm();
            Console.WriteLine("Item toevoegen:");
            Console.WriteLine();
            SoortItem soortItem = (SoortItem)SetSoortItem();
            string id = SetID();
            string titel = VraagString("Titel:");
            string maker = VraagString($"{SoortMaker(soortItem)}:");
            Console.WriteLine("Jaartal:");
            int jaartal = Validator.GetJaartal(true);
            return new Item(soortItem, id, titel, maker, jaartal);
        }

        private static int SetSoortItem()
        {
            Console.WriteLine("Welk soort item wilt u toevoegen?");
            Console.WriteLine();
            foreach (SoortItem item in Enum.GetValues(typeof(SoortItem)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            return Validator.GetMenuKeuze(Enum.GetNames(typeof(SoortItem)).Length);
        }

        private static string SetID()
        {
            Random r = new Random();
            string id;
            do
            {
                id = r.Next(0, 10000).ToString().PadLeft(4, '0');
            } while (!CheckID(id));
            return id;
        }

        private static string SoortMaker(SoortItem soortItem)
        {
            switch ((int)soortItem)
            {
                case 1:
                    return "Auteur";
                case 2:
                    return "Auteur";
                case 3:
                    return "Regisseur";
                case 4:
                    return "Uitvoerder";
                default:
                    return "";
            }
        }

        private static bool CheckID(string id)
        {
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie)
            {
                if (item.ItemID == id)
                {
                    return false;
                }
            }
            foreach (Item item in CollectieBibliotheek.AfgevoerdeItems)
            {
                if (item.ItemID == id)
                {
                    return false;
                }
            }
            return true;
        }

        public static Item ItemAfvoeren()
        {
            ClearScherm();
            ToonSubMenuAfvoeren();
            int keuze = Validator.GetMenuKeuze(4);
            return GetItemAfvoeren((SoortItem)keuze);
        }

        public static Item GetItemAfvoeren(SoortItem soortItem)
        {
            List<Item> tempLijst = new List<Item>();
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie)
            {
                if (item.SoortItem == soortItem)
                {
                    tempLijst.Add(item);
                }
            }
            ClearScherm();
            Console.WriteLine("Kies item om af te voeren.");
            Console.WriteLine();
            Console.WriteLine($"     {"ID",-5}{"Titel",-30}{"Auteur",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            int aantalItems = tempLijst.Count;
            for (int i = 0; i < aantalItems; i++)
            {
                Console.WriteLine($"{(i+1),3}. {tempLijst[i]}");
            }
            int keuze = Validator.GetMenuKeuze(aantalItems);
            if (Validator.DubbelCheck("Wilt u dit item zeker afvoeren?"))
            {
                return tempLijst[keuze - 1];
            }
            return null;
        }

        private static void ToonSubMenuAfvoeren()
        {
            Console.WriteLine("Wat wilt u afvoeren?");
            Console.WriteLine();
            Console.WriteLine("1. Overzicht boeken");
            Console.WriteLine("2. Overzicht stripverhalen");
            Console.WriteLine("3. Overzicht CD's");
            Console.WriteLine("4. Overzicht DVD's");
        }
    }
}
