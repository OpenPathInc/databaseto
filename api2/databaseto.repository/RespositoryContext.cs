using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using databaseto.model.Database;

namespace databaseto.repository {

    public class RespositoryContext : DbContext {

        private protected string _connectionString;

        public RespositoryContext(
            string connectionString
        ) : base() {

            _connectionString = connectionString;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            // define the database to use and the execution stratigy
            optionsBuilder.UseSqlServer(
                _connectionString,
                sqlServerOptionsAction:sqlOptions => {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(6),
                        errorNumbersToAdd: null
                    ).CommandTimeout(60);
                }
            );
      
        }

        public DbSet<DatabaseConnectionModel> DatabaseConnection { get; set; }

    }

}
