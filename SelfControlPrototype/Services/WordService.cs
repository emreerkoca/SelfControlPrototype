using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfControlPrototype.DataContext;
using SelfControlPrototype.Models;

namespace SelfControlPrototype.Services
{
    public class WordService : IWordService
    {
        private readonly ApplicationDbContext _context;

        public WordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddWordAsync(Word word)
        {
            _context.Word.Add(word);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> DeleteWord(int id)
        {
            var word = await _context.Word.Where(x => x.Id == id).SingleOrDefaultAsync();
            _context.Remove(word);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public async Task<Word> GetWordByIdAsync(int id)
        {
            return await _context.Word.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Word>> GetWordListAsync()
        {
            return (await _context.Word.ToListAsync());
        }

        public async Task<Word> GetRandomWordAsync()
        {
            return await _context.Word.OrderBy(r => Guid.NewGuid()).Skip(2).Take(1).FirstAsync();
        }


        public async Task<bool> UpdateWord(Word word)
        {
            Word selectedWord = await _context.Word.Where(x => x.Id == word.Id).SingleOrDefaultAsync();

            if (selectedWord == null)
                return false; //Write Log Message

            selectedWord.OriginalWord = word.OriginalWord;
            selectedWord.TranslatedWord = word.TranslatedWord;
            selectedWord.Sentence = word.Sentence;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
