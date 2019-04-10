using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaesarCipherWebApp.Models;
using System.Text;

namespace CaesarCipherWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View(new CipherViewModel());
        }

        [HttpPost]
        public IActionResult Index(CipherViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            model.TextIn = model.ActionType == "Зашифровать" ? Encipher(model.TextIn, model.Shift) : Decipher(model.TextIn, model.Shift);
            ModelState.Clear();
            return View(model);
        }
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }
            char d = char.IsUpper(ch) ? 'А' : 'а';
            return (char)((((ch + key) - d) % 33) + d);


        }
        public static string Encipher(string input, int key)
        {
            StringBuilder output = new StringBuilder();

            foreach (char ch in input)
                output.Append(cipher(ch, key));

            return output.ToString();
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 33 - key);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
