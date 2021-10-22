using SkillMatrix.Domain.Languages.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Languages.Repositories
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetLanguagesAsync();
        Task<Language> GetLanguageAsync(long id);
        Task PostLanguageAsync(Language language);
        Task PutLanguageAsync(long id, Language language);
        Task DeleteLanguageAsync(long id);
    }
}
