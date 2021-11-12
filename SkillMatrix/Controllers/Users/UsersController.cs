using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.DTOs.Users;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<FormUserDTO>> GetAsync()
        {
            return await _userService.GetUsersAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<FormUserDTO> GetUserAsync(string id)
        {
            return await _userService.GetUserAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task PostUserAsync([FromBody] FormUserDTO user, string password)
        {
            await _userService.PostUserAsync(user, password);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task PutUserAsync([FromBody] FormUserDTO user, [FromHeader] string userName)
        {
            user.UserName = userName;
            await _userService.PutUserAsync(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task DeleteUserAsync(string id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}
