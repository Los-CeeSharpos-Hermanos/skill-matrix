using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.Application.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            MapSkills();

        }

        private void MapSkills()
        {
            CreateMap<Skill, GetSkillDTO>().ForMember(
                d => d.SkillCategory,
                map => map.MapFrom(source => source.SkillCategory.Name));
        }
    }
}
