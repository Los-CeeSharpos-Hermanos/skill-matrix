using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Repositories.Skills
{
    public class SkillCategoryRepository : ISkillCategoryRepository
    {
        private readonly ApplicationDBContext _db;

        public SkillCategoryRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<SkillCategory>> GetAllSkillCategoriesAsync()
        {
            return await _db.SkillCategories.Where(p => p.SkillCategoryId > 0)
                                        .OrderBy(s => s.SkillCategoryId)
                                        .ToListAsync();
        }
    }
}
