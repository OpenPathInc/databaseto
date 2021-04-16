using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers {

    /// <summary>
    /// This creates the DatabaseToBaseController Class.
    /// </summary>
    public class DatabaseToBaseController : ControllerBase {

        /// <summary>
        /// An instance that creates logger for us.
        /// </summary>
        private ILoggerFactory _loggerFactory;

        /// <summary>
        /// A logger that can show us messages about our project.
        /// </summary>
        internal ILogger Logger { get; set; }

        /// <summary>
        /// This is the constructor for the DatabaseToBaseController Class
        /// </summary>
        public DatabaseToBaseController(
            ILoggerFactory loggerFactory
        ) {

            _loggerFactory = loggerFactory;
            Logger = _loggerFactory.CreateLogger<DatabaseToBaseController>();

        }

    }

}
