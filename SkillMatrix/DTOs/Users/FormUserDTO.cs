using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs.Users
{
    public class FormUserDTO
    {
        public string Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public LanguageRatingDTO[] Languages { get; set; }
        public SkillRatingDTO[] Skills { get; set; }
    }
}
