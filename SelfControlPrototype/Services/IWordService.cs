using SelfControlPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfControlPrototype.Services
{
    public interface IWordService
    {
        Task<bool> AddWordAsync(Word word);

        Task<List<Word>> GetWordListAsync();
    }
}
