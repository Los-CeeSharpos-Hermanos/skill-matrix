using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Languages.Models;
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
            MapLanguages();

        }

        private void MapSkills()
        {
            CreateMap<Skill, GetSkillDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.SkillId))
                .ForMember(
                d => d.SkillCategory,
                map => map.MapFrom(source => source.SkillCategory.Name))
                .ReverseMap();
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
