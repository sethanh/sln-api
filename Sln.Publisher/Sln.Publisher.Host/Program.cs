namespace Sln.Publisher.Host;

using DotNetEnv;
using Microsoft.Extensions.Hosting;
public partial class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
        Env.Load();
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
    }
       
}