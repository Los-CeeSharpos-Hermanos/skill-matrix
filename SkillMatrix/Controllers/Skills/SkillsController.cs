using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<GetSkillDTO>> Get()
        {
            return await _skillService.GetAllSkillsAsync();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<GetSkillDTO> Get(long id)
        {
            return await _skillService.GetSkillByIdAsync(id);
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
