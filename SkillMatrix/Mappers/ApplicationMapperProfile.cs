using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Application.DTOs.Users;

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
            MapLanguageRating();
            MapUsers();
            MapDepartments();
            MapTeams();

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

        private void MapLanguageRating()
        {
            CreateMap<LanguageRating, LanguageRatingDTO>().ReverseMap();
        }

        private void MapTeams()
        {
            CreateMap<Team, TeamDTO>()
                 .ForMember(
                 destination => destination.TeamId,
                 map => map.MapFrom(source => source.TeamId))
                 .ReverseMap();

            CreateMap<FormTeamDTO, Team>().ReverseMap();
        }

        private void MapDepartments()
        {
            CreateMap<Department, DepartmentDTO>()
                .ForMember(
                destination => destination.DepartmentId,
                map => map.MapFrom(source => source.DepartmentId))
                .ReverseMap();
        }

        private void MapUsers()
        {
            CreateMap<User, FormUserDTO>()
                .ForMember(
                destination => destination.Id,
                map => map.MapFrom(source => source.Id))
                .ForMember(
                destination => destination.Department,
                map => map.MapFrom(source => source.Department.DepartmentName))
                .ForMember(
                destination => destination.Team,
                map => map.MapFrom(source => source.Team.TeamName))
                .ForMember(
                dest => dest.Languages,
                map => map.MapFrom(src => src.LanguageRatings))
                .ReverseMap()
                .ForPath(
                destination => destination.Department.DepartmentName,
                map => map.MapFrom(source => source.Department))
                .ForPath(
                destination => destination.Team.TeamName,
                map => map.MapFrom(source => source.Team));

        }
    }
}
