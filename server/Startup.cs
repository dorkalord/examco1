using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Services;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(x => x.UseSqlServer(
                @"Server=tcp:examcodb.database.windows.net,1433;Initial Catalog=ExamcoDB;Persist Security Info=False;
                    User ID=examcoadmin;Password=goodWhal323;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

                /*Data Source=DESKTOP-BP7LGIN;Initial Catalog=examco9;
                Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" /**/

                ));
                
            services.AddMvc();
            services.AddAutoMapper();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IGeneralCritereaService, GeneralCritereaService>();
            services.AddScoped<IAdviceService, AdviceService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IExamCritereaService, ExamCritereaService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IArgumentCritereaService, ArgumentCritereaService>();
            services.AddScoped<IArgumentService, ArgumentService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICensorService, CensorService>();
            services.AddScoped<IExamAttemptService, ExamAttemptService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // configure jwt authentication
            var appSettings = app.ApplicationServices.GetService<IOptions<AppSettings>>().Value;
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            app.UseJwtBearerAuthentication(new JwtBearerOptions{
                AutomaticAuthenticate = true,
                TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }
            });

            app.UseMvc();
        }
    }
}
