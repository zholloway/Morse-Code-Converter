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
            var morseDecoderDictionary = new Dictionary<string, string>();

            using(var reader = new StreamReader(Morse.path))
            {
                while (reader.Peek() > -1)
                {
                    var letterAndCode = reader.ReadLine();
                    Console.WriteLine(letterAndCode);
                    //var split = letterAndCode.Split(",");

                }
            }

            Console.WriteLine("Please write a sentence. I will translate it to Morse code!");
            var userString = Console.ReadLine();
        }
    }
}
