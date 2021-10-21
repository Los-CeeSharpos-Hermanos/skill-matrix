using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Languages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<LanguageDTO>> Get()
        {
            return await _languageService.GetLanguages();
        }

        // GET api/<LanguagesController>/5
        [HttpGet("{id}")]
        public async Task<LanguageDTO> GetLanguage(long id)
        {
            return await _languageService.GetLanguage(id);
        }

        // POST api/<LanguagesController>
        [HttpPost]
        public async Task PostLanguage([FromBody] Language language)
        {
            await _languageService.PostLanguage(language);
        }

        // PUT api/<LanguagesController>/5
        [HttpPut("{id}")]
        public async Task PutLanguage(long id, [FromBody] Language language)
        {
            await _languageService.PutLanguage(id, language);
        }

        // DELETE api/<LanguagesController>/5
        [HttpDelete("{id}")]
        public async Task DeleteLanguage(long id)
        {
            await _languageService.DeleteLanguage(id);
        }
    }
}
