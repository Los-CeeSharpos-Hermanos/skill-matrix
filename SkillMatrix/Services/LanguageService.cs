using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Languages.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ILanguageService
    {
        Task<List<LanguageDTO>> GetLanguagesAsync();
        Task<LanguageDTO> GetLanguageAsync(long id);
        Task PostLanguageAsync(Language language);
        Task PutLanguageAsync(Language language);
        Task DeleteLanguageAsync(long id);
    }


    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<List<LanguageDTO>> GetLanguagesAsync()
        {
            var languages = await _languageRepository.GetLanguagesAsync();

            return _mapper.Map<List<LanguageDTO>>(languages);
        }

        public async Task<LanguageDTO> GetLanguageAsync(long id)
        {
            var language = await _languageRepository.GetLanguageAsync(id);

            return _mapper.Map<LanguageDTO>(language);
        }

        public async Task PostLanguageAsync(Language language)
        {
            await _languageRepository.PostLanguageAsync(language);

        }

        public async Task PutLanguageAsync(Language language)
        {
            await _languageRepository.PutLanguageAsync(language);
        }

        public async Task DeleteLanguageAsync(long id)
        {
            await _languageRepository.DeleteLanguageAsync(id);
        }
    }
}
