using AutoMapper;
using SkillMatrix.Application.DTOs;
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
        Task PostUserAsync(User user);
        Task PutUserAsync(User user);
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

        public async Task PostUserAsync(User user)
        {
            await _userRepository.PostUserAsync(user);

        }

        public async Task PutUserAsync(User user)
        {
            await _userRepository.PutUserAsync(user);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
