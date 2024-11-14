using DotNetEnv;
using SlnHost = Microsoft.Extensions.Hosting.Host;

namespace Sln.Payment.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Env.Load();
            return SlnHost.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
        }
    }
}