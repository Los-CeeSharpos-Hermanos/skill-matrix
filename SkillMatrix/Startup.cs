using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SkillMatrix.Application.Mappers;
using SkillMatrix.Application.Services;
using SkillMatrix.DataAccess;
using SkillMatrix.DataAccess.Infrastructures;
using SkillMatrix.Application.Services.Authentication;

namespace SkillMatrix.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            DataAccessConfig.Registry(services, Configuration);


            services.AddAutoMapper(typeof(ApplicationMapperProfile));

            services.AddScoped<ISkillService, SkillService>();

            services.AddScoped<ISkillCategoryService, SkillCategoryService>();

            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITeamService, TeamService>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.ConfigureAuthentication(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skill Matrix API", Version = "v1" });
                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "`Token only!!!` - without `Bearer_` prefix",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                UpdateDatabase(app);

                app.UseDeveloperExceptionPage();

                app.UseCors(options => options.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials());
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Skill Matrix API V1");

            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            var dbContext = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
            dbContext.UpdateDatabase();
        }
    }
}
