using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cryptography.Models;
using Cyphers.Algorithms;
using Cyphers;

namespace Cryptography.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ceasar()
        {
            var inputForm = new CeasarInputModel();
            return View(inputForm);
        }


        [HttpPost]
        public IActionResult Ceasar(CeasarInputModel inputModel)
        {
            var resultForm = new ResultViewModel
            {
                LeftTitle = $"Encoded message with key: {inputModel.NumberOfMoves}",
                LeftMessage = CeasarAlgorithm.Encode(inputModel.Message.ToLower(), inputModel.NumberOfMoves),
                RightTitle = $"Decoded message with key: {inputModel.NumberOfMoves}"
            };

            resultForm.RightMessage = CeasarAlgorithm.Decode(resultForm.LeftMessage, inputModel.NumberOfMoves);

            return View("Index", resultForm);
        }

        [HttpGet]
        public IActionResult Vigenere()
        {
            var inputForm = new VigenereInputModel();
            return View(inputForm);
        }

        [HttpPost]
        public IActionResult Vigenere(VigenereInputModel inputModel)
        {
            var resultForm = new ResultViewModel
            {
                LeftTitle = $"Encoded message with key: {inputModel.Key}",
                LeftMessage = VigenereCypher.Encode(inputModel.Message.ToLower(), inputModel.Key),
                RightTitle = $"Decoded message with key: {inputModel.Key}"
            };

            resultForm.RightMessage = VigenereCypher.Decode(resultForm.LeftMessage, inputModel.Key);

            return View("Index", resultForm);
        }

        [HttpGet]
        public IActionResult FrequencyAlgorithm(string message)
        {
            var resultForm = new ResultViewModel
            {
                LeftTitle = "Encoded message",
                RightTitle = "Frequency table",
                RightMessage = FrequencyTable()
            };

            resultForm.LeftMessage = FrequencyAnalysis.Encode(message);

            return View("Index", resultForm);
        }

        private string FrequencyTable()
        {
            var table = "<table class=\"table\"><thead><tr><th scope=\"col\">English Letter</th><th scope=\"col\">Frequency</th><th scope=\"col\">Ukrainian Letter</th><th scope=\"col\">Frequency</th></tr><tbody>";
            for (var i =0; i< FrequencyAlphabet.ListOfUkrainianFrequencyValues.Count(); i++)
            {
                var row = "<tr>";

                if(i < FrequencyAlphabet.ListOfEnglishFrequencyValues.Count())
                {
                    row += $"<td>{FrequencyAlphabet.EnglishFrequencyAlphabet[i]}</td><td>{FrequencyAlphabet.ListOfEnglishFrequencyValues[i]}</td>";
                }
                else
                {
                    row += $"<td></td><td></td>";
                }

                row+= $"<td>{FrequencyAlphabet.UkrainianFrequencyAlphabet[i]}</td><td>{FrequencyAlphabet.ListOfUkrainianFrequencyValues[i]}</td></tr>";

                table += row;
            }

            table += "</tbody></table>";

            return table;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
