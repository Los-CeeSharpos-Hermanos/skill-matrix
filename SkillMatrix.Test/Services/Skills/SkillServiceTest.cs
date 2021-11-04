using AutoMapper;
using NSubstitute;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Application.Mappers;
using SkillMatrix.Application.Services;
using SkillMatrix.DataAccess;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using SkillMatrix.Test.Fakes;
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
            var expectedSkills = SkillFakes.GetFakeSkills();
            _skillRepository.GetAllSkillsAsync().Returns(Task.FromResult(expectedSkills));

            var skillService = new SkillService(_mapper, _skillRepository);

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
            var expectedSkill = SkillFakes.GetFakeSkills().Where(x => x.SkillId == id).Single();
            _skillRepository.GetSkillByIdAsync(id).Returns(Task.FromResult(expectedSkill));

            var skillService = new SkillService(_mapper, _skillRepository);

            //Act
            var skill = await skillService.GetSkillByIdAsync(id);

            //Assert
            Assert.IsType<GetSkillDTO>(skill);
            Assert.Equal(expectedSkill.SkillId, skill.Id);
        }

    }
}
