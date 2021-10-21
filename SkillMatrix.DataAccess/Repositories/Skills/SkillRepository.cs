using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Repositories.Skills
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDBContext _db;

        public SkillRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> AddSkillAsync(Skill skill)
        {
            await _db.Skills.AddAsync(new Skill { SkillName = "Teste", SkillCategoryId = 1 });

            return await _db.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _db.Skills.Where(p => p.SkillId > 0)
                                   .OrderBy(s => s.SkillId)
                                   .ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(long id)
        {
            return await _db.Skills.Where(p => p.SkillId == id).SingleOrDefaultAsync();
        }

        private async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }


    }
}
