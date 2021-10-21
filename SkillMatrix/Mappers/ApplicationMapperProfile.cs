using AutoMapper;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.Application.Mappers
{
    public class ApplicationMapperProfile : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public ApplicationMapperProfile()
        {
            MapSkills();
            MapSkillCategories();
        }

        private void MapSkills()
        {
            CreateMap<Skill, GetSkillDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.SkillId))
                .ForMember(
                d => d.SkillCategory,
                map => map.MapFrom(source => source.SkillCategory.SkillCategoryName))
                .ReverseMap();

            CreateMap<FormSkillDTO, Skill>().ReverseMap();
        }

        private void MapSkillCategories()
        {
            CreateMap<SkillCategory, SkillCategoryDropdownDTO>();
        }
    }
}
