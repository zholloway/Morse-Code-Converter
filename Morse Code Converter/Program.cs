using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morse_Code_Converter
{
    class Program
    {
        public const string pathToTranslations = "translations.csv";

        public static void SaveTranslations(string userString, string translatedUserString)
        {
            using (var writer = new StreamWriter(pathToTranslations, true))
            {
                writer.WriteLine($"{userString},{translatedUserString}");
            }
        }

        //---------//
        //---------//

        static void Main(string[] args)
        {
            Dictionary<int, Morse> morseDecoderDictionary = Morse.MorseDecoderDictionary();

            var keepGoing = true;

            while (keepGoing == true)
            {
                Console.WriteLine("Please write a sentence. I will translate it to Morse code!");
                var userString = Console.ReadLine();

                var translatedUserString = Morse.TranslateEnglishToMorseCode(userString, morseDecoderDictionary);
                Console.WriteLine($"Your translated sentence is: {translatedUserString}");

                SaveTranslations(userString, translatedUserString);

                Console.WriteLine("Your encoded message has been saved. Do you have any more messages you would like to encode? Please type [y]es or [n]o.");
                var userChoice = Console.ReadLine();
                if (userChoice == "y")
                {
                    keepGoing = true;
                }
                else
                {
                    keepGoing = false;
                }
            }
        }
    }
}
