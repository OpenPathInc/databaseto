using JWTAuthentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using Microsoft.AspNetCore.Builder;

namespace api2
{
    public class Program
    {
        public static void Main(string[] args) {

            // NLog: setup the logger first to catch all errors
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try {

                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex) {

                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;

            }
            finally {

                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();

            }

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => {

                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    logging.AddConsole();
                    logging.AddDebug();

                })
                .UseNLog()
                .ConfigureWebHostDefaults(webBuilder => {

                    webBuilder.UseSentry(o => {

                        o.Dsn = "https://249357a0278047a28dc760381b3983c3@o556010.ingest.sentry.io/5704172";
                        o.Release = "0.1";
                        o.MaxBreadcrumbs = 200;
                        o.MinimumBreadcrumbLevel = LogLevel.Information; // Debug and higher are stored as breadcrumbs (default is Info)
                        o.MinimumEventLevel = LogLevel.Error; // Error and higher is sent as event (default is Error)
                        o.AttachStacktrace = true;
                        o.DecompressionMethods = System.Net.DecompressionMethods.GZip;
                        o.MaxQueueItems = 100;
                        o.ConfigureScope(
                            scope =>
                            scope.SetTag("Application", "DatabaseTo API")
                        );
                        o.IncludeActivityData = true;

                    });

                })
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
