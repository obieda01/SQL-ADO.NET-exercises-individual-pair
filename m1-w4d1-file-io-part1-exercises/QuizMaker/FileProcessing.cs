using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace QuizMaker
{
    public static class FileProcessing
    {
        public static void manipulateQuizFile()
        {
            int numberOfQuestions = 0;
            int numberOfRightanswer = 0;
            Console.WriteLine("Are you ready for the quiz ?");
            string str = Console.ReadLine();
            Console.WriteLine("Please input the .txt file path:");
            string fileToSearchIn = Console.ReadLine();

            while (!File.Exists(fileToSearchIn))
            {
                Console.WriteLine("Ivalid Path...Please input the an existing file path :");
                fileToSearchIn = Console.ReadLine();
            }
            using (StreamReader sb = new StreamReader(fileToSearchIn))
            {
                try
                {
                    while (!sb.EndOfStream)
                    {
                        numberOfQuestions++;
                        if (readAndManipulateFromFile(sb.ReadLine()) == readUserAnswers())
                        {
                            Console.WriteLine("\nRight!\n\n\n");
                            numberOfRightanswer++;
                        }
                        else
                        {
                            Console.WriteLine("\nSorry that isn't correct!\n\n\n");
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("an error occur while accessing the File " + e.Message); }
                Console.WriteLine("You got " + numberOfRightanswer + " answer(s) correct out of the total " + numberOfQuestions + " questions asked");
            }
            Console.ReadKey();
        }
        //C:\Users\aobiedat\Tech Elevator\.Net class\week1\ahmedobieda-c-exercises\m1-w4d1-file-io-part1-exercises\sample-quiz-file.txt
        public static string readAndManipulateFromFile(string lines)
        {
            string[] stringsFromEveryLine = lines.Split('|');
            string rightAnswer = string.Empty;
            Console.WriteLine("\n" + stringsFromEveryLine[0]);
            for (int i = 1; i < stringsFromEveryLine.Length; i++)
            {
                if (!stringsFromEveryLine[i].Contains("*"))
                {
                    Console.WriteLine("\n" + i + ". " + stringsFromEveryLine[i]);
                }
                else
                {
                    Console.WriteLine("\n" + i + ". " + stringsFromEveryLine[i].Substring(0, stringsFromEveryLine.Length - 1));
                    rightAnswer = i.ToString();
                }
            }

            return rightAnswer;
        }

        public static string readUserAnswers()
        {
            Console.WriteLine("\nPlease answer the question by number:");
            string actualUserAnswer = string.Empty;
            bool isValid = false;
            while (!isValid)
            {
                actualUserAnswer = Console.ReadLine();

                if (actualUserAnswer == "1" || actualUserAnswer == "2" ||
                    actualUserAnswer == "3" || actualUserAnswer == "4")
                {
                    isValid = true;

                }

            }

            Console.WriteLine("Your answer is: " + actualUserAnswer);
            return actualUserAnswer;
        }

    }
}
