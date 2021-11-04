using SkillMatrix.Domain.Skills.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillMatrix.Test.Fakes
{
    public static class SkillFakes
    {
        public static List<Skill> GetFakeSkills()
        {
            return new List<Skill>
            {
                new Skill
                {
                   SkillId = 1,
                   SkillName = "C#",
                   SkillCategoryId = 1,
                   SkillCategory = GetFakeSkillCategories().Where(c => c.SkillCategoryId == 1).SingleOrDefault(),
                },
                new Skill
                {
                   SkillId = 2,
                   SkillName = "Team Play",
                   SkillCategoryId = 2,
                   SkillCategory = GetFakeSkillCategories().Where(c => c.SkillCategoryId == 2).SingleOrDefault(),
                },
                new Skill
                {
                   SkillId = 3,
                   SkillName = "Java",
                   SkillCategoryId = 3,
                   SkillCategory = GetFakeSkillCategories().Where(c => c.SkillCategoryId == 3).SingleOrDefault(),
                }
            };
        }

        public static List<SkillCategory> GetFakeSkillCategories()
        {
            return new List<SkillCategory>
            {
                new SkillCategory
                {

                   SkillCategoryId = 1,
                   SkillCategoryName = "Technical Skills",
                   CreatedAt = DateTime.Now
                },                new SkillCategory
                {

                   SkillCategoryId = 2,
                   SkillCategoryName = "Soft Skills",
                   CreatedAt = DateTime.Now
                }
            };
        }
    }
}
