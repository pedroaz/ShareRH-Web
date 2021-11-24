﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetBook.Domain.PetsDomain;
using PetBook.Domain.UsersDomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetBook.Infrastructure.Database
{
    public class PetBookDatabaseContext : DbContext, IPetBookDatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public PetBookDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var directory = directoryInfo.Parent.Parent.Parent;
            var dbPath = $"Data Source={directory}\\petbook.db";
            optionsBuilder.UseSqlite(dbPath);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
