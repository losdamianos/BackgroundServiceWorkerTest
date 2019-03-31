using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace WorkerTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
      
                var settings = new EventLogSettings
            {
                SourceName = "Worker2",
                 LogName = "Worker2"
                  
            };
            return Host.CreateDefaultBuilder(args)
                        .ConfigureLogging(loggerFactory => loggerFactory.AddEventLog(settings))
                        .UseServiceBaseLifetime()
                        .ConfigureServices(services =>
                        {
                        services.AddHostedService<Worker>();
                        });
        }
    }
}
