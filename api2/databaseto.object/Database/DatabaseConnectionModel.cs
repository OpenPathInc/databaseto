using databaseto.model.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace databaseto.model.Database {

    [Table("DatabaseConnections")]
    public class DatabaseConnectionModel {

        public long Id { get; set; }

        public string Name { get; set; }
    

        public string ConnectionString { get; set; }

        public DatabaseType Type { get; set; }

    }

}
