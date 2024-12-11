﻿using GitHubStatistics.Api.Configuration;
using Microsoft.OpenApi.Models;

namespace GitHubStatistics.Api
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
            services.AddAuthentication();
            
            services.AddControllers();

            services
                .AddServerLogic(
                    Configuration.GetSection("DomainOptions"),
                    Configuration.GetSection("GitHubOptions"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
        }
    }
}
