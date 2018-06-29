using System;
using System.Collections.Generic;
using DataAccess;

namespace BusinessLogic
{
    [Serializable()]
    public class CollectieBibliotheek
    {
        static public List<Item> ItemsInCollectie { get; set; }

        static public List<Item> AfgevoerdeItems { get; set; }

        static public List<Lid> Leden { get; set; }


        public CollectieBibliotheek()
        {
            DemoVulDataBases();
            ItemsInCollectie = Lezen.ItemsInCollectie<Item>();
            AfgevoerdeItems = Lezen.AfgevoerdeItems<Item>();
            Leden = Lezen.Leden<Lid>();
        }

        private static void DemoVulDataBases()
        {
            if (!Lezen.CheckIfDatabaseExists())
            {
                Console.WriteLine("Geen database gevonden. Test-database aanmaken...");
                List<Item> collectie = new List<Item>();
                collectie.Add(new Item(SoortItem.Boek, "3512", "Don Quichote", "Miguel de Cervantes", 1612));
                collectie.Add(new Item(SoortItem.Boek, "2648", "A Tale Of 2 Cities", "Charles Dickens", 1859));
                collectie.Add(new Item(SoortItem.Boek, "1006", "Lord Of The Rings", "JRR Tolkien", 1954));
                collectie.Add(new Item(SoortItem.Boek, "4666", "Le Petit Prince", "de Saint-Exupéry", 1943));
                collectie.Add(new Item(SoortItem.Boek, "5356", "Honderd Jaar Eenzaamheid", "Marquez", 1967));
                collectie.Add(new Item(SoortItem.CD, "8654", "Born To Run", "Bruce Springsteen", 1975));
                collectie.Add(new Item(SoortItem.CD, "2116", "Blood On The Tracks", "Bob Dylan", 1975));
                collectie.Add(new Item(SoortItem.CD, "7813", "Monsters Of Folk", "Monsters Of Folk", 2010));
                collectie.Add(new Item(SoortItem.CD, "3444", "The Party", "Andy Shauf", 2017));
                collectie.Add(new Item(SoortItem.CD, "8862", "Rumours", "Fleetwood Mac", 1977));
                collectie.Add(new Item(SoortItem.Stripverhaal, "0022", "De Koperen Knullen", "Willy Vandersteen", 1981));
                collectie.Add(new Item(SoortItem.Stripverhaal, "3469", "De Zingende Aap", "Jef Nys", 2014));
                collectie.Add(new Item(SoortItem.Stripverhaal, "1833", "Het Gebroken Zwaard", "Willy Van Der Steen", 1959));
                collectie.Add(new Item(SoortItem.Stripverhaal, "6438", "Het Mysterie Spell-Deprik", "Merho", 2001));
                collectie.Add(new Item(SoortItem.Stripverhaal, "5555", "Het Masker Der Stilte", "Franquin", 1976));
                collectie.Add(new Item(SoortItem.DVD, "6543", "The Godfather", "Coppola", 1972));
                collectie.Add(new Item(SoortItem.DVD, "2948", "The Shawshank Redemption", "Darabont", 1994));
                collectie.Add(new Item(SoortItem.DVD, "7772", "Schindler's List", "Spielberg", 1993));
                collectie.Add(new Item(SoortItem.DVD, "9876", "Raging Bull", "Scorsese", 1980));
                collectie.Add(new Item(SoortItem.DVD, "1234", "Casablanca", "Curtis", 1942));
                Schrijven.ItemsInCollectie(collectie);
                List<Item> afgevoerd = new List<Item>();
                Schrijven.AfgevoerdeItems(afgevoerd);
                List<Lid> leden = new List<Lid>();
                leden.Add(new Medewerker("Tom", "Tilley", new DateTime(1984, 12, 20)));
                leden.Add(new Lid("Bart", "Vanhoeymissen", new DateTime(1987, 7, 13)));
                leden.Add(new Lid("Toon", "Cools", new DateTime(1982, 11, 15)));
                leden.Add(new Lid("Tom", "Van Opstal", new DateTime(1984, 06, 22)));
                leden.Add(new Medewerker("Simon", "Tierens", new DateTime(1989, 02, 19)));
                leden.Add(new Lid("Steven", "Vanderjeugt", new DateTime(1988, 04, 01)));
                leden.Add(new Lid("Laurens", "De Prins", new DateTime(1992, 8, 30)));
                leden.Add(new Lid("Dirk", "Lauwaert", new DateTime(1968, 6, 7)));
                Schrijven.Leden(leden);
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Test-database aangemaakt");
                System.Threading.Thread.Sleep(1500);
            }

            
            
            
        }

    }
}
