using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Controllers.Skills
{
    [Authorize]
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
        public async Task Post([FromBody] FormSkillDTO skill)
        {
            await _skillService.AddSkillAsync(skill);
        }

        // PUT api/<SkillsController>/5
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody] FormSkillDTO skill)
        {
            IsValidId(id);

            await _skillService.UpdateSkillAsync(id, skill);
        }

        // DELETE api/<SkillsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            IsValidId(id);
            await _skillService.RemoveSkillAsync(id);
        }

        private void IsValidId(long id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid id value");
            }
        }
    }
}
