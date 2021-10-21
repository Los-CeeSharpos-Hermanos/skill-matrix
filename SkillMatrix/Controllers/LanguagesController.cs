using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.Services;
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
        private readonly LanguageLogic languageLogic;

        public LanguagesController(LanguageLogic languageLogic)
        {
            this.languageLogic = languageLogic;
        }

        // GET: api/<LanguagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LanguagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LanguagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LanguagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
