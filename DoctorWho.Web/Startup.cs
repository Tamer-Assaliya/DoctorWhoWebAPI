using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DoctorWho.Db;
using FluentValidation.AspNetCore;
using FluentValidation;
using DoctorWho.Web.Validators;

namespace DoctorWho.Web
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
            services.AddControllers().AddFluentValidation();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<DoctorRepository>();
            services.AddScoped<EpisodeRepository>();
            services.AddScoped<EpisodeCompanionRepository>();
            services.AddScoped<EpisodeEnemyRepository>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<EnemyRepository>();
            services.AddScoped<CompanionRepository>();
            services.AddDbContext<DoctorWhoCoreDbContext>(
                options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DoctorWhoWeb"));
            }
            );
            services.AddTransient<IValidator<Models.DoctorForUpadteDto>, DoctorForUpdateDtoValidator>();
            services.AddTransient<IValidator<Models.EpisodeForCreationDto>, EpisodeForCreationDtoValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
