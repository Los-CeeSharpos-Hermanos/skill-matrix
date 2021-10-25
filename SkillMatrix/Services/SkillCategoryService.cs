using AutoMapper;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ISkillCategoryService
    {
        Task<List<SkillCategory>> GetAllSkillCategoriesAsync();
        Task<List<SkillCategoryDropdownDTO>> GetDropdownSkillCategoriesAsync();

    }

    public class SkillCategoryService : ISkillCategoryService
    {
        private readonly ISkillCategoryRepository _skillCategoryRepository;
        private readonly IMapper _mapper;


        public SkillCategoryService(ISkillCategoryRepository skillCategoryRepository, IMapper mapper)
        {
            _skillCategoryRepository = skillCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SkillCategory>> GetAllSkillCategoriesAsync()
        {
            var skillCategories = await _skillCategoryRepository.GetAllSkillCategoriesAsync();
            return skillCategories;
        }

        public async Task<List<SkillCategoryDropdownDTO>> GetDropdownSkillCategoriesAsync()
        {
            var skillCategories = await _skillCategoryRepository.GetAllSkillCategoriesAsync();
            return _mapper.Map<List<SkillCategoryDropdownDTO>>(skillCategories);
        }
    }
}
