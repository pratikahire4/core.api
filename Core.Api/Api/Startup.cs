using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using System.IO;
using System.Reflection;

namespace Api
{
    /// <summary>
    /// OG.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Injected obj.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IMongoClient, MongoClient>(s => 
            {
                var mongoUri = s.GetRequiredService<IConfiguration>()["MongoUri"];
                return new MongoClient(mongoUri);
            });
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("candidatesapi", new OpenApiInfo
                {
                    Title = "Candidates core api doc",
                    Version = "v1"
                });
                string fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string filepath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filepath);
            });         
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(x => 
            {
                x.SwaggerEndpoint("candidatesapi/swagger.json", "Candidates API");
            });
        }
    }
}
