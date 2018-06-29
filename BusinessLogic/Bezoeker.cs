using System;
using System.Collections.Generic;
using DataAccess;
using ConsoleValidator;
using System.Linq;


namespace BusinessLogic
{
    [Serializable()]
    public class Bezoeker
    {
        private string _voornaam;
        private string _familienaam;

        public string Voornaam
        {
            get { return _voornaam; }
            private set { _voornaam = value; }
        }
        
        public string Familienaam
        {
            get { return _familienaam; }
            private set { _familienaam = value; }
        }

        public Bezoeker(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }

        public void RegistreerAlsLid()
        {
            Console.WriteLine("Wat is uw geboortedatum? (formaat: dd/mm/jjjj)");
            DateTime geboortedatum = Validator.GetDatumInVerleden("Dit is geen geldige geboortedatum. Probeer opnieuw.", true);
            CollectieBibliotheek.Leden.Add(new Lid(Voornaam, Familienaam, geboortedatum));
            Schrijven.Leden(CollectieBibliotheek.Leden);
            Console.WriteLine("Proficiat, je bent nu lid!");
        }

        public List<Item> ZoekItem(string zoekterm)
        {
            return CollectieBibliotheek.ItemsInCollectie.FindAll(it => it.Titel.ToUpper().Contains(zoekterm.ToUpper()) || it.ItemID == zoekterm);
        }


        public void ToonOverzichtBoek()
        {
            Console.WriteLine("OVERZICHT BOEKEN");
            Console.WriteLine();
            Console.WriteLine($"{"ID",-5}{"Titel",-30}{"Auteur",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie.OrderBy(i => i.Maker).ToList())
            {
                if (item.SoortItem == SoortItem.Boek)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        public void ToonOverzichtStripverhaal()
        {
            Console.WriteLine("OVERZICHT STRIPVERHALEN");
            Console.WriteLine();
            Console.WriteLine($"{"ID",-5}{"Titel",-30}{"Auteur",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie.OrderBy(i => i.Maker).ToList())
            {
                if (item.SoortItem == SoortItem.Stripverhaal)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        public void ToonOverzichtCD()
        {
            Console.WriteLine("OVERZICHT CD'S");
            Console.WriteLine();
            Console.WriteLine($"{"ID",-5}{"Titel",-30}{"Uitvoerder",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie.OrderBy(i => i.Maker).ToList())
            {
                if (item.SoortItem == SoortItem.CD)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        public void ToonOverzichtDVD()
        {
            Console.WriteLine("OVERZICHT DVD'S");
            Console.WriteLine();
            Console.WriteLine($"{"ID",-5}{"Titel",-30}{"Auteur",-20}{"Jaar",5}{"Uitg.",7}{"Geres.",7}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie.OrderBy(i => i.Maker).ToList())
            {
                if (item.SoortItem == SoortItem.DVD)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }
    }
}
