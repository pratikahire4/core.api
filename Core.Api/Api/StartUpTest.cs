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
    public class StartUpTest
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
                return new MongoClient("mongodb+srv://learnitdevmongo:mongoUser1earnitdev@cluster0.layqp.mongodb.net/donationdb?retryWrites=true&w=majority");
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
        }
    }
}
