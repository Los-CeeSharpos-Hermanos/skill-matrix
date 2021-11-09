using AutoMapper;
using SkillMatrix.Application.DTOs.Users;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface IUserService
    {
        Task<List<FormUserDTO>> GetUsersAsync();
        Task<FormUserDTO> GetUserAsync(long id);
        Task PostUserAsync(FormUserDTO user);
        Task PutUserAsync(FormUserDTO user);
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

        public async Task<List<FormUserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return _mapper.Map<List<FormUserDTO>>(users);
        }

        public async Task<FormUserDTO> GetUserAsync(long id)
        {
            var user = await _userRepository.GetUserAsync(id);

            return _mapper.Map<FormUserDTO>(user);
        }

        public async Task PostUserAsync(FormUserDTO user)
        {
            User userAdd = _mapper.Map<User>(user);

            await _userRepository.PostUserAsync(userAdd);
        }

        public async Task PutUserAsync(FormUserDTO user)
        {   
            var updatedUser = _mapper.Map<User>(user);

            await _userRepository.PutUserAsync(updatedUser);
        }
            
        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
