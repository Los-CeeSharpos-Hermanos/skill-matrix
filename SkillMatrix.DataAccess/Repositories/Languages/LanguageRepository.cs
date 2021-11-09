using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Languages.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Repositories.Languages
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDBContext _db;

        public LanguageRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Language>> GetLanguagesAsync()
        {
            return await _db.Languages.Where(p => p.Id > 0)
                                      .OrderBy(l => l.Name)
                                      .ToListAsync();
        }

        public async Task<Language> GetLanguageAsync(long id)
        {
            return await _db.Languages.FindAsync(id);
        }

        public async Task PostLanguageAsync(Language language)
        {
            await _db.Languages.AddAsync(language);
            await _db.SaveChangesAsync();
        }

        public async Task PutLanguageAsync(Language language)
        {
            _db.Languages.Update(language);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteLanguageAsync(long id)
        {
            Language dbLanguage = await _db.Languages.Where(l => l.Id == id).FirstOrDefaultAsync()
                    ?? throw new KeyNotFoundException($"Language not found");
            _db.Languages.Remove(dbLanguage);
            await _db.SaveChangesAsync();
        }
    }
}
