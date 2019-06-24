using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FoldersAndTestCases.API.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoldersAndTestCases.API.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FoldersAndTestCases.API.Domain.Services;
using FoldersAndTestCases.API.Persistence.Contexts;
using FoldersAndTestCases.API.Services;
using FoldersAndTestCases.API.Persistence.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace FoldersAndTestCases.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>(options => {
                //options.UseInMemoryDatabase("FoldersAndTestCases-api-in-memory");
                options.UseSqlServer(Configuration.GetConnectionString("FoldersAndTestCaseFilesDB"));
            });
            
            // Set up dependency injection for controller's logger
            services.AddScoped<ILogger, Logger<FoldersController>>();
            services.AddScoped<ILogger, Logger<TestCaseFilesController>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();

            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IFolderService, FolderService>();
            services.AddScoped<ITestCaseRepository, TestCaseRepository>();
            services.AddScoped<ITestCaseService, TestCaseService>();


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "FoldersAndTestCases API", Version = "v1" });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //context.Database.EnsureCreated();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoldersAndTestCases API V1");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
