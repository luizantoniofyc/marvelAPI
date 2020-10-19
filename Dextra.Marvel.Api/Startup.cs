using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Dextra.Marvel.Api.Filters;
using Dextra.Marvel.Application;
using Dextra.Marvel.Infra.Data;
using Dextra.Marvel.Infra.Data.Seeds;
using Dextra.Marvel.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Dextra.Marvel.Api
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
            services.AddCors();

            services.AddResponseCompression(
                options =>
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>();
                });
            services.Configure<BrotliCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
            services.Configure<GzipCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.Conventions.Add(new VersionByNamespaceConvention());
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = true;
                    options.RespectBrowserAcceptHeader = true;
                    options.Filters.Add(new ApplicationExceptionFilter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(
                options =>
                {
                    using (var serviceProvider = services.BuildServiceProvider())
                    {
                        var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                        }
                    }
                    
                    options.IncludeXmlComments(XmlCommentsFilePath);
                    options.IncludeXmlComments(XmlCommentsFilePathForModel);
                    options.DescribeAllParametersInCamelCase();
                    options.DescribeAllEnumsAsStrings();
                    options.DescribeStringEnumsInCamelCase();
                });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(DomainMappingProfile).Assembly);
            services.AddHttpClient();
            services.AddDIConfiguration();
            services.AddDbContext<MarvelContext>(options => options.UseInMemoryDatabase(databaseName: "MarvelDB"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
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

            app.UseCors(option => option.AllowAnyOrigin());
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                    options.RoutePrefix = string.Empty;
                });

            app.UseMvc();
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                return Path.Combine(AppContext.BaseDirectory, xmlFile);
            }
        }

        static string XmlCommentsFilePathForModel
        {
            get
            {
                var xmlFile = $"{new AssemblyName(typeof(Application.Models.Input.CharacterInput).GetTypeInfo().Assembly.FullName).Name}.xml";
                return Path.Combine(AppContext.BaseDirectory, xmlFile);
            }
        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = "Marvel API",
                Version = description.ApiVersion.ToString(),
                Description = "Reimplementation of character endpoints to show Thanos that together we are invincible."
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
