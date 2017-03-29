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
        public const string path = "morse.csv";

        public string Letter { get; set; }

        public string Code { get; set; }

        public static Dictionary<string, string> MorseDecoderDictionary()
        {
            var morseDecoderDictionary = new Dictionary<string, string>();

            using (var reader = new StreamReader(Morse.path))
            {
                while (reader.Peek() > -1)
                {
                    var letterAndCode = reader.ReadLine();
                    Console.WriteLine(letterAndCode);
                    var split = letterAndCode.Split(',');
                    var letter = split[0];
                    var code = split[1];
                    morseDecoderDictionary.Add(letter, code);
                }
            }

            return morseDecoderDictionary;
        }
    } 
}
