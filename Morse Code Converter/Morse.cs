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

        public Morse(string letter, string code)
        {
            Letter = letter;
            Code = code;
        }

        public static Dictionary<int, Morse> MorseDecoderDictionary()
        {
            var morseDecoderDictionary = new Dictionary<int, Morse>();

            using (var reader = new StreamReader(Morse.path))
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
    } 
}
