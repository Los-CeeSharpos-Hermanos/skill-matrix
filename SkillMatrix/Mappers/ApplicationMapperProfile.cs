using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Languages.Models;
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
            MapLanguages();

        }

        private void MapSkills()
        {
            CreateMap<Skill, GetSkillDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.SkillId))
                .ForMember(
                d => d.SkillCategoryName,
                map => map.MapFrom(source => source.SkillCategory.SkillCategoryName))
                .ForMember(
                d => d.SkillCategoryId,
                map => map.MapFrom(source => source.SkillCategory.SkillCategoryId))
                .ReverseMap();

            CreateMap<FormSkillDTO, Skill>().ReverseMap();
        }

        private void MapSkillCategories()
        {
            CreateMap<SkillCategory, SkillCategoryDropdownDTO>();
        }

        private void MapLanguages()
        {
            CreateMap<Language, LanguageDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.Id))
                .ReverseMap();
        }
    }
}
