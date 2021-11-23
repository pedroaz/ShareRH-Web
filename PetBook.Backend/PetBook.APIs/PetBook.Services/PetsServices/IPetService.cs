using PetBook.Domain.PetsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.PetsServices
{
    public interface IPetService
    {
        Task DeleteAll();
        Task AddPet(Pet pet);
        Task<Pet> GetPet(int id);
        Task<List<Pet>> GetAll();
    }
}
