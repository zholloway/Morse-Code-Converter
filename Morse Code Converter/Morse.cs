using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morse_Code_Converter
{
    class Morse
    {
        public const string pathToMorse = "morse.csv";

        public string Letter { get; set; }

        public string Code { get; set; }

        public Morse(string letter, string code)
        {
            Letter = letter;
            Code = code;
        }

        public static Dictionary<int, Morse> MorseDecoderDictionary()
        {
            var morseDecoderDictionary = new Dictionary<int, Morse>();

            using (var reader = new StreamReader(Morse.pathToMorse))
            {
                var i = 0;
                while (reader.Peek() > -1)
                {
                    var letterAndCode = reader.ReadLine();
                    var split = letterAndCode.Split(',');
                    var key = i;
                    var morse = new Morse(split[0], split[1]);
                    morseDecoderDictionary.Add(key, morse);
                    i++;
                }           
            }

            return morseDecoderDictionary;
        }

        public static string TranslateEnglishToMorseCode (string userString, Dictionary<int, Morse> morseDecoderDictionary)
        {
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

            return translatedUserString;
        }

        public static string TranlateMorseCodeToEnglish (string userAttempt, Dictionary<int, Morse> morseDecoderDictionary)
        {
            var translatedUserString = "Sorry, that code does not correspond to an English letter.";

            foreach (KeyValuePair<int, Morse> kvp in morseDecoderDictionary)
            {
                if (userAttempt == kvp.Value.Code)
                {
                    translatedUserString = kvp.Value.Letter;
                }
            }

            return translatedUserString;
        }

        public static string TranslateMultipleMorseCode(string userAttempt, Dictionary<int, Morse> morseDecoderDictionary)
        {
            var letter = String.Empty;
            var individualWordArray = new List<string>();
            var multipleWordArray = new List<string>();
            var completedWord = String.Empty;

            //the last letter wont be saved to the array unless there is a space on the end of the string
            userAttempt += " ";

            //break the userAttempt into an list containing individual letters using delimiter of " "
            foreach (var character in userAttempt)
            {
                var parsedCharacter = character.ToString();

                if ((parsedCharacter != " ") && (parsedCharacter != "/")) 
                {
                   letter += parsedCharacter;                  
                }
                else
                {
                    individualWordArray.Add(letter);
                    letter = String.Empty;
                }
            }

            for (int i = 0; i < individualWordArray.Count(); i++)
            {
               completedWord += TranlateMorseCodeToEnglish(individualWordArray[i], morseDecoderDictionary);
            }

            return completedWord;
        }
    } 
}
