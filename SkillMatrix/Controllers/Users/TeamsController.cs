using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IEnumerable<TeamDTO>> GetAsync()
        {
            return await _teamService.GetTeamsAsync();
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<TeamDTO> GetTeamAsync(long id)
        {
            return await _teamService.GetTeamAsync(id);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task PostTeamAsync([FromBody] Team team)
        {
            await _teamService.PostTeamAsync(team);
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task PutTeamAsync([FromBody] Team team)
        {
            await _teamService.PutTeamAsync(team);
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteTeamAsync(long id)
        {
            await _teamService.DeleteTeamAsync(id);
        }
    }
}
