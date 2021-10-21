using SkillMatrix.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services
{
    public class LanguageLogic
    {
        private readonly ApplicationDBContext dBContext;

        public LanguageLogic(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

    }
}
