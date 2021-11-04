using Bogus;
using SkillMatrix.Domain.Enums;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Test.Fakes
{
    public class SkillRatingFakes
    {
        private readonly Faker<SkillRating> _fakeSkillRating;
        private readonly User _user;
        private readonly Skill _skill;

        private SkillRatingFakes(User user, Skill skill)
        {
            _user = user;
            _skill = skill;
            _fakeSkillRating = GetFakeSkillRatingModel();
        }

        public static SkillRatingFakes Create(User user, Skill skill)
        {
            return new SkillRatingFakes(user, skill);
        }

        public SkillRating GetDepartment()
        {
            return _fakeSkillRating.Generate();
        }

        public List<SkillRating> GenerateManySkillRatings(int totalElements)
        {
            return _fakeSkillRating.Generate(totalElements);
        }

        private Faker<SkillRating> GetFakeSkillRatingModel()
        {

            return new Faker<SkillRating>()
                        .RuleFor(s => s.Rating, f => f.PickRandom<Rating>())
                        .RuleFor(s => s.SkillId, _skill.SkillId)
                        .RuleFor(s => s.Skill, _skill)
                        .RuleFor(s => s.UserId, _user.Id)
                        .RuleFor(s => s.User, _user);

        }
    }
}
