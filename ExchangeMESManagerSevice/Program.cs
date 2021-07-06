using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExchangeMESManagerSevice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///CreateWebHostBuilder(args).Build().Run();
            // получаем путь к файлу 
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            // путь к каталогу проекта
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            // создаем хост
            // запускаем в виде службы

            if (Debugger.IsAttached || args.Contains("--debug"))
            {
                var host = WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>()
                        .Build();
                host.Run();
            }
            else
            {
                var host = WebHost.CreateDefaultBuilder(args)
                      .UseContentRoot(pathToContentRoot)
                        .UseStartup<Startup>()
                        .Build();
                host.RunAsService();
            }



        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
