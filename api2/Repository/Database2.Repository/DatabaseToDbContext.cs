using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Database2.Repository {

    public class DatabaseToDbContext : DbContext {

        private protected string _connectionString;

        public DatabaseToDbContext(
            string connectionString
        ) : base() {

            _connectionString = connectionString;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            // if we don't have a connection string, load one from file
            // NOTE: This code should be removed in the long term.
            if (string.IsNullOrWhiteSpace(_connectionString)) {

                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

                var root = builder.Build();
                var sampleConnectionString = root.GetConnectionString("DatabaseTo");

            }

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

        public DbSet<DatabaseTo.Model.Data.DatabaseConnection> DatabaseConnections { get; set; }

    }

}
