using Bogus;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Test.Fakes
{
    public class DepartmentFakes
    {
        private long _departmentId;
        private readonly Faker<Department> _fakeDepartment;

        private DepartmentFakes(long departmentId)
        {
            _departmentId = departmentId;
            _fakeDepartment = GetFakeDepartmentModel();
        }

        public static DepartmentFakes Create(long departmentId = 1)
        {
            return new DepartmentFakes(departmentId);
        }

        public Department GetDepartment()
        {
            return _fakeDepartment.Generate();
        }

        public List<Department> GenerateManyDepartments(int numberOfDepartments)
        {
            return _fakeDepartment.Generate(numberOfDepartments);
        }

        private Faker<Department> GetFakeDepartmentModel()
        {
            return new Faker<Department>()
                        .RuleFor(d => d.DepartmentId, f => _departmentId++)
                        .RuleFor(d => d.DepartmentName, f => f.Name.JobArea())
                        .RuleFor(d => d.CreatedAt, f => f.Date.Recent())
                        .RuleFor(d => d.UpdatedAt, DateTime.Now);
        }
    }
}
