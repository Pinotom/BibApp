using System;
using System.IO;
using DataAccess;
using System.Linq;

namespace BusinessLogic
{
    [Serializable()]
    public class Medewerker : Lid
    {
        public Medewerker(string voornaam, string familienaam, DateTime geboortedatum):base(voornaam, familienaam, geboortedatum)
        {

        }

        public void PromoveerLidNaarMedewerker(Lid lid)
        {
            if (lid is Medewerker)
            {
                Console.WriteLine("Dit lid is al medewerker.");
                return;
            }
            CollectieBibliotheek.Leden.Add(new Medewerker(lid.Voornaam, lid.Familienaam, lid.Geboortedatum));
            Schrijven.Leden(CollectieBibliotheek.Leden);
            CollectieBibliotheek.Leden.Remove(lid);
            Schrijven.Leden(CollectieBibliotheek.Leden);
            Console.WriteLine("Lid succesvol gepromoveerd.");
        }

        public void VoerItemAf(Item item)
        {
            if (item == null)
            {
                return;
            }
            if (CollectieBibliotheek.ItemsInCollectie.Contains(item))
            {
                CollectieBibliotheek.AfgevoerdeItems.Add(item);
                CollectieBibliotheek.ItemsInCollectie.Remove(item);
                Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
                Schrijven.AfgevoerdeItems(CollectieBibliotheek.AfgevoerdeItems);
                Console.WriteLine("Item succesvol afgevoerd.");
                return;
            }
            Console.WriteLine("Kan item niet vinden in de collectie.");
        }

        public void VoegItemToe(Item item)
        {
            if (CollectieBibliotheek.ItemsInCollectie.Contains(item))
            {
                Console.WriteLine("Kan dit item niet toevoegen, want het bestaat reeds in de collectie.");
                return;
            }
            CollectieBibliotheek.ItemsInCollectie.Add(item);
            Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
            Console.WriteLine($"{item.SoortItem} succesvol toegevoegd.");
        }

        public void GeefOverzichtLeden()
        {
            Console.WriteLine("OVERZICHT LEDEN");
            Console.WriteLine();
            Console.WriteLine($"     {"Voornaam",-15}{"Familienaam",-25}{"Geboortedatum",-15}{"Lid/Medewerker",-15}");
            Console.WriteLine("---------------------------------------------------------------------------");
            int index = 1;
            foreach (Lid lid in CollectieBibliotheek.Leden)
            {
                Console.WriteLine($"{index++,3}. {lid}");
            }
        }

        public void MaakLedenBestanden()
        {
            int index = 1;
            foreach (Lid lid in CollectieBibliotheek.Leden.OrderBy(l => l.Familienaam).ToList())
            {
                using (TextWriter writer = File.CreateText($"{index++}{lid.Familienaam}{lid.Voornaam}.txt"))
                {
                    writer.WriteLine($"Naam: {lid.Voornaam} {lid.Familienaam}");
                    writer.WriteLine($"Geboortedatum: {lid.Geboortedatum.ToShortDateString()}");
                    writer.WriteLine($"Medewerker: {(lid is Medewerker ? "Ja" : "Nee")}");
                    writer.WriteLine();
                    writer.WriteLine("Uitgeleend:");
                    for (int i = 0; i < 5; i++)
                    {
                        if (lid.ItemsUitgeleend[i] != null)
                        {
                            writer.WriteLine($"{lid.ItemsUitgeleend[i].ItemID} {lid.ItemsUitgeleend[i].Maker} - {lid.ItemsUitgeleend[i].Titel}");
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine("Gereserveerd:");
                    for (int i = 0; i < 5; i++)
                    {
                        if (lid.Reservatie[i] != null)
                        {
                            writer.WriteLine($"{lid.Reservatie[i].ItemID} {lid.Reservatie[i].Maker} - {lid.Reservatie[i].Titel}");
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine("Uitleenhistoriek:");
                    foreach (var item in lid.UitleenHistoriek)
                    {
                        writer.WriteLine($"{item.Key.ItemID} {item.Key.Maker} - {item.Key.Titel} {item.Value.ToShortDateString()}");
                    }
                }
            }
            Console.WriteLine("Ledenbestanden succesvol aangemaakt.");

        }    
            
    }
}
