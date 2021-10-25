using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Users.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentAsync(long id);
        Task PostDepartmentAsync(Department department);
        Task PutDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(long id);
    }
}
