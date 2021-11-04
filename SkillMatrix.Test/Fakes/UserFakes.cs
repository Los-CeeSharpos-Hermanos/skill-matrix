using Bogus;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Test.Fakes;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Test.Services.Users
{
    public class UserFakes
    {
        private long _id;
        private readonly Faker<User> _fakeUser;
        private readonly IEnumerable<Skill> _skills;
        private readonly IEnumerable<Department> _departments;

        private UserFakes(long counter)
        {
            _id = counter;
            _skills = SkillFakes.GetFakeSkills();
            _departments = DepartmentFakes.Create().GenerateManyDepartments(10);

            _fakeUser = GetFakeModel();
        }

        public static UserFakes Create(long counter = 0)
        {
            return new UserFakes(counter);
        }

        public User GetFakeUser()
        {
            return _fakeUser.Generate();
        }

        public List<User> GetFakeUsers(int numberOfUsers)
        {
            return _fakeUser.Generate(numberOfUsers);
        }


        private Faker<User> GetFakeModel()
        {

            return new Faker<User>()
            .RuleFor(u => u.Id, f => _id++)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.SurName, f => f.Name.LastName())
            .RuleFor(u => u.JobTitle, f => f.Name.JobTitle())
            .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.Department, f => f.PickRandom(_departments))
            .RuleFor(u => u.DepartmentId, (f, u) => u.Department.DepartmentId)
            .RuleFor(
                u => u.SkillRatings,
                (f, u) => SkillRatingFakes.Create(u, f.PickRandom(_skills)).GenerateManySkillRatings(10));
        }

    }

}
