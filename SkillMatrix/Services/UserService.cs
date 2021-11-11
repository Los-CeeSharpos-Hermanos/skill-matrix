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
        Task<List<FormUserDTO>> GetUsersAsync();
        Task<FormUserDTO> GetUserAsync(string id);
        Task PostUserAsync(FormUserDTO user, string password);
        Task PutUserAsync(FormUserDTO user);
        Task DeleteUserAsync(string id);
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

        public async Task<List<FormUserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return _mapper.Map<List<FormUserDTO>>(users);
        }

        public async Task<FormUserDTO> GetUserAsync(string id)
        {
            var user = await _userRepository.GetUserAsync(id);

            return _mapper.Map<FormUserDTO>(user);
        }

        public async Task PostUserAsync(FormUserDTO user, string password)
        {
            User userAdd = _mapper.Map<User>(user);

            await _userRepository.CreateUserAsync(userAdd, password);
        }

        public async Task PutUserAsync(FormUserDTO user)
        {
            var updatedUser = await _userRepository.GetUserAsync(user.Id);

            updatedUser = _mapper.Map<User>(user);

            await _userRepository.UpdateUserAsync(updatedUser);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
