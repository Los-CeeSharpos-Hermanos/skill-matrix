using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.DataAccess;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Languages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ILanguageService
    {
        Task<List<LanguageDTO>> GetLanguages();
        Task<LanguageDTO> GetLanguage(long id);
        Task PostLanguage(Language language);
        Task PutLanguage(long id, Language language);
        Task DeleteLanguage(long id);
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

        public async Task<List<LanguageDTO>> GetLanguages()
        {
            var languages = await _languageRepository.GetLanguagesAsync();

            return _mapper.Map<List<LanguageDTO>>(languages);
        }

        public async Task<LanguageDTO> GetLanguage(long id)
        {
            var language = await _languageRepository.GetLanguageAsync(id);

            return _mapper.Map<LanguageDTO>(language);
        }

        public async Task PostLanguage(Language language)
        {
            await _languageRepository.PostLanguageAsync(language);

        }

        public async Task PutLanguage(long id, Language language)
        {
            await _languageRepository.PutLanguageAsync(id, language);
        }

        public async Task DeleteLanguage(long id)
        {
            await _languageRepository.DeleteLanguageAsync(id);
        }
    }
}
