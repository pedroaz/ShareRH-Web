using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetBook.Domain.PetsDomain;
using PetBook.Domain.UsersDomain;

namespace PetBook.Infrastructure.Database
{
    public class PetBookAzureDatabaseContext : DbContext, IPetBookDatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public PetBookAzureDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _configuration.GetConnectionString("dbDefaultConnection");

            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
