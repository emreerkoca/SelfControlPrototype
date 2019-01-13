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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region Add Word
        [HttpGet]
        public IActionResult AddWord()
        {
            ViewData["Message"] = "You can add original word and translated word.";

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddWord(Word newWord)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var result = await _wordService.AddWordAsync(newWord);

            if (!result)
            {
                return BadRequest("Could not add word.");
            }

            return RedirectToAction("WordList");
        }
        #endregion

        #region Word List
        public async Task<IActionResult> WordList()
        {
            List<Word> wordList = new List<Word>();
            wordList = await _wordService.GetWordListAsync();

            return View(wordList);
        }
        #endregion

        #region Update Word
        [HttpGet]
        public async Task<IActionResult> UpdateWord(int wordId)
        {
            Word word = new Word();
            word = await _wordService.GetWordByIdAsync(wordId);

            return View(word);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWord(Word updatedWord)
        {
            var result = await _wordService.UpdateWord(updatedWord);
            
            if(!result)
            {
                return BadRequest("Could not update word.");
            }

            return RedirectToAction("WordList");
        }
        #endregion

        #region Delete Word
        public async Task<IActionResult> DeleteWord(int wordId)
        {
            var result = await _wordService.DeleteWord(wordId);

            if (!result)
            {
                return BadRequest("Could not delete word.");
            }

            return RedirectToAction("WordList");

        }
        #endregion

        #region Jump Word
        public async Task<ActionResult> JumpWord()
        {
            Word word = new Word();
            word = await _wordService.GetRandomWordAsync();

            return PartialView("JumpWord",word);
        }

        #endregion
    }
}
