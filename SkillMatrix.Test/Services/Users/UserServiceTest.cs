using AutoMapper;
using NSubstitute;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SkillMatrix.Test.Services.Users
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;
        private readonly UserFakes _userFakes;

        public UserServiceTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _mapper = TestStartupHelper.CreateApplicationMapper();
            _userFakes = UserFakes.Create();

        }

        [Fact]
        public async void ShouldReturnUsers()
        {
            //arrange
            var expectedUsers = _userFakes.GetFakeUsers(10);
            _userRepository.ListUsersAsync().Returns(Task.FromResult(expectedUsers));

            var userService = new UserService(_mapper, _userRepository);

            //act
            var results = await userService.ListUsersAsync();
            //assert
            Assert.NotEmpty(results);
            Assert.Equal(expectedUsers.Count, results.Count);

        }

    }
}
