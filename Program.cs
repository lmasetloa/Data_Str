using System;
using System.IO;

namespace Data_Str
{
    class Program
    {
        private const int rows = 5;
        private const int cols = 5;

        static void Main(string[] args)
        {
            string[,] Grid = new string[rows, cols];
            Random random = new Random();
            //Read each line of the file into a string array
            string[] lines = File.ReadAllLines(@"C:\Users\eva\source\repos\Data_Str\Doc\words.txt");
            //for loop to store the Char in an array
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < rows; j++)
                {
                    //Random generator from A-Z caps
                    char nextRandom = (char)random.Next('A', 'A' + 26);
                    //assign random char into an arrays
                    Grid[i, j] = nextRandom.ToString();

                }
                Console.WriteLine($"{Grid[i, 0]} {Grid[i, 1]} {Grid[i, 2]} {Grid[i, 3]} {Grid[i, 4]}");
            }
            //for each to take line by line from array 
            foreach (var line in lines)
            {
                int t = 0;
                string word = "";
                int[] arrI = new int[line.Length];
                int[] arrJ = new int[line.Length];

                bool found = false;
                string foundPos = "";
                LineLoop:
                //check if the length is not out of range
                if (t < line.Length)
                {
                    found = false;
                    for(int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (Grid[i, j].ToLower() == line[t].ToString())
                            {
                                //Concate the string in case we want to match the grid word with the line
                                word += Grid[i, j];
                                // we set the found to true if we found any matching letter 
                                found = true;

                                //array to store row position
                                arrI[t] = i;
                                //array to store col position
                                arrJ[t] = j;
                                t++;
                                //if the letter found go to find the next letter
                                goto LineLoop;
                            }
                        }

                    }
                    //if the letter from the word is not in the Grid we go to the next word(line) 
                    if (!found)
                    {
                        t = line.Length;
                    }
                }
                //Check if this two string match
                if (CheckTwoString(line, word.ToLower()))
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        foundPos += $"{Grid[arrI[i], arrJ[i]]} at Row {arrI[i]} at Col {arrJ[i]} ";
                        Grid[arrI[i], arrJ[i]] = "";
                    }
                    Console.WriteLine($"Found as: {foundPos}");
                }

            }

            Console.ReadLine();
        }

        public static bool CheckTwoString(string line, string Grid)
        {
            if (line == Grid)
                return true;
            return false;
        }
    }
}
