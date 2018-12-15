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

        public async Task<List<Word>> GetWordListAsync()
        {
            List<Word> wordList = new List<Word>();

            return (await _context.Word.ToListAsync());
        }
    }
}
