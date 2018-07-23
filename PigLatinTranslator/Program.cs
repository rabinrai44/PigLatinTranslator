using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Program
    {
        //initial boolean stored default value true to continue run program
        private static bool runContinue =true;


        // Main method
        static void Main(string[] args)
        {
            //Header
            PrintHeaderTop();

            // start main program as a default value of runContinue = true
            while (runContinue)
            {
                // prompt to the user
                Console.Write("\nEnter a line to be translated:\t");
                string inputWords = Console.ReadLine();

                //calling method to translate given word to PigLatin 
                PigLatinTranslator(inputWords);

                //calling method play again option wheather user wish to continue
                PlayAgain();
            }

            Console.ReadKey();
        }


        //simply print the header on the top program window screen
        private static void PrintHeaderTop()
        {
            string welcome = "Welcome to the Pig Latin Translator!\n";
            Console.WriteLine(welcome);
        }

        //DEFINED CONSTANT VOWELS
        //check if letter is a vowel wheather matched return true
        //otherwise return false
        static bool IS_VOWELS(char vowel)
        {
            char[] VOWELS = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i <VOWELS.Length; i++)
            {
                if (vowel == VOWELS[i])
                {
                    return true;
                }
            }

            return false;
        }


        //takes of a non-vowel and put it on the end 
        //recall the function itself until a vowel is found and return the word
        static string MoveLetter(string word)
        {
            if (!IS_VOWELS(word[0]))
            {
                char moveLetter = Char.ToLower(word[0]);
                return MoveLetter(word.Substring(1) + moveLetter);
            }
            else
                return word;
        }


        //checks whether input word starts with a vowel then put at the end "way"
        //otherwise push that consonant to end until the vowel found then put on the very end of new word "ay"
        private static void PigLatinTranslator(string word)
        {

            if (IS_VOWELS(word[0]))
            {
                string vowelFirst = word + "way";
                Console.WriteLine(vowelFirst);
            }
            else
            {
                string nonVowelFirst = MoveLetter(word) + "ay";
                Console.WriteLine(nonVowelFirst);
            }
        }


        //simply checks the user input value y as a true to continue run
        //otherwise, reset the doContinue value will be false and exit program
        static void PlayAgain()
        {
            Console.Write("\nContinue? (y/n)\t");
            var exitInput = Char.ToLower(Console.ReadKey().KeyChar);

            if (exitInput != 'y')
            {
                runContinue = false;
                Console.WriteLine("\nGoodBye!\n");
            }
        }       
    }
}
