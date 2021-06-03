using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseTo.Model.Data {

    [Table("Queries")]
    public class Query {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public DatabaseConnection Connection { get; set; }

    }
}
