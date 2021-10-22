using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Languages.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: api/<LanguagesController>
        [HttpGet]
        public async Task<IEnumerable<LanguageDTO>> GetAsync()
        {
            return await _languageService.GetLanguagesAsync();
        }

        // GET api/<LanguagesController>/5
        [HttpGet("{id}")]
        public async Task<LanguageDTO> GetLanguage(long id)
        {
            return await _languageService.GetLanguageAsync(id);
        }

        // POST api/<LanguagesController>
        [HttpPost]
        public async Task PostLanguageAsync([FromBody] Language language)
        {
            await _languageService.PostLanguageAsync(language);
        }

        // PUT api/<LanguagesController>/5
        [HttpPut("{id}")]
        public async Task PutLanguageAsync([FromBody] Language language)
        {
            await _languageService.PutLanguageAsync(language);
        }

        // DELETE api/<LanguagesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteLanguageAsync(long id)
        {
            await _languageService.DeleteLanguageAsync(id);
        }
    }
}
