using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenPath.Reporting.Core.Interfaces;
using OpenPath.Reporting.Domain.Entities;
using OpenPath.Reporting.Services;
using OpenPath.Reporting.Web.API.Extensions;
using OpenPath.Reporting.Web.API.Middleware;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OpenPath.Reporting.Web.API
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.This method gets called by the runtime. Use this method to add services to the container.      
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddControllers();
            services.AddAuthorization();
            //  Configure the web API to use OAuth Identity server
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication((options) =>
                {
                    var IdsConfiguration = Configuration.GetSection("IdentityServerConfiguration").Get<IdentityServerAuthenticatorConfiguration>();
                    options.Authority = IdsConfiguration.Server;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = IdsConfiguration.Scopes.FirstOrDefault();
                });

            services.AddLogging(configure => {
                configure.AddConsole();
                configure.AddDebug();
            });

            services.AddHealthCheck(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //  Cofigure app to have an endpoint for health that will
            //  be use by the kubernetes health monitoring feature
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseMiddleware<ExceptionLogMiddleware>();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
