using System;

namespace BusinessLogic
{
    [Serializable()]
    public enum SoortItem { Boek = 1, Stripverhaal, DVD, CD }

    [Serializable()]
    public class Item : IComparable<Item>
    {
        private SoortItem _soortItem;
        private string _itemID;
        private string _titel;
        private string _maker;
        private int _jaartal;
        private bool _uitgeleend;
        private bool _afgevoerd;
        private bool _gereserveerd;

        public SoortItem SoortItem
        {
            get { return _soortItem; }
            private set { _soortItem = value; }
        }

        public string ItemID    
        {
            get { return _itemID; }
            private set { _itemID = value; }
        }

        public string Titel
        {
            get { return _titel; }
            private set { _titel = value; }
        }

        public string Maker
        {
            get { return _maker; }
            private set { _maker = value; }
        }

        public int Jaartal
        {
            get { return _jaartal; }
            private set { _jaartal = value; }
        }

        public bool Uitgeleend
        {
            get { return _uitgeleend; }
            set { _uitgeleend = value; }
        }

        public bool Afgevoerd
        {
            get { return _afgevoerd; }
            set { _afgevoerd = value; }
        }

        public bool Gereserveerd
        {
            get { return _gereserveerd; }
            set { _gereserveerd = value; }
        }

        public Item(SoortItem soortItem, string id, string titel, string maker, int jaartal)
        {
            SoortItem = soortItem;
            ItemID = id;
            Titel = titel;
            Maker = maker;
            Jaartal = jaartal;
            Uitgeleend = false;
            Afgevoerd = false;
            Gereserveerd = false;
        }

        public int CompareTo(Item anderItem)
        {
            if (anderItem == null)
            {
                return 1;
            }

            return this.ItemID.CompareTo(anderItem.ItemID);
        }

        public override string ToString()
        {
            return $"{ItemID,-5}{Titel,-30}{Maker,-20}{Jaartal,5}   {(Uitgeleend ? "X" : " "),-4}   {(Gereserveerd ? "X" : " "),-4}";
        }
    }
}
