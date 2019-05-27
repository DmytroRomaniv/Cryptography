using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyphers
{
    public static class FrequencyAlphabet
    {
        public static string EnglishFrequencyAlphabet = "etaoinsrhdlucmfywgpbvkxqjz";
        public static string UkrainianFrequencyAlphabet = "оанвиіетклрсудмпбгзяєжїйхцчшщьюфґ";

        public static List<double> ListOfEnglishFrequencyValues = new List<double> { 12.02, 9.1, 8.12, 7.68, 7.31, 6.95, 6.28, 6.02, 5.92, 4.32, 3.98, 2.88, 2.71, 2.61, 2.3, 2.11, 2.09, 2.03, 1.82, 1.49, 1.11, 0.69, 0.17, 0.11, 0.1, 0.07 };
        public static List<double> ListOfUkrainianFrequencyValues = new List<double> { 9.28, 8.34, 7.1, 6.23, 6.0, 5.5, 5.48, 4.77, 4.59, 4.57, 4.0, 3.93, 3.38, 3.06, 3.02, 2.84, 2.16, 2.1, 1.83, 1.59, 1.53, 1.24, 1.17, 1.15, 1.02, 0.84, 0.71, 0.71, 0.7, 0.39, 0.35, 0.32, 0.01 };

        public static string GetAlphabet(string message)
        {
            return UkrainianFrequencyAlphabet.Contains(message.FirstOrDefault(c => c != ' ')) ? UkrainianFrequencyAlphabet : EnglishFrequencyAlphabet;
        }
    }
}
