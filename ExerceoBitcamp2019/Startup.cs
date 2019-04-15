using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
// using Microsoft.OpenApi.Models; - Uncomment in .NetCore 2.2
using Swashbuckle.AspNetCore.Swagger;

namespace ExerceoBitcamp2019
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
            IMvcBuilder mvcBuilder = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
#if DEBUG 
            mvcBuilder.AddJsonOptions(options => { options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;});
#endif
            services.AddSwaggerGen(c =>
                {
                    c.DescribeAllEnumsAsStrings();
                    c.SwaggerDoc("v1", new Info //OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ExerceoBitcamp2019",
                        Description = "This is our hackathon project.",
                        Contact = new Contact //OpenApiContact
                        {
                            Name = "ExerceoBitGroup",
                            Email = string.Empty,
                            Url = ""//new Uri("https://google.com") 
                        },
                        License = new License //OpenApiLicense
                        {
                            Name = "Use under Apache",
                            Url = ""//new Uri("https://google.com")
                        }
                    });
                    //var xmlFile = $"{Assembly.GetExecut ingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //c.IncludeXmlComments(xmlPath);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exerceo Bitcamp 2019");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
