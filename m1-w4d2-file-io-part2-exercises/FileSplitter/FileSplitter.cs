using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileSplitter
{
    public static class FileSplitter
    {
        public static int numberOfLinesPerFile = 0;
        public static void proccessFiles()
        {//alices_adventures_in_wonderland.txt
         //C:\Users\aobiedat\Tech Elevator\.Net class\week1\ahmedobieda-c-exercises\m1-w4d2-file-io-part2-exercises\tests\

            bool isValid = false;

            string destinationPath = string.Empty;
            while (!isValid)
            {
                Console.WriteLine("Please input the Path you want the files to be on:");
                destinationPath = Console.ReadLine();
                if (!Directory.Exists(destinationPath))
                {
                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                        isValid = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("the Path you entered is NOT Valid");
                    }
                }
                isValid = true;
            }
            Console.WriteLine("What is the name of the input file?");
            string sourceFileName = Console.ReadLine();
            isValid = false;
            while (!isValid)
            {
                try
                {
                    if (!File.Exists(sourceFileName))
                    {
                        throw new IOException();
                    }
                    else
                    {
                        isValid = true;
                        writeOnEveryFiles(getLineNumbers(destinationPath, sourceFileName), destinationPath, sourceFileName);
                       
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("File NOT FOUND" + e.Message);
                }
            }
        }

        public static int getLineNumbers(string destinationPath, string sourceFileName)
        {
            int numOfFiles = 0;
            Console.WriteLine("How many lines of text (max) should there be in the split files?");
            try
            {
                numberOfLinesPerFile = int.Parse(Console.ReadLine());
                if (numberOfLinesPerFile <= 0) throw new Exception();
                using (StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, sourceFileName)))
                {
                    int linesCount = 0;
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine();
                        linesCount++;

                    }
                    Console.WriteLine($"input file had { linesCount} lines of text.\n\n**GENERATING OUTPUT**");
                    if (linesCount % numberOfLinesPerFile != 0)
                    {
                        numOfFiles = (linesCount / numberOfLinesPerFile) + 1;
                    }
                    else
                    {
                        numOfFiles = (linesCount / numberOfLinesPerFile);

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Number Of Lines is NOT valid");

            }
            return numOfFiles;

        }



        public static void writeOnEveryFiles(int numberOfFiles, string destinationPath, string sourceFileName)
        {
           
            using (StreamReader sr = new StreamReader(Path.Combine(destinationPath, sourceFileName)))
            {                
                for (int i = 1; i <= numberOfFiles; i++)
                {
                    
                    using (StreamWriter sw = new StreamWriter(Path.Combine(destinationPath,$"Generating input-{i}.txt")))
                    {
                        for (int j = 1; j < numberOfLinesPerFile; j++)

                        {
                            if (!sr.EndOfStream)
                            {
                                sw.WriteLine(sr.ReadLine());
                            }
                            else break;
                        }
                    }

                }
            }

        }
    }

}
