using SkillMatrix.Domain.Skills.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skills.Repositories
{
    public interface ISkillCategoryRepository
    {
        Task<List<SkillCategory>> GetAllSkillCategoriesAsync();

    }
}
