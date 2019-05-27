using System;
using Cyphers;

namespace TEst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UkrainianAlphabet.NumberCharacterPairs[0]);
            Console.WriteLine(Alphabet.NumberCharacterPairs[20]);
            Console.WriteLine(UkrainianAlphabet.CharacterNumberPairs['і']);
            Console.WriteLine(Alphabet.CharacterNumberPairs['z']);
            Console.WriteLine("Hello World!");
        }
    }
}
