using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FrontEnd
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(opt =>
                    {
                        opt.ListenAnyIP(443, listenOpt =>
                        {
                            listenOpt.UseHttps(@"D:\Certificates\usermanagementsystem.com.pfx", "12345678");
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}