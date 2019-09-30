using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using CSharp.Infra.Migration;
using CSharp.Infra.CrossCutting.AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using CSharp.Infra.CrossCutting.Ioc;
using CSharp.ApiProject.Response;

namespace CSharpApiProject
{
    public class Startup
    {
        private const string Version = "1";
        private const string ProjectTitleName = "CSharp.ApiProject";
        private readonly IConfigurationRoot _configurationRoot;

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true);

            _configurationRoot = builder.Build();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt =>
                {

                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            //services.AddHostedService<Application.Tasks.ConsultaSefazBackground>();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddAutoMapper(config =>
            {
                config.ForAllMaps((map, expression) =>
                {
                    foreach (var unmappedPropertyName in map.GetUnmappedPropertyNames())
                        expression.ForMember(unmappedPropertyName,
                            configurationExpression => configurationExpression.Ignore());
                });

                config.AddProfiles(typeof(ApplicationProfile).Assembly);
            });

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));


            ConfigureSwagger(services);

            var connectionString = _configurationRoot.GetConnectionString("DefaultConnection");

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer2016()
                    // Set the connection string
                    .WithGlobalConnectionString(connectionString)
                    // Define the assemblies containing the migrations
                    .ScanIn(typeof(BaseLine).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.DescribeAllEnumsAsStrings();
                s.DescribeStringEnumsInCamelCase();
                s.DescribeAllParametersInCamelCase();
                s.SwaggerDoc($"v{Version}", new Info
                {
                    Version = $"v{Version}",
                    Title = ProjectTitleName,
                    Description = "API Swagger surface",                   
                    Contact = new Contact
                    {
                        Name = "Contact_Name",
                        Email = "Contact_Email",
                        Url = "Url"
                    },
                });

                //var filePath = Path.Combine(@"C:\Users\Marceçp\Desktop\CSharpTestProject-master\CSharpTestProject-master\CSharpApiProject\", $"{ ProjectTitleName}.xml");
                //s.IncludeXmlComments(filePath);

               // s.OperationFilter<AuthResponsesOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint($"/swagger/v{Version}/swagger.json", "Praxio API");
         
            });

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            migrationRunner.MigrateUp();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionString = _configurationRoot.GetConnectionString("DefaultConnection");

            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new InfraModule(connectionString));

            builder.RegisterType<Presenter>();

        }

    }
}
