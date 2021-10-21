using AutoMapper;
using NSubstitute;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Mappers;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SkillMatrix.Test.Services
{

    public class SkillServiceTest
    {
        private readonly IMapper _mapper;

        private readonly ISkillRepository _skillRepository;

        public SkillServiceTest()
        {
            _skillRepository = Substitute.For<ISkillRepository>();
            _mapper = TestStartupHelper.CreateApplicationMapper();

        }

        [Fact]
        public async void ShouldReturnSkills()
        {
            //Arrange
            var expectedSkills = GetFakeSkills();
            _skillRepository.GetAllSkillsAsync().Returns(Task.FromResult(expectedSkills));

            var skillService = new SkillService(_skillRepository, _mapper);

            //Act
            var skills = await skillService.GetAllSkillsAsync();

            //Assert
            Assert.NotEmpty(skills);
            Assert.Equal(expectedSkills.Count, skills.Count);
            Assert.All(skills, result => Assert.IsType<GetSkillDTO>(result));
        }

        [Fact]
        public async void ShouldReturnSkillTheSkillWithId()
        {
            //Arrange
            var id = 1;
            var expectedSkill = GetFakeSkills().Where(x => x.SkillId == id).Single();
            _skillRepository.GetSkillByIdAsync(id).Returns(Task.FromResult(expectedSkill));

            var skillService = new SkillService(_skillRepository, _mapper);

            //Act
            var skill = await skillService.GetSkillByIdAsync(id);

            //Assert
            Assert.IsType<GetSkillDTO>(skill);
            Assert.Equal(expectedSkill.SkillId, skill.Id);
        }

        public List<Skill> GetFakeSkills()
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

        public List<SkillCategory> GetFakeSkillCategories()
        {
            return new List<SkillCategory>
            {
                new SkillCategory
                {

                   SkillCategoryId = 1,
                   Name = "Technical Skills",
                   CreatedAt = DateTime.Now
                },                new SkillCategory
                {

                   SkillCategoryId = 2,
                   Name = "Soft Skills",
                   CreatedAt = DateTime.Now
                }
            };
        }
    }
}
