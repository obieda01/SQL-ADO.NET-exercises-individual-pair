using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WordSearch
{
    public static class WordSearch
    {
        public static void workSearcher()
        {
            Console.WriteLine("Please input the string you're searching for :");
            string stringToSearch = Console.ReadLine();

            Console.WriteLine("Please input the file path you're searching in :");
            string fileToSearchIn = Console.ReadLine();
            while (!File.Exists(fileToSearchIn))
            {
                Console.WriteLine("Please input the an existing file path :");
                fileToSearchIn = Console.ReadLine();
            }
            Console.WriteLine("Is the search should be case insensitive (Y/N):");
            string boolCaseSensitive = Console.ReadLine();

            while (!(boolCaseSensitive.ToLower() == "n" || boolCaseSensitive.ToLower() == "y"))
            {

                Console.WriteLine("Invalid input! Is the search case insensitive (Y/N)");

            }
            try
            {
                using (StreamReader sr = new StreamReader(fileToSearchIn))
                {
                    int lineNumber = 1;
                    while (!sr.EndOfStream)
                    {
                        string currentLine = sr.ReadLine();
                        if (boolCaseSensitive == "y")
                        {
                            if (currentLine.Contains(stringToSearch)) Console.WriteLine(lineNumber + ") " + currentLine.ToString());
                        }
                        else
                        {
                            if (currentLine.ToLower().Contains(stringToSearch.ToLower())) Console.WriteLine(lineNumber + ") " + currentLine.ToString());

                        }
                        lineNumber++;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
            Console.ReadKey();
            //C:\Users\aobiedat\Tech Elevator\.Net class\week1\ahmedobieda-c-exercises\m1-w4d1-file-io-part1-exercises\alices_adventures_in_wonderland.txt
            //C:\Users\aobiedat\Tech Elevator\.Net class\week1\ahmedobieda-c-exercises\m1-w4d1-file-io-part1-exercises\sample-quiz-file.txt
        }
    }
}
