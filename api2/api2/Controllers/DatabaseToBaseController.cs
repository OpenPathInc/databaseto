using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers {

    public class DatabaseToBaseController : ControllerBase {

        private ILoggerFactory _loggerFactory;

        internal ILogger Logger { get; set; }

        public DatabaseToBaseController(
            ILoggerFactory loggerFactory
        ) {

            _loggerFactory = loggerFactory;
            Logger = _loggerFactory.CreateLogger<DatabaseToBaseController>();

        }

    }

}
