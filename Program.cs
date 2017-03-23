using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeowWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {

#if !DEBUG
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";
#endif
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
#if !DEBUG
                .UseUrls(url)
#endif
                .Build();

            host.Run();
        }
    }
}
