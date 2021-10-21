using AutoMapper;
using SkillMatrix.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Test
{

    public static class TestStartupHelper
    {
        public static IMapper CreateApplicationMapper()
        {
            var applicationMapperProfile = new ApplicationMapperProfile();
            var autoMapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(applicationMapperProfile));


            return autoMapperConfig.CreateMapper();
        }

    }
}
