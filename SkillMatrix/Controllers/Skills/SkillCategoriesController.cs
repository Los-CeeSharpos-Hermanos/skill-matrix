using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers.Skills
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class SkillCategoriesController : ControllerBase
    {
        private readonly ISkillCategoryService _skillCategoryService;

        public SkillCategoriesController(ISkillCategoryService skillCategoryService)
        {
            _skillCategoryService = skillCategoryService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("dropdown-skill-categories")]
        public async Task<IEnumerable<SkillCategoryDropdownDTO>> GetDropdownSkillCategories()
        {
            return await _skillCategoryService.GetDropdownSkillCategoriesAsync();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
