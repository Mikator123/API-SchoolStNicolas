using System.Data.Common;
using System.Data.SqlClient;
using API.Utils.RSA;
using DAL.Services.Repositories;
using DAL.Services.Repositories.Classes;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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


            services.AddControllers();
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionStringObj(connectionString));
            services.AddSingleton<Connection>();
            //REPOSITORIES
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ClassRepository>();
            services.AddSingleton<ContactRepository>();
            services.AddSingleton<StatusRepository>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
