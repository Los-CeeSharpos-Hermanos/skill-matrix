using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;

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
<<<<<<< HEAD
            MapUsers();
            MapDepartments();
            MapTeams();
=======
>>>>>>> main

        }

        private void MapSkills()
        {
            CreateMap<Skill, DTOs.Skills.GetSkillDTO>()
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
<<<<<<< HEAD

        private void MapTeams()
        {
            CreateMap<Team, TeamDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.Id))
                .ReverseMap();
        }

        private void MapDepartments()
        {
            CreateMap<Department, DepartmentDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.Id))
                .ReverseMap();
        }

        private void MapUsers()
        {
            CreateMap<User, UserDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.Id))
                /* .ForMember(
                d => d.Skills,
                map => map.MapFrom(source => source.Skills))
                .ForMember(
                d => d.Languages,
                map => map.MapFrom(source => source.Languages))
                .ForMember(
                d => d.Department,
                map => map.MapFrom(source => source.Department.Id))
                .ForMember(
                d => d.Team,
                map => map.MapFrom(source => source.Team.Id))*/
                .ReverseMap();
        }
=======
>>>>>>> main
    }
}
