using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp5
{
    [Serializable]
    public class Country : ISerializable
    {
        public String Name { get; set; }
        public int Square { get; set; }
        public int Population { get; set; }

        public Country()
        {
        }

        protected Country(SerializationInfo info, StreamingContext context)
        {
            Name = (String) info.GetValue("Name", typeof(String));
            Square = (int) info.GetValue("Square", typeof(int));
            Population = (int) info.GetValue("Population", typeof(int));
        }

        public Country(string name, int square, int population)
        {
            Name = name;
            Square = square;
            Population = population;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Square)}: {Square}, {nameof(Population)}: {Population}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Name", Name);
            info.AddValue("Square", Square);
            info.AddValue("Population", Population);
        }

        public static void Write(String path, List<Country> countries)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, countries);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something goes wrong.. " + ex.Message);
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }


        public List<Country> Read(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            try
            {
                BinaryFormatter bs = new BinaryFormatter();
                return (List<Country>) bs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something goes wrong.. " + ex.Message);
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }

        public static List<Country> SortByName(List<Country> countries)
        {
            return countries.OrderBy(x => x.Name).ToList();
        }

        public static List<Country> SortBySquare(List<Country> countries)
        {
            return countries.OrderBy(x => x.Square).ToList();
        }
        
        public static List<Country> SortByPopulation(List<Country> countries)
        {
            return countries.OrderBy(x => x.Population).ToList();
        }

        public static List<Country> FindByName(List<Country> countries, String keyword)
        {
            return countries.FindAll(x => x.Name.Contains(keyword));
        }
    }
}