using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyphers.Algorithms
{
    public static class FrequencyAnalysis
    {
        public static string Encode (string message)
        {
            var alphabet = FrequencyAlphabet.GetAlphabet(message);
            var index = 0;
            var groupedMessage = message.GroupBy(e => e).OrderByDescending(e => e.Count());

            foreach(var character in groupedMessage)
            {
                message = message.Replace(character.FirstOrDefault(), char.ToUpperInvariant(alphabet[index]));
                index++;
            }

            return message;
        }
    }
}
