using AutoMapper;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.DataAccess;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ISkillService
    {
        Task<List<GetSkillDTO>> GetAllSkillsAsync();
        Task<GetSkillDTO> GetSkillByIdAsync(long id);
        Task<int> AddSkillAsync(FormSkillDTO skill);
    }

    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;


        public SkillService(IMapper mapper, ISkillRepository unitOfWork)
        {
            _mapper = mapper;
            _skillRepository = unitOfWork;
        }

        public async Task<int> AddSkillAsync(FormSkillDTO skill)
        {
            var mappedSkill = _mapper.Map<FormSkillDTO, Skill>(skill);

            return await _skillRepository.AddSkillAsync(mappedSkill);
        }

        public async Task<List<GetSkillDTO>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllSkillsAsync();

            return _mapper.Map<List<Skill>, List<GetSkillDTO>>(skills);
        }

        public async Task<GetSkillDTO> GetSkillByIdAsync(long id)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(id);

            return _mapper.Map<GetSkillDTO>(skill);
        }

    }
}
