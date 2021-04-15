using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : DatabaseToBaseController {

        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherForecastController(
            ILoggerFactory loggerFactory
        ) : base(loggerFactory) {

            // empty

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() {

            var randomNumberGenerator = (Random)null;
            var temperatureCNumber = 0;
            var summaryNumber = 0;

            try {

                Logger.LogInformation("Get request for weather forecast received");

                randomNumberGenerator = new Random();

                Logger.LogInformation("Returning weather forecast");

                temperatureCNumber = randomNumberGenerator.Next(-20, 55);
                summaryNumber = randomNumberGenerator.Next(Summaries.Length);

                throw new Exception("Ahhhhh! There was an error!");

                return Enumerable
                    .Range(1, 5)
                    .Select(
                        index => new WeatherForecast {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = temperatureCNumber,
                            Summary = Summaries[summaryNumber]
                        }
                    )
                    .ToArray();

            }
            catch(Exception ex) {

                Logger.LogError("There was a fatal error, soft message returned to user", temperatureCNumber, summaryNumber);

                return new List<WeatherForecast> {
                    new WeatherForecast { ErrorDescription = ex.Message}
                };

            }

        }
    }
}
