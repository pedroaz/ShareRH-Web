using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PetBook.Domain.PetsDomain;
using PetBook.Infrastructure.Database;
using PetBook.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.PetsServices
{
    /// <summary>
    /// Default implementation of IPetService
    /// </summary>
    public class PetService : IPetService
    {
        private readonly PetBookDatabaseContext _dbContext;
        private readonly IHubContext<PetBookHub> _hubContext;

        public PetService(PetBookDatabaseContext dbContext, IHubContext<PetBookHub> hubContext)
        {
            _hubContext = hubContext;
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<List<Pet>> GetAll()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Pet> GetPet(int id)
        {
            return await _dbContext.Pets.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task AddPet(Pet pet)
        {
            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("Refresh");
        }

        /// <inheritdoc/>
        public async Task UpdatePetAge(string name, int age)
        {
            var petData = _dbContext.Pets.ToList().Find(_ => _.Name.Equals(name));
            petData.Age = age;
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("Refresh");
        }

        /// <inheritdoc/>
        public async Task DeleteAll()
        {
            _dbContext.Pets.RemoveRange(_dbContext.Pets);
            await _dbContext.SaveChangesAsync();
        }
    }
}
