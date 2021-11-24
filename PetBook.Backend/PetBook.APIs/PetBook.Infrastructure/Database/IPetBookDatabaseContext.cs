using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetBook.Domain.PetsDomain;
using PetBook.Domain.UsersDomain;

namespace PetBook.Infrastructure.Database
{
    public interface IPetBookDatabaseContext
    {
        DbSet<Pet> Pets { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
