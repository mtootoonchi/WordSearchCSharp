using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rules of the Crossword.");
            Console.WriteLine("Capital letters are letters with accent marks.");
            Console.WriteLine();
            string[,] wordsearch = null;
            List<string> words = null;
            string choice = "null";
            string word = "";
            while (true)
            {
                wordsearch = null;
                choice = "null";
                words = null;
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("Type \"1\" for Crossword Maker.");
                Console.WriteLine("Type \"2\" for Crossword Solver.");
                Console.WriteLine("Enter anything else to stop.\n");
                Console.Write("Choice: ");
                choice = Console.ReadLine();
                Console.WriteLine();
                if (choice.Equals("1")) // Crossword Maker
                {
                    Console.WriteLine("Not done yet.\n");
                    wordsearch = new string[askInt("How many rows are in your crossword?\nEnter \"0\" or a non-number to exit."), askInt("How many columns are in your crossword?\nEnter \"0\" or a non-number to exit.")];
                    if (wordsearch.GetLength(0) == 0 || wordsearch.GetLength(1) == 0)
                    {
                        Console.WriteLine("Invalid choice or \"0.\"");
                    }
                    else
                    {
                        words = new List<string>();
                        for (int i = 1; i != 0; i++)
                        {
                            word = "";
                            word = askString("What do you want your " + i + " word to be?\nEnter 0 to stop.");
                            if (word.Equals("0"))
                            {
                                i = -1;
                            }
                            else
                            {
                                words.Add(word);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice.Equals("2")) // Crossword Solver
                {
                    wordsearch = new string[askInt("How many rows are in your crossword?\nEnter \"0\" or a non-number to exit."), askInt("How many columns are in your crossword?\nEnter \"0\" or a non-number to exit.")];
                    if (wordsearch.GetLength(0) == 0 || wordsearch.GetLength(1) == 0)
                    {
                        Console.WriteLine("Invalid choice or \"0.\"");
                    }
                    else
                    {
                        words = new List<string>();
                        for (int i = 0; i < wordsearch.GetLength(0); i++)
                        {
                            for (int j = 0; j < wordsearch.GetLength(1); j++)
                            {
                                wordsearch[i, j] = askString("What is your space for row " + (i + 1) + " column " + (j + 1) + " in your crossword?");
                            }
                        }
                        for (int i = 1; i != 0; i++)
                        {
                            word = "";
                            word = askString("What is your " + i + " word?\nEnter \"0\" to stop.");
                            if (word.Equals("0"))
                            {
                                i = -1;
                            }
                            else
                            {
                                words.Add(word);
                            }
                            Console.WriteLine();
                        }
                        Solver solved = new Solver(wordsearch, words);
                        solved.Solve();
                        solved.Solved();
                    }
                }
                else
                {
                    Console.WriteLine("You had stopped the program.");
                    break;
                }
                Console.WriteLine();
            }
        }
        public static int askInt(string str)
        {
            Console.WriteLine(str + "\nChoice: ");
            return tryInt(Console.ReadLine());
        }
        public static int tryInt(string str)
        {
            try
            {
                // checking valid integer using parseInt() method 
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }
        public static string askString(string str)
        {
            Console.WriteLine(str + "\nChoice: ");
            return Console.ReadLine();
        }
    }
}
