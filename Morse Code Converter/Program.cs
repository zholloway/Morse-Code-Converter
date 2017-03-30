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

            Console.WriteLine("Enter [1] for encoding or [2] for decoding");
            var whichOne = Console.ReadLine();

            if(whichOne == "1")
            {
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
            else
            {
                Console.WriteLine("Decode the following sentence by typing morse code. If it is a letter, it will be translated to English. Try to crack the code!");
                Console.WriteLine("... . . /... .... .- .-. .--.");
                 
                var userTranslationSoFar = String.Empty;

                while (userTranslationSoFar.ToLower() != "see sharp")
                {
                    var userAttempt = Console.ReadLine();

                    //var translatedUserAttempt = Morse.TranlateMorseCodeToEnglish(userAttempt, morseDecoderDictionary);
                    var translatedUserAttempt = Morse.TranslateMultipleMorseCode(userAttempt, morseDecoderDictionary);
                   
                    Console.WriteLine($"Your code turned out to be... {translatedUserAttempt}");

                    /*
                    if (translatedUserAttempt != "Sorry, your code does not match an English letter.")
                    {
                        userTranslationSoFar += translatedUserAttempt;
                    }
                    */

                    userTranslationSoFar = translatedUserAttempt;

                    Console.WriteLine($"So far you've put together: {userTranslationSoFar}");

                    if (userTranslationSoFar == "see sharp")
                    {
                        Console.WriteLine("You translated the message! Goodbye.");
                        Console.ReadLine();
                    }
                }               
            }        
        }
    }
}
