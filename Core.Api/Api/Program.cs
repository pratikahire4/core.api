using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    ///First class that starts because of the main method.
    public class Program
    {
        ///Main
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        ///Builds server to host the aspnetcore app.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
