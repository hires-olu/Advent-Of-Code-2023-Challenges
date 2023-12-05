using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day_1
{
    class Trebuchet
    {
        public static int ValueFinderPartOne(StreamReader reader)
        {
            int totalCalValues = 0;

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Debug.WriteLine(line);

                string numOnly = Regex.Replace(line, "[^0-9]", "");
                Debug.WriteLine(numOnly);

                char first_number = numOnly[0];
                char last_number = numOnly[numOnly.Length - 1];

                string foundValue = first_number.ToString() + last_number.ToString();
                Debug.WriteLine(foundValue);
                totalCalValues += int.Parse(foundValue);
            }
            reader.Close();
            return totalCalValues;
        }

        public static int ValueFinderPartTwo(StreamReader reader)
        {
            int totalCalValues = 0;
            string first_number = null;
            int firstNumIndex;
            string last_number = null;
            int lastNumIndex;

            string[] numbersWritten = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

            string line;

            while (( line = reader.ReadLine()) != null )
            {
                Debug.WriteLine(line);

                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsNumber(line[i])) 
                    {
                        if (first_number == null)
                            first_number = line[i].ToString();
                        else
                        {

                            last_number = line[i].ToString();
                        }
                    }
                    else
                    {
                        {
                            string sortingLine = line[i..(line.Length - 1)];
                        }
                    }
                }


            }
            reader.Close();
            return totalCalValues;
        }
        

        public static void Main(string[] args) 
        {
            int dayOneAnswerOne;
            int dayOneAnswerTwo;

            dayOneAnswerOne = ValueFinderPartOne(new StreamReader("E:\\Cloud Storage\\GitHub Works\\Advent-Of-Code-2023-Challenges\\Day 1\\Day 1\\puzzleInput.txt"));
            Console.WriteLine("Day One Answer Part One: " + dayOneAnswerOne);
            dayOneAnswerTwo = ValueFinderPartTwo(new StreamReader("E:\\Cloud Storage\\GitHub Works\\Advent-Of-Code-2023-Challenges\\Day 1\\Day 1\\puzzleInput.txt"));
            Console.WriteLine("Day One Answer Part Two: " + dayOneAnswerTwo);
        }
    }
}
