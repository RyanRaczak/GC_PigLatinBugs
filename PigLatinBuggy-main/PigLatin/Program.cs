using System;

namespace PigLatin
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    string userInput = GetInput("Please input a word or sentence to translate to pig Latin");

        //    string translation = ToPigLatin(userInput);
        //    Console.WriteLine(translation);
        //}

        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        public static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vowels)
            {
                if (c == vowel)
                {
                    return true;
                }
            }
            return false;
        }

        public static string ToPigLatin(string word)
        {
            //Modified the program to take in a word or split
            //a string with several words into a string array.
            //It will then cycle the process until all words have
            //gone through the translator

            //Added various bools and additional string variables
            //to handle the extra information being passed from 
            //an array as well as shifting certain variables/bools 
            //around to deal with an array. 

            //Outside of the one string of several loops, there was
            //logic errors in IsVowel that wasn't having it produce
            //correct results, Runtime errors due to incorrect indexing,
            //and leaving the 'w' out of 'way' when dealing with words
            //that started with a vowel. 
            string output = "";
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            word = word.ToLower();
            string[] words = word.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                bool specialCaught = false;
                foreach (char c in specialChars)
                {
                    foreach (char w in words[i])
                    {
                        if (w == c)
                        {
                            if (!specialCaught)
                            {
                                specialCaught = true;
                                Console.WriteLine("That word has special characters, we will return it as is");
                                output += words[i];
                                break;
                            }

                        }
                    }

                }

                bool noVowels = true;
                foreach (char letter in words[i])
                {
                    if (IsVowel(letter))
                    {
                        noVowels = false;
                    }
                }

                if (noVowels)
                {
                    output += words[i];
                }

                string modOutput = "";
                char firstLetter = words[i][0];
                if (IsVowel(firstLetter) == true)
                {
                    modOutput = words[i] + "way";
                }
                else if (!specialCaught && !noVowels)
                {
                    int vowelIndex = -1;
                    //Handle going through all the consonants
                    string wordCut = words[i];
                    for (int j = 0; j <= wordCut.Length; j++)
                    {
                        if (IsVowel(wordCut[j]) == true)
                        {
                            vowelIndex = j;
                            break;
                        }
                    }

                    string sub = words[i].Substring(vowelIndex);
                    string postFix = words[i].Substring(0, vowelIndex);

                    modOutput += sub + postFix + "ay";
                }
                output += modOutput + " ";
            }
            return output.Trim();
        }
    }
}