using MorseCodeTranslator.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var letterToMorsedictionary = JsonDictionaryService.GetLetterToMorseDictionaryFromJson();

            Console.WriteLine("Starting Translator ... ");

            Start(letterToMorsedictionary);
            
        }

        private static void Start(Dictionary<string, string> dictionary)
        {
            while (true)
            {
                var input = GetInput("Enter sentence to convert to morse:\n");

                var morseString = GetMorseFromString(dictionary, input);

                var stringFromMorse = GetStringFromMorse(dictionary, morseString);

                var finalInput = GetInput("Try again?");
                if (finalInput.ToLower() == "no")
                {
                    break;
                }
            }
        }

        private static string GetInput(string description)
        {
            Console.WriteLine(description);
            var userInput = Console.ReadLine();

            return userInput;
        }

        private static string GetMorseFromString(Dictionary<string, string> dictionary, string input)
        {
            Console.WriteLine("\nSentence converted to Morse:");
            var morseString = JsonDictionaryService.GetMorseCodeFromString(dictionary, input);
            Console.WriteLine(morseString);

            return morseString;
        }

        private static string GetStringFromMorse(Dictionary<string, string> dictionary, string morseString)
        {
            Console.WriteLine("\nMorse converted back to sentence:");
            var stringFromMorse = JsonDictionaryService.GetStringFromMorseCode(dictionary, morseString);
            Console.WriteLine($"{stringFromMorse}\n");

            return stringFromMorse;
        }
    }
}
