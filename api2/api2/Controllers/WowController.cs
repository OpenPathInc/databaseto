using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WowController : Controller {

        [HttpGet]
        public string Index(string name) {

            using(var db2Context = new DatabaseToDbContext()) {

                var record = new DatabaseTo.Model.Data.DatabaseConnection {
                    Name = name,
                    Description = "Is this not cool!"
                };

                db2Context.DatabaseConnections.Add(record);

                db2Context.SaveChanges();

                return $"added {name} successfully with id {record.Id}";

            }

        }

    }

}
