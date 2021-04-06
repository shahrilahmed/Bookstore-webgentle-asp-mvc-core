using Microsoft.EntityFrameworkCore;
using MvcCoreBookstore.DB;
using MvcCoreBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreBookstore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewLanguage(LanguageModel language)
        {
            var newLanguage = new Language()
            {
                Name = language.Name,
                Description = language.Description
                
            };

            await _context.AddAsync(newLanguage);
            await _context.SaveChangesAsync();
            return newLanguage.Id;
        }
        public async Task<List<LanguageModel>> GetAllLanguages()
        {
            var allLanguages = await _context.Languages.Select(
                x => new LanguageModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }
                ).ToListAsync();

            return allLanguages;
        }

        public async Task<LanguageModel> GetLanguageById(int id)
        {
            var language = await _context.Languages.Where(x => x.Id == id).Select(x => new LanguageModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return language;
        }

        public List<LanguageModel> SearchLanguage(string Name)
        {
            return null;
            //return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();
        }
    }
}
