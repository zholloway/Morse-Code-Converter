﻿using System;
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
            Dictionary<string, string> morseDecoderDictionary = Morse.MorseDecoderDictionary();

            Console.WriteLine("Please write a sentence. I will translate it to Morse code!");
            var userString = Console.ReadLine();
        }
    }
}
