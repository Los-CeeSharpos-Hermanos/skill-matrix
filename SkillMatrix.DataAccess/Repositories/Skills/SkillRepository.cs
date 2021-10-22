using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain;
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
            await _db.Skills.AddAsync(skill);

            return await SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _db.Skills.Where(p => p.SkillId > 0)
                                   .OrderBy(s => s.SkillId)
                                   .ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(long id)
        {
            return await _db.Skills.FindAsync(id);
        }

        public void UpdateSkill(Skill skill)
        {
            _db.Update(skill);
            SaveChanges();
        }


        public void DeleteSkill(Skill skill)
        {
            _db.Remove(skill);
            SaveChanges();
        }

        public int SaveChanges()
        {
            var entries = _db.ChangeTracker.Entries()
         .Where(e => e.Entity is BaseEntity && (
                 e.State == EntityState.Added
                 || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            }

            return _db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = _db.ChangeTracker.Entries()
         .Where(e => e.Entity is BaseEntity && (
                 e.State == EntityState.Added
                 || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            }

            return await _db.SaveChangesAsync();
        }
    }
}
