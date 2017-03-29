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
        static void Main(string[] args)
        {
            Dictionary<int, Morse> morseDecoderDictionary = Morse.MorseDecoderDictionary();

            Console.WriteLine("Please write a sentence. I will translate it to Morse code!");
            var userString = Console.ReadLine();

            var translatedUserString = String.Empty;

            foreach (var character in userString.ToUpper())
            {
                var stringLetter = character.ToString();

                foreach (KeyValuePair<int, Morse> kvp in morseDecoderDictionary)
                {
                    if (stringLetter == kvp.Value.Letter)
                    {
                        translatedUserString += kvp.Value.Code;
                    }
                }
            }

            Console.WriteLine($"Your translated sentence is: {translatedUserString}");

            Console.ReadLine();
        }
    }
}
