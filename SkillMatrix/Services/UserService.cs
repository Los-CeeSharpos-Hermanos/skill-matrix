using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.DTOs.Users;
using SkillMatrix.DataAccess;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(long id);
        Task PostUserAsync(FormUserDTO user);
        Task PutUserAsync(long id, FormUserDTO user);
        Task DeleteUserAsync(long id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserAsync(long id)
        {
            var user = await _userRepository.GetUserAsync(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task PostUserAsync(FormUserDTO user)
        {
            User userAdd = new()
            {
                FirstName = user.FirstName,
                SurName = user.SurName,
                Telephone = user.Telephone,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                JobTitle = user.JobTitle,
                Department = await _userRepository.GetDepartmentAsync(user.Department),
                Team = await _userRepository.GetTeamAsync(user.Team)
            };
            userAdd.DepartmentId = userAdd.Department.DepartmentId;
            userAdd.TeamId = userAdd.Team.TeamId;

            LanguageRating tt = new LanguageRating();
            SkillRating skillRating = new SkillRating();

            foreach (LanguageRatingDTO l in user.Languages)
            {
                tt.LanguageId = l.LanguageId;
                tt.UserId = user.Id;
                switch (l.Rating)
                {
                    case 1: tt.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                    case 2: tt.Rating = Domain.Skills.Enums.Rating.Intermediate; break;
                    case 3: tt.Rating = Domain.Skills.Enums.Rating.Advanced; break;
                    default: tt.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                }
                userAdd.LanguageRatings.Add(tt);
            }
            foreach (SkillRatingDTO s in user.Skills)
            {
                skillRating.SkillId = s.SkillId;
                skillRating.UserId = user.Id;
                switch (s.Rating)
                {
                    case 1: skillRating.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                    case 2: skillRating.Rating = Domain.Skills.Enums.Rating.Intermediate; break;
                    case 3: skillRating.Rating = Domain.Skills.Enums.Rating.Advanced; break;
                    default: skillRating.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                }
                userAdd.SkillRatings.Add(skillRating);
            }
            await _userRepository.PostUserAsync(userAdd);

        }

        public async Task PutUserAsync(long id, FormUserDTO user)
        {
            LanguageRating tt = new LanguageRating();
            SkillRating skillRating = new SkillRating();

            var updatedUser = await _userRepository.GetUserAsync(id);

            updatedUser.FirstName = user.FirstName;
            updatedUser.SurName = user.SurName;
            updatedUser.ImageUrl = user.ImageUrl;
            updatedUser.JobTitle = user.JobTitle;
            updatedUser.Telephone = user.Telephone;
            updatedUser.Email = user.Email;
            updatedUser.Department = await _userRepository.GetDepartmentAsync(user.Department);
            updatedUser.Team = await _userRepository.GetTeamAsync(user.Team);

            updatedUser.LanguageRatings.Clear();
            updatedUser.SkillRatings.Clear();

            foreach (LanguageRatingDTO l in user.Languages)
            {
                tt.LanguageId = l.LanguageId;
                tt.UserId = user.Id;
                switch (l.Rating)
                {
                    case 1: tt.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                    case 2: tt.Rating = Domain.Skills.Enums.Rating.Intermediate; break;
                    case 3: tt.Rating = Domain.Skills.Enums.Rating.Advanced; break;
                    default: tt.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                }
                updatedUser.LanguageRatings.Add(tt);
            }
            foreach (SkillRatingDTO s in user.Skills)
            {
                skillRating.SkillId = s.SkillId;
                skillRating.UserId = user.Id;
                switch (s.Rating)
                {
                    case 1: skillRating.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                    case 2: skillRating.Rating = Domain.Skills.Enums.Rating.Intermediate; break;
                    case 3: skillRating.Rating = Domain.Skills.Enums.Rating.Advanced; break;
                    default: skillRating.Rating = Domain.Skills.Enums.Rating.Begginer; break;
                }
                updatedUser.SkillRatings.Add(skillRating);
            }

            await _userRepository.PutUserAsync(id, updatedUser);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
