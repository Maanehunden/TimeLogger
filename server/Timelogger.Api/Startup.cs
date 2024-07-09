using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Timelogger.Data.Models;
using FreelancerTimeTracking.API.Mappings;
using System.Data;
using Timelogger.Api.Services;
using Timelogger.Data.Repositories;
using Timelogger.Data;
using System.IO;
using System.Threading.Tasks;
using System;
using Dapper;
using System.Data.SQLite;
using System.Data.Entity.Migrations.Design;
using Timelogger.Data.Migrations;

namespace Timelogger.Api
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
            services.AddControllers();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Register Dapper connection factory
            services.AddScoped<IDbConnection>(sp =>
                new DapperConnectionFactory(Configuration.GetConnectionString("DefaultConnection")).CreateConnection());

            // Register repositories and services
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITimeRegistrationRepository, TimeRegistrationRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITimeRegistrationService, TimeRegistrationService>();
        }

/*        private async Task ExecuteSqlScriptIfDatabaseNotExists(IServiceProvider serviceProvider)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var dbFilePath = new SQLiteConnectionStringBuilder(connectionString).DataSource;

            if (!File.Exists(dbFilePath))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbConnection = scope.ServiceProvider.GetRequiredService<IDbConnection>();

                    await dbConnection.ExecuteAsync(MigrationsCommands.InitCreate);
                }
            }
        }*/


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Execute the InitialCreate.sql script
            DatabaseInitializer.Initialize(Configuration.GetSection("SqlLiteDbName").Get<string>());
           // ExecuteSqlScriptIfDatabaseNotExists(app.ApplicationServices).GetAwaiter().GetResult();
        }
    }
}