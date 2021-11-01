using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs;
using SkillMatrix.Application.Services;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillMatrix.Application.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IEnumerable<DepartmentDTO>> GetAsync()
        {
            return await _departmentService.GetDepartmentsAsync();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<DepartmentDTO> GetDepartmentAsync(long id)
        {
            return await _departmentService.GetDepartmentAsync(id);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task PostDepartmentAsyn([FromBody] Department department)
        {
            await _departmentService.PostDepartmentAsync(department);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task PutDepartmentAsync([FromBody] Department department)
        {
            await _departmentService.PutDepartmentAsync(department);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDepartmentAsync(long id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
        }
    }
}
