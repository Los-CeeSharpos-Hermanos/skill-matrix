using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers.Skills
{


    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        // GET: api/<SkillsController>
        [HttpGet]
        public IEnumerable<GetSkillDTO> Get()
        {
            return _skillService.GetAllSkills();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SkillsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SkillsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SkillsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
