using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;

namespace BusinessLogic
{
    [Serializable()]
    public class Lid : Bezoeker
    {
        private DateTime _geboortedatum;
        private Dictionary<Item,DateTime> _uitleenHistoriek = new Dictionary<Item, DateTime>();
        private Item[] _itemsUitgeleend = new Item[5];
        private Item[] _reservatie = new Item[5];

        public DateTime Geboortedatum
        {
            get { return _geboortedatum; }
            private set { _geboortedatum = value; }
        }
        
        public Dictionary<Item, DateTime> UitleenHistoriek
        {
            get { return _uitleenHistoriek; }
            private set { _uitleenHistoriek = value; }
        }

        public Item[] ItemsUitgeleend
        {
            get { return _itemsUitgeleend; }
            private set { _itemsUitgeleend = value; }
        }

        public Item[] Reservatie
        {
            get { return _reservatie; }
            private set { _reservatie = value; }
        }

        public Lid(string voornaam, string familienaam, DateTime geboortedatum) : base(voornaam, familienaam)
        {
            Geboortedatum = geboortedatum;
        }

        public void Uitlenen(Item item)
        {
            int indexReservatie = Array.IndexOf(Reservatie, item);
            bool zelfGereserveerd = indexReservatie != -1;
            if (item.Gereserveerd && !zelfGereserveerd)
            {
                Console.WriteLine("U kan dit item niet uitlenen, want het is gereserveerd door iemand anders.");
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (ItemsUitgeleend[i] == null)
                    {
                        if (item.Gereserveerd && zelfGereserveerd)
                        {
                            Reservatie[indexReservatie] = null;
                            CollectieBibliotheek.ItemsInCollectie.Find(it => it.ItemID == item.ItemID).Gereserveerd = false;
                            Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
                        }
                        ItemsUitgeleend[i] = item;
                        CollectieBibliotheek.ItemsInCollectie.Find(it => it.ItemID == item.ItemID).Uitgeleend = true;
                        Console.WriteLine("Item is succesvol uitgeleend.");
                        Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
                        Schrijven.Leden(CollectieBibliotheek.Leden);
                        return;
                    }
                }
                Console.WriteLine("U kan niets meer uitlenen, want u heeft nog 5 items thuis.");
            }
        }

        public void Terugbrengen(Item item)
        {
            for (int i = 0; i < 5; i++)
            {
                if (ItemsUitgeleend[i].ItemID == item.ItemID)
                {
                    UitleenHistoriek.Add(ItemsUitgeleend[i], DateTime.Now);
                    ItemsUitgeleend[i] = null;
                    CollectieBibliotheek.ItemsInCollectie.Find(it => it.ItemID == item.ItemID).Uitgeleend = false;
                    Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
                    Schrijven.Leden(CollectieBibliotheek.Leden);
                    Console.WriteLine("Boek succesvol teruggebracht.");
                    return;
                }
            }
            Console.WriteLine("U had dit boek niet uitgeleend, dus kan u het ook niet terugbrengen.");
        }

        public void Reserveren(Item item)
        {
            if (Reservatie.Contains(item))
            {
                Console.WriteLine("U had dit item reeds gereserveerd.");
            }
            for (int i = 0; i < 5; i++)
            {
                if (Reservatie[i] == null)
                {
                    int index = CollectieBibliotheek.ItemsInCollectie.FindIndex(it => it.ItemID == item.ItemID);
                    if (!CollectieBibliotheek.ItemsInCollectie[index].Gereserveerd)
                    {
                        CollectieBibliotheek.ItemsInCollectie[index].Gereserveerd = true;
                        Reservatie[i] = item;
                        Console.WriteLine("U heeft dit boek succesvol gereserveerd.");
                        Schrijven.ItemsInCollectie(CollectieBibliotheek.ItemsInCollectie);
                        Schrijven.Leden(CollectieBibliotheek.Leden);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, dit item is reeds gereserveerd door iemand anders.");
                        return;
                    }
                }
            }
            Console.WriteLine("U kan niets meer reserveren, want u heeft reeds 5 items gereserveerd.");
        }

        public override string ToString()
        {
            string soortLid = "L";
            if (this is Medewerker)
            {
                soortLid = "M";
            }
            return $"{Voornaam,-15}{Familienaam,-25}{Geboortedatum.ToShortDateString(),-15}{soortLid,-15}";
        }

    }
}
