using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccess
{
    public class Lezen
    {
        public static List<T> ItemsInCollectie<T>()
        {
            List<T> itemsInCollectie = new List<T>(); 
            try
            {
                using (Stream stream = File.Open("itemsInCollectie.txt", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    itemsInCollectie = (List<T>)bin.Deserialize(stream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return itemsInCollectie;
        }

        public static List<T> AfgevoerdeItems<T>()
        {
            List<T> afgevoerdeItems = new List<T>();
            try
            {
                using (Stream stream = File.Open("afgevoerdeItems.txt", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    afgevoerdeItems = (List<T>)bin.Deserialize(stream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return afgevoerdeItems;
        }

        public static List<T> Leden<T>()
        {
            List<T> leden = new List<T>();
            try
            {
                using (Stream stream = File.Open("leden.txt", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    leden = (List<T>)bin.Deserialize(stream);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return leden;
        }

        public static bool CheckIfDatabaseExists()
        {
            return File.Exists("itemsInCollectie.txt") && File.Exists("itemsInCollectie.txt");
        }
    }
}
