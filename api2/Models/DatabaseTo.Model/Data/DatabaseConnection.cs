using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DatabaseTo.Model.Enumerator;

namespace DatabaseTo.Model.Data {

    [Table("DatabaseConnections")]
    public class DatabaseConnection {

        /// <summary>
        /// The unique id for this database connection.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// A name for this database connection.
        /// </summary>
        [MaxLength(255)]
        public string Name { get; set; }

    }

}
