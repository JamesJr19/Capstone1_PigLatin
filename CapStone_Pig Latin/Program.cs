using System;

namespace CapStone_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)

        {
            //While loop to ask the user if they would like to continue
            string userContinue = "y";

            while (userContinue != "n")

            {
                //change colors back to original
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Welcome to the Pig Latin generator.");

                Console.WriteLine("Please enter a word.");

                string userInput = Console.ReadLine().ToLower();

                Console.WriteLine();

                CheckForText(userInput);

                


                //validation for numbers
                int valid;
                string pigLatin;

                if (int.TryParse(userInput, out valid))
                {
                    //if user enters a number, display number as it is. Do not convert .
                    Console.WriteLine(userInput);
                }
                else
                {
                    pigLatin = PigLatin(userInput);
                    Console.WriteLine($"{pigLatin}\n");
                }

                //check to see if input has any special characters
                char[] one = userInput.ToCharArray();
                char[] two = new char[one.Length];

                for (int i = 0; i < one.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(one[i]))
                    {
                        Console.WriteLine(userInput);
                    }
                }

                // ask user if they want to enter another word
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Would you like to try again? y/n?");

                userContinue = Console.ReadLine();
                while (userContinue != "y" && userContinue != "n")
                {
                    userContinue = Console.ReadLine().ToLower();
                    Console.WriteLine("");

                }
            }
        }



        //method to convert input sentence to pig latin
        public static string PigLatin(string sentence)
        {
            //declare variables used
            string firstLetter, restOfWord, vowels = "AEIOUaeiou";
            int letter;

            //for each loop to find if first letter is a vowel or a constonant
            foreach (string word in sentence.Split())
            {
                firstLetter = word.Substring(0, 1).ToLower();
                restOfWord = word.Substring(1, word.Length - 1).ToLower();
                letter = vowels.IndexOf(firstLetter);

                if (letter == -1)
                {
                    sentence = restOfWord + firstLetter + "ay";
                }
                else
                {
                    sentence = word + "way";

                }

            }
            return sentence;
        }
        //check to see if user entered anything
        public static string CheckForText(string userInput)
        {

            while (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a word.");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

    }
}







