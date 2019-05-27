using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyphers.Algorithms
{
    public static class VigenereCypher
    {
        public static string Encode(string message, string key)
        {
            var alphabet = Alphabet.GetAlphabet(message);
            var encodedMessage = new StringBuilder();

            for(var i = 0; i< message.Length; i++)
            {
                var index = (alphabet.IndexOf(message[i]) + alphabet.IndexOf(key[i % key.Length])) % alphabet.Length;
                encodedMessage.Append(alphabet.ElementAt(index));
            }

            return encodedMessage.ToString();
        }

        public static string Decode(string message, string key)
        {
            var alphabet = Alphabet.GetAlphabet(message);
            var decodedMessage = new StringBuilder();

            for (var i = 0; i < message.Length; i++)
            {
                var index = (alphabet.IndexOf(message[i]) + alphabet.Length - alphabet.IndexOf(key[i % key.Length])) % alphabet.Length;
                decodedMessage.Append(alphabet.ElementAt(index));
            }

            return decodedMessage.ToString();
        }
    }
}
