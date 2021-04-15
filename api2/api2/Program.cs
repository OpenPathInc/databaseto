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
                //.Sen(sentry => {

                //    sentry.Release = Open.Path.Global.Environment.Version;
                //    sentry.MaxBreadcrumbs = 200;
                //    sentry.MinimumBreadcrumbLevel = Microsoft.Extensions.Logging.LogLevel.Information; // Debug and higher are stored as breadcrumbs (default is Info)
                //    sentry.MinimumEventLevel = Microsoft.Extensions.Logging.LogLevel.Error; // Error and higher is sent as event (default is Error)
                //    sentry.Dsn = "https://0047f607e2b44322ac53c2f1a91d64c5@o556010.ingest.sentry.io/5686339";
                //    sentry.AttachStacktrace = true;
                //    //sentry.SendDefaultPii = true; // Send Personal Identifiable information like the username of the user logged in to the device
                //    sentry.DecompressionMethods = System.Net.DecompressionMethods.GZip;
                //    sentry.MaxQueueItems = 100;
                //    sentry.ConfigureScope(
                //        scope =>
                //        scope.SetTag("Application", "Transaction API")
                //    );
                //    sentry.IncludeActivityData = true;

                //})
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
