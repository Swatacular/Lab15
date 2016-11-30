using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Countries Maintenance Application!");
            while (true)
            {
                Console.WriteLine(MenuToString());
                Console.WriteLine();
                string input = getValidInput();
                Console.WriteLine();
                CheckAndUpdate(int.Parse(input));
            }
        }


        public static string CountryFileAddress = "../../Countries.txt";
        public static List<string> Countries = new List<string>();


        public static void CheckAndUpdate(int menuChoice)
        {
            if (menuChoice == 1)
            {
                Console.WriteLine(CountriesToString());
            }
            else if (menuChoice == 2)
            {
                WriteToFile(getValidInput("Enter country: "));
            }
            else if (menuChoice == 3)
            {
                Exit();
            }
            else throw new FormatException();
        }

        public static string MenuToString()
        {
            return ("1 - See the list of countries\n" +
                "2 - Add a country\n" +
                "3 - Exit");
        }

        public static string getValidInput()
        {
            Console.Write("Enter menu number: ");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Bad Input, Try again: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string getValidInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bad Input, Try again: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string CountriesToString()
        {
            string returnString = "";

            foreach (string str in ReadFromFile())
            {
                returnString += str + "\n";
            }
            return returnString;
        }

        public static void Exit()
        {
            Console.WriteLine("Buh-bye!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #region FileIO
        public static StreamWriter sw;
        public static StreamReader sr;

        public static void WriteToFile(string countryName)
        {
            sw = new StreamWriter(CountryFileAddress, true);
            sw.WriteLine(countryName.Trim());
            sw.Close();
            Console.WriteLine("This country has been saved!");
            Console.WriteLine();
        }

        public static List<string> ReadFromFile()
        {
            List<string> newCountryList = new List<string>();
            sr = new StreamReader(CountryFileAddress);
            string data = sr.ReadToEnd().Trim();
            sr.Close();

            foreach (string str in data.Split('\n'))
            {
                newCountryList.Add(str);
            }

            return newCountryList;
        }
        #endregion

    }
}
