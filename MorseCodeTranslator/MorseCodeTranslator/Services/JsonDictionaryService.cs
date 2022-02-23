using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MorseCodeTranslator.Services
{
    public static class JsonDictionaryService
    {
        public static Dictionary<string, string> GetLetterToMorseDictionaryFromJson()
        {
            using (StreamReader reader = new StreamReader("../../json/alphabetToMorse.json"))
            {
                string json = reader.ReadToEnd();
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                return dictionary;
            }
        }

        public static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var character in dictionary)
            {
                Console.WriteLine($"Key is: {character.Key}\nValue is: {character.Value}\n");
            }
        }

        public static string GetValueFromDictionary(Dictionary<string, string> dictionary, string key)
        {
            dictionary.TryGetValue(key, out string value);
            return value;
        }

        public static string GetValueFromDictionary(Dictionary<string, string> dictionary, char key)
        {
            dictionary.TryGetValue(key.ToString(), out string value);
            return value;
        }

        public static string GetKeyFromDictionary(Dictionary<string, string> dictionary, string value)
        {
            var key = dictionary.FirstOrDefault(KVpair => KVpair.Value == value).Key;
            return key;
        }

        public static string GetMorseCodeFromString(Dictionary<string, string> dictionary, string sentence)
        {
            var morseSentence = string.Empty;
            char[] characters = sentence.ToCharArray();

            foreach (var character in characters)
            {
                morseSentence = $"{morseSentence}|{GetValueFromDictionary(dictionary, character)}";
            }

            return morseSentence;
        }

        public static string GetStringFromMorseCode(Dictionary<string, string> dictionary, string morseString)
        {
            var sentence = string.Empty;
            string[] morseLetters = morseString.Split('|');

            foreach (var character in morseLetters)
            {
                sentence = $"{sentence}{GetKeyFromDictionary(dictionary, character)}";
            }

            return sentence;
        }

    }
}