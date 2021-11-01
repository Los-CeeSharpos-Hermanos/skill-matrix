using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Teams;
using SkillMatrix.Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetTeamsAsync();
        Task<TeamDTO> GetTeamAsync(long id);
        Task PostTeamAsync(Team team);
        Task PutTeamAsync(Team team);
        Task DeleteTeamAsync(long id);
    }
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<List<TeamDTO>> GetTeamsAsync()
        {
            var teams = await _teamRepository.GetTeamsAsync();

            return _mapper.Map<List<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetTeamAsync(long id)
        {
            var team = await _teamRepository.GetTeamAsync(id);

            return _mapper.Map<TeamDTO>(team);
        }

        public async Task PostTeamAsync(Team team)
        {
            await _teamRepository.PostTeamAsync(team);
        }

        public async Task PutTeamAsync(Team team)
        {
            await _teamRepository.PutTeamAsync(team);
        }

        public async Task DeleteTeamAsync(long id)
        {
            await _teamRepository.DeleteTeamAsync(id);
        }
    }
}
