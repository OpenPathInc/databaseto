using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OpenPath.Reporting.Web.API.Extensions
{
    /// <summary>
    /// Health Extension
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class HealthExtension
    {
        #region Methods

        /// <summary>
        /// This extension will configure the health checks of the system
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();

            //  NOTE:
            //  You can add more health check monitoring component like, SQL database,
            //  Another Microservices connectivity, and your own customer health check component
            return services;
        }

        #endregion Methods
    }
}