using AutoMapper;
using NSubstitute;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using SkillMatrix.Test.Fakes;
using System.Threading.Tasks;
using Xunit;

namespace SkillMatrix.Test.Services
{
    public class SkillCategoryServiceTest
    {
        private readonly ISkillCategoryRepository _skillCategoryRepository;
        private readonly IMapper _mapper;

        public SkillCategoryServiceTest()
        {
            _skillCategoryRepository = Substitute.For<ISkillCategoryRepository>();
            _mapper = TestStartupHelper.CreateApplicationMapper();
        }

        [Fact]
        public async void ShouldReturnAllSkillCategories()
        {
            //Arrange
            var expectedSkillCategories = SkillFakes.GetFakeSkillCategories();
            _skillCategoryRepository.GetAllSkillCategoriesAsync().Returns(Task.FromResult(expectedSkillCategories));

            var skillCategoryService = new SkillCategoryService(_skillCategoryRepository, _mapper);

            //Act
            var skillCategories = await skillCategoryService.GetAllSkillCategoriesAsync();

            //Assert
            Assert.NotEmpty(skillCategories);
            Assert.Equal(expectedSkillCategories.Count, skillCategories.Count);
            Assert.All(skillCategories, result => Assert.IsType<SkillCategory>(result));

        }

        [Fact]
        public async void ShouldReturnAllDropdownSkillCategories()
        {
            //Arrange
            var expectedSkillCategories = SkillFakes.GetFakeSkillCategories();
            _skillCategoryRepository.GetAllSkillCategoriesAsync().Returns(Task.FromResult(expectedSkillCategories));

            var skillCategoryService = new SkillCategoryService(_skillCategoryRepository, _mapper);

            //Act
            var skillCategories = await skillCategoryService.GetDropdownSkillCategoriesAsync();

            //Assert
            Assert.NotEmpty(skillCategories);
            Assert.Equal(expectedSkillCategories.Count, skillCategories.Count);
            Assert.All(skillCategories, result => Assert.IsType<SkillCategoryDropdownDTO>(result));

        }
    }
}
