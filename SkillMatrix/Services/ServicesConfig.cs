using Microsoft.Extensions.DependencyInjection;

namespace SkillMatrix.Application.Services
{
    public class ServicesConfig
    {
        public static void ServiceRegistry(IServiceCollection services)
        {
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
