using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyphers.Algorithms
{
    public static class CeasarAlgorithm
    {
        public static string Encode(string message, int numberOfMoves)
        {
            var encodedMessage = new StringBuilder();
            var alphabet = Alphabet.GetAlphabet(message);

            foreach (var character in message)
            {
                if (alphabet.Contains(character))
                {
                    var index = (alphabet.IndexOf(character) + numberOfMoves) % alphabet.Length;
                    var encodedCharacter = alphabet.ElementAt(index);
                    encodedMessage.Append(encodedCharacter);
                }
            }

            return encodedMessage.ToString();
        }

        public static string Decode(string message, int numberOfMoves)
        {
            var decodedMessage = new StringBuilder();
            var alphabet = Alphabet.GetAlphabet(message);

            foreach (var character in message)
            {
                if (alphabet.Contains(character))
                {
                    var index = alphabet.IndexOf(character) - (numberOfMoves % alphabet.Length);
                    if (index < 0)
                        index = alphabet.Length + index;

                    var encodedCharacter = alphabet.ElementAt(index);
                    decodedMessage.Append(encodedCharacter);
                }
            }

            return decodedMessage.ToString();
        }
    }
}
