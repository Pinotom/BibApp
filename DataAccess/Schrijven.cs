using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccess
{
    public class Schrijven
    {
        public static void ItemsInCollectie<T>(T itemsInCollectie)
        {
            try
            {
                using (Stream stream = File.Open("itemsInCollectie.txt", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, itemsInCollectie);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void AfgevoerdeItems<T>(T afgevoerdeItems)
        {
            try
            {
                using (Stream stream = File.Open("afgevoerdeItems.txt", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, afgevoerdeItems);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Leden<T>(T leden)
        {
            try
            {
                using (Stream stream = File.Open("leden.txt", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, leden);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
