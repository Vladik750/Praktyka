using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApp5
{
    public class Task4
    {
        private delegate void Printable();

        private Dictionary<String, String> menu = new Dictionary<string, string>();
        private Dictionary<String, Printable> menuMethods = new Dictionary<string, Printable>();
        private List<Country> _countries;
        
        public Task4()
        {
            menu.Add("1", "read from file");
            menu.Add("2", "sort by name");
            menu.Add("3", "sort by square");
            menu.Add("4", "sort by population");
            menu.Add("5", "find by name");

            menuMethods.Add("1", ReadFromFile);
            menuMethods.Add("2", SortByName);
            menuMethods.Add("3", SortBySquare);
            menuMethods.Add("4", FindByName);
            menuMethods.Add("5", FindByName);

        }

        public void show()
        {
            String keyMenu;
            do
            {
                outputMenu();
                Console.WriteLine("Please, select menu point.");
                keyMenu = Console.ReadLine();
                try
                {
                    menuMethods[keyMenu]();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input" + e.Message);
                }
            } while (!keyMenu.Equals("Q"));
        }

        private static void PrintFlot(List<Country> aeroflots)
        {
            aeroflots.ForEach(x => Console.WriteLine(x));
        }

        private void ReadFromFile()
        {
            Console.Write("Input file path: ");

            String path = Console.ReadLine();

            Stream stream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                _countries =(List<Country>) bf.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            PrintFlot(_countries);
        }

        private void SortByName()
        {
           _countries = Country.SortByName(_countries);

            PrintFlot(_countries);
        }

        private void SortBySquare()
        {
            _countries = Country.SortBySquare(_countries);

            PrintFlot(_countries);
        }

        private void SortByPopulation()
        {
            _countries = Country.SortByPopulation(_countries);

            PrintFlot(_countries);
        }
        private void FindByName()
        {
            Console.Write("Input key:");

            String key = Console.ReadLine();

            PrintFlot(Country.FindByName(_countries, key));
        }


        private void outputMenu()
        {
            Console.WriteLine("\nMenu:");

            menu.ToList()
                .ForEach(x => Console.WriteLine(x.Key + " - " + x.Value));
        }
    }
}