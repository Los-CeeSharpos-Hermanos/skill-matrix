using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Repositories.Users
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _db;

        public DepartmentRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _db.Departments.Where(p => p.Id > 0)
                                  .OrderBy(t => t.Id)
                                  .ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(long id)
        {
            return await _db.Departments.FindAsync(id);
        }

        public async Task PostDepartmentAsync(Department department)
        {
            await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
        }

        public async Task PutDepartmentAsync(Department department)
        {
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            Department dbDepartment = await _db.Departments.Where(department => department.Id == id).FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException("$Department not found");
            _db.Departments.Remove(dbDepartment);
            await _db.SaveChangesAsync();
        }
    }
}
