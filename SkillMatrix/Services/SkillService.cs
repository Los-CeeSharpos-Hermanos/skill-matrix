using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ISkillService
    {
        Task<List<GetSkillDTO>> GetAllSkills();
    }

    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSkillDTO>> GetAllSkills()
        {
            var skills = await _skillRepository.GetAllSkillsAsync();

            return _mapper.Map<List<GetSkillDTO>>(skills);
        }

    }
}
