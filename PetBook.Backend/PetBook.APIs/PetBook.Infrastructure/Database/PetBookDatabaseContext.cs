using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetBook.Domain.PetsDomain;
using PetBook.Domain.UsersDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetBook.Infrastructure.Database
{
    public class PetBookDatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        public PetBookDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration["SqlLiteConnection"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
