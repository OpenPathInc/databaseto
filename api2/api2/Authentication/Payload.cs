using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Authentication
{
    public class Payload
    {
        public string Version { get; set; }
        public string next_page { get; set; }
        public string last_page { get; set; }

        public int count { get; set; }

        public int page { get; set; }

        public int total { get; set; }
        public object results { get; set; }
    }
}
