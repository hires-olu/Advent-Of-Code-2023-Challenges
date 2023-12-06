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
           

            string[] numbersWritten = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

            string line;

            while (( line = reader.ReadLine()) != null )
            {
                Debug.WriteLine(line);

                string first_number = null;
                int firstNumIndex = 0;
                string last_number = null;
                int lastNumIndex = 0;

                bool foundLastCharacter = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsNumber(line[i])) 
                    {
                        if (first_number == null)
                        {
                            firstNumIndex = i;
                            first_number = line[i].ToString();
                        }   
                        else if (firstNumIndex > i)
                        {
                            firstNumIndex = i;
                            first_number = line[i].ToString();
                        }

                        if (last_number == null)
                        {
                            lastNumIndex = i;
                            last_number = line[i].ToString();
                        }
                        else if (lastNumIndex < i)
                        {
                            lastNumIndex = i;
                            last_number = line[i].ToString();
                        }
                    }
                    else
                    {
                        {

                            for (int j = 0; j < numbersWritten.Length; j++)
                            {
                                if (line.Contains(numbersWritten[j].ToString()))
                                {
                                    int writtenToInt = j + 1;
                                    int writtenIndex = line.IndexOf(numbersWritten[j].ToString());
                                    Debug.WriteLine("Position Of Found Word " + numbersWritten[j].ToString() + ": " + writtenIndex);

                                    if (first_number == null)
                                    {
                                        firstNumIndex = writtenIndex;
                                        first_number = writtenToInt.ToString();
                                    }
                                    else if (firstNumIndex > writtenIndex)
                                    {
                                        firstNumIndex = writtenIndex;
                                        first_number = writtenToInt.ToString();
                                    }

                                    if (last_number == null && foundLastCharacter == false)
                                    {
                                        lastNumIndex = writtenIndex;
                                        last_number = writtenToInt.ToString();
                                    }
                                    else if (lastNumIndex < writtenIndex && foundLastCharacter == false)
                                    {
                                        lastNumIndex = writtenIndex;
                                        last_number = writtenToInt.ToString();
                                    }

                                }
                                if (line.EndsWith(numbersWritten[j].ToString()) && foundLastCharacter == false)
                                {
                                    foundLastCharacter = true;
                                    int writtenToInt = j + 1;
                                    int writtenIndex = line.IndexOf(numbersWritten[j].ToString());
                                    Debug.WriteLine("Position Of Found Word " + numbersWritten[j].ToString() + ": " + writtenIndex);
                                    Debug.WriteLine("Poop");

                                    lastNumIndex = writtenIndex;
                                    last_number = writtenToInt.ToString();
                                }
                            }
                        }
                    }
                }

                string foundValue = first_number + last_number;
                Debug.WriteLine(foundValue);
                totalCalValues += int.Parse(foundValue);

            }
            reader.Close();
            return totalCalValues;
        }
        

        public static void Main(string[] args) 
        {
            int dayOneAnswerOne;
            int dayOneAnswerTwo;

            //dayOneAnswerOne = ValueFinderPartOne(new StreamReader("E:\\Cloud Storage\\GitHub Works\\Advent-Of-Code-2023-Challenges\\Day 1\\Day 1\\puzzleInput.txt"));
            //Console.WriteLine("Day One Answer Part One: " + dayOneAnswerOne);
            dayOneAnswerTwo = ValueFinderPartTwo(new StreamReader("E:\\Cloud Storage\\GitHub Works\\Advent-Of-Code-2023-Challenges\\Day 1\\Day 1\\testfile.txt"));
            Console.WriteLine("Day One Answer Part Two: " + dayOneAnswerTwo);
        }
    }
}
