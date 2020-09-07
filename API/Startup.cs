using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using API.Utils.AppSettings;
using API.Utils.RSA;
using DAL.Services.Repositories.RelativeToClass;
using DAL.Services.Repositories.RelativeToSchool;
using DAL.Services.Repositories.RelativeToUser;
using DAL.Services.Repositories.RelativeToWorkingProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ToolBox.SecurityToken;
using ToolBoxDB;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            IConfigurationSection dbSection = Configuration.GetSection("DbConnectionSettings");
            DbConnectionSettings dbConnectionSettings = dbSection.Get<DbConnectionSettings>();
            string connectionString = dbSection.Get<DbConnectionSettings>().ConnectionString;

            IConfigurationSection TokenSection = Configuration.GetSection("TokenSettings");
            TokenPassPhrase tokenPP = TokenSection.Get<TokenPassPhrase>();
            string PassPhrase = TokenSection.Get<TokenPassPhrase>().PassPhrase;

            //Authorization en ASP CORE
            //services.Configure<TokenPassPhrase>(TokenSection);
            //byte[] key = Encoding.ASCII.GetBytes(PassPhrase);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});




            services.AddControllers();
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionStringObj(connectionString));
            services.AddSingleton<Connection>();
            services.AddSingleton<ITokenService, TokenService>(token => new TokenService(PassPhrase));
            //REPOSITORIES
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ClassRepository>();
            services.AddSingleton<ContactRepository>();
            services.AddSingleton<UserStatusRepository>();
            services.AddSingleton<LunchRepository>();
            services.AddSingleton<TrimestrialInfoRepository>();
            services.AddSingleton<SchoolRuleRepository>();
            services.AddSingleton<SchoolEventRepository>();
            services.AddSingleton<SchoolYearCategoryRepository>();
            services.AddSingleton<TeachingCategoryRepository>();
            services.AddSingleton<TestResultRepository>();
            services.AddSingleton<WorkingProfileQuestionRepository>();
            services.AddSingleton<WorkingProfileDocumentRepository>();
            services.AddSingleton<AuthRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
