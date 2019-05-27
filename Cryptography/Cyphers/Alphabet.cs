using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyphers
{
    public static class Alphabet
    {
        public static string EnglishAlphabet = " abcdefghijklmnopqrstuvwxyz";

        public static string UkrainianAlphabet = " абвгґдеєжзиіїйклмнопрстуфцшщьюя";

        public static string GetAlphabet(string message)
        {
            return UkrainianAlphabet.Contains(message.FirstOrDefault(c => c != ' ')) ? UkrainianAlphabet : EnglishAlphabet;
        }
    }
}
