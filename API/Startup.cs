using System.Data.Common;
using System.Data.SqlClient;
using API.Utils.RSA;
using DAL.Services.Repositories.Classes;
using DAL.Services.Repositories.Lunches;
using DAL.Services.Repositories.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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


            services.AddControllers();
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionStringObj(connectionString));
            services.AddSingleton<Connection>();
            string PassPhrase = @"?*w*92%&+d_pxTU8j3gUMsDDkU*pr@fvva*u5CBMV&Qpju$xsbx2s#UM3uhSrCB^2=pk&53JDB69SYV*48=YaQFjRTcQLPLA#sFVjZjb5ja=mkAuh?Yb*T5!G6mHf_+Zy$e5km@*fjEBBzcK8g!H4QCU*vYrEAE^p9TBUmCfPQSyC!f6tpQyBYKrT!AaMLycJL@94m94-tNmWa6b&Jw@s+2hqF2YB_G_+3k?uZU4L*gT5f5aK2F5_TvnEvtr7vE&";
            services.AddSingleton<ITokenService, TokenService>(token => new TokenService(PassPhrase));
            //REPOSITORIES
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ClassRepository>();
            services.AddSingleton<ContactRepository>();
            services.AddSingleton<StatusRepository>();
            services.AddSingleton<LunchRepository>();

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
