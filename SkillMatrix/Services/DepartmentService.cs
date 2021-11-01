using AutoMapper;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillMatrix.DataAccess.Repositories.Users;

namespace SkillMatrix.Application.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentAsync(long id);
        Task PostDepartmentAsync(Department department);
        Task PutDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(long id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDTO>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();

            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public async Task<DepartmentDTO> GetDepartmentAsync(long id)
        {
            var department = await _departmentRepository.GetDepartmentAsync(id);

            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task PostDepartmentAsync(Department department)
        {
            await _departmentRepository.PostDepartmentAsync(department);
        }

        public async Task PutDepartmentAsync(Department department)
        {
            await _departmentRepository.PutDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
