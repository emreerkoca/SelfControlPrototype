using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfControlPrototype.DataContext;
using SelfControlPrototype.Models;
using SelfControlPrototype.Services;

namespace SelfControlPrototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWordService _wordService;

        public HomeController(IWordService wordService)
        {
            _wordService = wordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Word()
        {
            ViewData["Message"] = "You can add original word and translated word.";

            List<Word> wordList = new List<Word>();
            wordList =await _wordService.GetWordListAsync();

            return View(wordList);
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

        [HttpPost]
        public async Task<IActionResult> AddWord(Word newWord)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var result = await _wordService.AddWordAsync(newWord);

            if(!result)
            {
                return BadRequest("Could not add word.");
            }

            return RedirectToAction("Word");
        }
    }
}
