using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PetBook.Domain.PetsDomain;
using PetBook.Infrastructure.Database;
using PetBook.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.PetsServices
{
    public class PetService : IPetService
    {
        private readonly PetBookDatabaseContext _dbContext;
        private readonly IHubContext<PetBookHub> _hubContext;

        public PetService(PetBookDatabaseContext dbContext, IHubContext<PetBookHub> hubContext)
        {
            _hubContext = hubContext;
            _dbContext = dbContext;
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        public async Task<Pet> GetPet(int id)
        {
            return await _dbContext.Pets.FindAsync(id);
        }

        public async Task AddPet(Pet pet)
        {
            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("Refresh");
        }

        public async Task DeleteAll()
        {
            _dbContext.Pets.RemoveRange(_dbContext.Pets);
            await _dbContext.SaveChangesAsync();
        }
    }
}
